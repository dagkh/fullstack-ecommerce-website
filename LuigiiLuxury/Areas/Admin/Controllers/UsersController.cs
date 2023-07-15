using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return HttpNotFound();
            else
                return View();
        }

        public ActionResult Details(int userId)
        {
            if (Session["Admin"] == null)
                return HttpNotFound();
            else
            {
                var user = _usersService.Get(userId);

                if (user != null)
                    return View(userId);
                else
                    return HttpNotFound();
            }
        }
    }
}