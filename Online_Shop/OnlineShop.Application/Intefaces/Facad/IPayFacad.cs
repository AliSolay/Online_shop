using OnlineShop.Application.Services.Finances.Comand.AddRequestPay;
using OnlineShop.Application.Services.Finances.Query.GetRequestPay;
using OnlineShop.Application.Services.Finances.Query.GetRequestPayAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Intefaces.Facad
{
    public interface IPayFacad
    {
        IAddRequestPayService AddRequestPayService { get; }
        IGetRequestPayService GetGetRequestPayService { get; }
        IGetRequestPayAdminService GetRequestPayAdminService { get; }
    }
}
