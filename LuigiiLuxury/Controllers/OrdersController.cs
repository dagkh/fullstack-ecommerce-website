using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var orders = _ordersService.GetAll();

            return View(orders);
        }
    }
}