using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using OnlineShop.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.Orders.Querry.GetOrders
{
    public interface IGetOrderService
    {
        ResultDto<List<RequestGetOrderDto>> Execute(long UserId);
    }

    public class GetOrderService : IGetOrderService
    {
        private readonly IDataBaseContext _context;
        public GetOrderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RequestGetOrderDto>> Execute(long UserId)
        {
            var order = _context.Orders
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id).ToList().Select(p => new RequestGetOrderDto
                {
                    OrderId = p.Id,
                    OrderState = p.OrderState,
                    RequestPayId = p.RequestPayId,
                    OrderDetails = p.OrderDetails.Select(o => new OrderDetailDto
                    {
                        OrderDetailId = o.OrderId,
                        Count = o.Count,
                        Price = o.Price,
                        ProductId = o.ProductId,
                        ProductName = o.Product.Name
                    }).ToList(),
                }).ToList();

            return new ResultDto<List<RequestGetOrderDto>>
            {
                Data = order,
                IsSuccess = true,
            };
        }
    }

    public class RequestGetOrderDto
    {
        public long OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public long RequestPayId { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }

    public class OrderDetailDto
    {
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }

}
