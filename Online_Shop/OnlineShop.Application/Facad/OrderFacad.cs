using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Orders.Command.AddNewOrder;
using OnlineShop.Application.Services.Orders.Querry.GetOrders;
using OnlineShop.Application.Services.Orders.Querry.GetOrdersAdmin;

namespace OnlineShop.Application.Facad
{
    public class OrderFacad : IOrderFacad
    {
        private readonly IDataBaseContext _context;
        public OrderFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private IGetOrdersForAdminService _getOrdersForAdminService;
        public IGetOrdersForAdminService GetOrdersForAdminService
        {
            get
            {
                return _getOrdersForAdminService = _getOrdersForAdminService ?? new GetOrdersForAdminService(_context);
            }
        }

        private IGetOrderService _getOrderService;
        public IGetOrderService GetOrderService
        {
            get
            {
                return _getOrderService = _getOrderService ?? new GetOrderService(_context);
            }
        }

        private IAddNewOrderService _addNewOrderService;
        public IAddNewOrderService AddNewOrderService
        {
            get
            {
                return _addNewOrderService = _addNewOrderService ?? new AddNewOrderService(_context);
            }
        }
    }
}
