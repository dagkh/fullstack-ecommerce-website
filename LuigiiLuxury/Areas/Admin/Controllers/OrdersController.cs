using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public ActionResult Index()
        {
            if (Session["Admin"] == null)
                return HttpNotFound();
            else
                return View();
        }

        // GET: Details
        public ActionResult Details(int orderId)
        {
            if (Session["Admin"] == null)
                return HttpNotFound();
            else
            {
                var order = _ordersService.Get(orderId);

                return View(order);
            }
        }
    }
}