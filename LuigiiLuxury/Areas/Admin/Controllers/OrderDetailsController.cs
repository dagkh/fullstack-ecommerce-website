using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Areas.Admin.Controllers
{
    public class OrderDetailsController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return HttpNotFound();
            else
                return View();
        }
    }
}

