using Microsoft.EntityFrameworkCore;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using OnlineShop.Common.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Finances.Query.GetRequestPayAdmin
{
    public interface IGetRequestPayAdminService
    {
        ResultDto<RequestPayAdminDto> Execute(int Page, int pageSize);
    }

    public class GetRequestPayAdminService : IGetRequestPayAdminService
    {
        private readonly IDataBaseContext _context;
        public GetRequestPayAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<RequestPayAdminDto> Execute(int Page, int pageSize)
        {
            var rowCount = 0;
            var requestPay = _context.RequestPays.Include(p => p.User);
            var pay = requestPay.ToPaged(Page, pageSize, out rowCount);
            


            return new ResultDto<RequestPayAdminDto>
            {
                Data = new RequestPayAdminDto
                {
                    Rows = rowCount,
                    ResultPayDtos = requestPay.Select(p => new ResultPayDto
                    {
                        Id = p.User.Id,
                        Amount = p.Amount,
                        Authority = p.Authority,
                        Guid = p.Guid,
                        RefId = p.RefId,
                        PayDate = p.PayDate,
                        IsPay = p.IsPay,
                        UserId = p.UserId,
                        UserName = p.User.FullName,
                    }).ToList(),
                },
                IsSuccess = true,
            };
        }
    }

    public class RequestPayAdminDto
    {
        public List<ResultPayDto> ResultPayDtos { get; set; }
        public int Rows { get; set; }
    }

    public class ResultPayDto
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; } = "";
        public long RefId { get; set; } = 0;
    }
}
