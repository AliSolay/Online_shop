using Endpoint.site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Users.Command.EidtUsers;
using OnlineShop.Application.Services.Users.Command.RegisterUsers;
using OnlineShop.Common.Dto;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersFacad _usersFacad;
        public UsersController(IUsersFacad usersFacad)
        {
            _usersFacad = usersFacad;
        }

        public IActionResult Index(string serchkey, int page = 1)
        {
            return View(_usersFacad.GetUsersService.Execute(new RequestPageDto
            {
                Page = page,
                SearchKey = serchkey,
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_usersFacad.GetRolesService.Execute().Data, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _usersFacad.RegisterUserService.Execute(new RequestRegisterUserServiceDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesRegisterUserServiceDto>
                {
                    new RolesRegisterUserServiceDto
                    {
                        Id = RoleId
                    }
                },
                Password = Password,
                RePassword = RePassword,

            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long userId)
        {
            return Json(_usersFacad.DeleteUserService.Execute(userId));
        }

        [HttpPost]
        public IActionResult ChangeStatusUser(long userId)
        {
            return Json(_usersFacad.UserStatusChangeService.Execute(userId));
        }


        [HttpPost]
        public IActionResult Edit(long UserId, string FullName, string Email)
        {
            var role = ClaimUtility.GetRolse(User);

            return Json(_usersFacad.EditUserService.Execute(new RequestEdituserDto
            {
                userId = UserId,
                Fullname = FullName,
                Email = Email,
            }));
        }

    }
}