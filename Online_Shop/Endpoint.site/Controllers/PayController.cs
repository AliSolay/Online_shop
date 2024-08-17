using Dto.Payment;
using Endpoint.site.Utilities;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Carts;
using OnlineShop.Application.Services.Orders.Command.AddNewOrder;
using ZarinPal.Class;

namespace Endpoint.site.Controllers
{
    [Authorize("Customer")]
    public class PayController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IPayFacad _payFacad;
        private readonly IOrderFacad _orderFacad;
        private readonly CookiesManeger _cookiesManeger;
        private readonly Payment _payment; private readonly Authority _authority; private readonly Transactions _transactions;
        public PayController(ICartService cartService, IOrderFacad orderFacad,IPayFacad payFacad)
        {
            _payFacad = payFacad;
            _cartService = cartService;
            _orderFacad = orderFacad;
            _cookiesManeger = new CookiesManeger();
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index()
        {
            long? userId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), userId);
            if (cart.Data.SumAmount>0)
            {
                var requestPay = _payFacad.AddRequestPayService.Execute(cart.Data.SumAmount, userId.Value);

                //ارسال به درگاه پرداخت

                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09121112222",
                    CallbackUrl = "https://localhost:44341/pay/verify?guid{requestPay.Data.guid}",
                    Description = "پرداخت شماره فاکتور:" + requestPay.Data.RequestPayId,
                    Email = requestPay.Data.Email,
                    Amount = requestPay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");

            }
            else
            {
                return RedirectToAction("index,cart");
            }
            return View();
        }

        public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        {

            var requestPay = _payFacad.GetGetRequestPayService.Execute(guid);

            var verification = await _payment.Verification(new DtoVerification
            {
                Amount = requestPay.Data.Amount,
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Authority = authority
            }, Payment.Mode.sandbox);


            //var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", $"{{\"MerchantID\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{10000}\"}}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //VerificationPayResultDto verification = JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);
            long? UserId = ClaimUtility.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), UserId);

            if (verification.Status == 100)
            {
                _orderFacad.AddNewOrderService.Execute(new RequestAddOrderDto
                {
                    CartId = cart.Data.CartId,
                    UserId = UserId.Value,
                    RequestPayId = requestPay.Data.Id
                });

                //redirect to orders
                return RedirectToAction("Index", "Orders");
            }
            else
            {
                Console.WriteLine("پرداخت ناموفق");
            }

            return View();
        }
    }
}
