using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LuigiiLuxury.Services;
using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Areas.Admin.Controllers
{
    public class CartController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly IProductsService _productsService;
        private readonly IOrdersService _ordersService;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly ICountriesService _countriesService;
        private ICartService _cartService;

        public CartController(
            IProductsService productsService,
            IOrdersService ordersService,
            IUsersService usersService,
            ICountriesService countriesService,
            IOrderDetailsService ordersDetailsService,
            ICartService cartService
            )
        {
            _productsService = productsService;
            _usersService = usersService;
            _ordersService = ordersService;
            _countriesService = countriesService;
            _orderDetailsService = ordersDetailsService;
            _cartService = cartService;
        }

        private void SaveSession()
        {
            Session["Items"] = _cartService.Items;
            Session["CountOfItemInCart"] = _cartService.Items.Count;
            Session["CartTotal"] = _cartService.CartTotal;
        }

        private void ClearSession()
        {
            HttpContext.Session.Remove("Items");
            HttpContext.Session.Remove("CountOfItemInCart");
            HttpContext.Session.Remove("CartTotal");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToCart(int productId)
        {
            if (Session["Items"] != null) // nếu Cart đã được tạo
            {
                _cartService.Items = (List<ItemViewModel>)Session["Items"];
                _cartService.CartTotal = Convert.ToInt32(Session["CartTotal"]);
            }

            _cartService.Add(productId);
            SaveSession();

            return RedirectToAction("Index");
        }

        public ActionResult RemoveItem(int productId)
        {
            if (Session["Items"] != null)
            {
                _cartService.Items = (List<ItemViewModel>)Session["Items"];
                _cartService.CartTotal = Convert.ToInt32(Session["CartTotal"]);
            }

            _cartService.Remove(productId);

            if (_cartService.CartTotal == 0)
                ClearSession();
            else
                SaveSession();

            return RedirectToAction("Index");
        }

        // GET: Cart/Checkout
        public ActionResult Checkout()
        {
            OrderFormViewModel order = null;
            if (Session["Items"] != null)
            {
                if (Session["CurrentUserId"] != null)
                {
                    int id = Convert.ToInt32(Session["CurrentUserId"]);
                    var user = _usersService.Get(id);

                    order = new OrderFormViewModel()
                    {
                        Email = user.Email,
                        UserId = user.Id,
                        ShipPhoneNumber = user.PhoneNumber,
                        ShipAddress = user.Address,
                        ShipFullName = _usersService.GetFullName(user.Id)
                    };

                    return View(order);
                }
                else
                    return View();

            }
            else
                return HttpNotFound();
        }
        // POST: Cart/Checkout
        [HttpPost]
        public ActionResult Checkout(OrderFormViewModel orderForm)
        {
            if (ModelState.IsValid)
            {
                int orderId = _ordersService.Add(orderForm);
                var items = (List<ItemViewModel>)Session["Items"];

                _cartService.SaveOrderDetails(items, orderId);
                ClearSession();

                return RedirectToAction("CheckoutSuccess");
            }

            return View();
        }

        public ActionResult CheckoutSuccess()
        {
            return View();
        }

        public ActionResult MyOrders(int userId)
        {
            if (_usersService.IsExistingInDatabase(userId))
            {
                var orders = _ordersService.GetOrdersByUserId(userId);

                if (orders != null)
                    return View();
                return View();

            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}