using OnlineShop.Application.Services.Orders.Command.AddNewOrder;
using OnlineShop.Application.Services.Orders.Querry.GetOrders;
using OnlineShop.Application.Services.Orders.Querry.GetOrdersAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Intefaces.Facad
{
    public interface IOrderFacad
    {
        IGetOrdersForAdminService GetOrdersForAdminService { get; }
        IGetOrderService GetOrderService { get; }
        IAddNewOrderService AddNewOrderService { get; }

    }
}
