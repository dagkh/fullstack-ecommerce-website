using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces.Services;
using LuigiiLuxury.Services;

namespace LuigiiLuxury.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            this._productsService = productsService;
        }

        public ActionResult Details(int productId)
        {
            var product = _productsService.Get(productId);

            return View(product);
        }
    }
}