using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Finances.Comand.AddRequestPay;
using OnlineShop.Application.Services.Finances.Query.GetRequestPay;
using OnlineShop.Application.Services.Finances.Query.GetRequestPayAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Facad
{
    public class PayFacad : IPayFacad
    {
        private readonly IDataBaseContext _context;
        public PayFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private IAddRequestPayService _addRequestPayService;
        public IAddRequestPayService AddRequestPayService
        {
            get
            {
                return _addRequestPayService = _addRequestPayService ?? new AddRequestPayService(_context);
            }
        }

        private IGetRequestPayService _getRequestPayService;
        public IGetRequestPayService GetGetRequestPayService
        {
            get
            {
                return _getRequestPayService = _getRequestPayService ?? new GetGetRequestPayService(_context);
            }
        }

        private IGetRequestPayAdminService _getRequestPayAdminService;
        public IGetRequestPayAdminService GetRequestPayAdminService
        {
            get
            {
                return _getRequestPayAdminService = _getRequestPayAdminService ?? new GetRequestPayAdminService(_context);
            }
        }
    }
}
