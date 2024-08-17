using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Finances.Query.GetRequestPay
{
    public interface IGetRequestPayService
    {
        ResultDto<RequsetPayDto> Execute(Guid guid);
    }

    public class GetGetRequestPayService : IGetRequestPayService
    {
        private readonly IDataBaseContext _context;
        public GetGetRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<RequsetPayDto> Execute(Guid guid)
        {
            var requsetPay = _context.RequestPays.Where(p => p.Guid == guid).FirstOrDefault();

            if (requsetPay != null)
            {
                return new ResultDto<RequsetPayDto>()
                {
                    Data = new RequsetPayDto
                    {
                        Amount = requsetPay.Amount,
                        Id = requsetPay.Id,
                    },
                    IsSuccess = true,
                };
            }
            else
            {
                throw new Exception("RequestPay Not Found");
            }
        }
    }

    public class RequsetPayDto
    {
        public long Id { get; set; }
        public int Amount { get; set; }
    }
}
