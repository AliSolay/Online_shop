using Microsoft.EntityFrameworkCore;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using OnlineShop.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Orders.Command.AddNewOrder
{
    public interface IAddNewOrderService
    {
        ResultDto Execute(RequestAddOrderDto request);
    }

    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDataBaseContext _context;
        public AddNewOrderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestAddOrderDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var requestPay = _context.RequestPays.Find(request.RequestPayId);
            var cart = _context.Carts.Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .Where(p => p.Id == request.CartId).FirstOrDefault();
            
            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.Authority = request.Authority;
            requestPay.RefId = request.RefId;

            cart.Finished = true;

            Order order = new Order
            {
                Address = "",
                User = user,
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                
            };

            _context.Orders.Add(order);

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product,
                };

                orderDetails.Add(orderDetail);
            }

            _context.OrderDetails.AddRange(orderDetails);

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "عملیات با موفقیت انجام شد"
            };
        }
    }

    public class RequestAddOrderDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }
        public string? Authority { get; set; }
        public long RefId { get; set; } = 0;
    }
}
