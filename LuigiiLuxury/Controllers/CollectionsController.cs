using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Services;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly IBrandsService _brandsService;

        public CollectionsController(IProductsService productsService, IBrandsService brandsService)
        {
            _productsService = productsService;
            _brandsService = brandsService;
        }

        public ActionResult Index(string brand, string sortBy, int? page)
        {
            if (page == null)
                page = 1;

            var products = _productsService.GetAll();

            if (!String.IsNullOrEmpty(brand))
            {
                if (brand != "all brands")
                    products = products.Where(p => p.Brand.Name == brand).ToList();
            }

            switch (sortBy)
            {
                case "price-ascending":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price-descending":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "AVAI":
                    products = products.OrderByDescending(p => p.AvailabilityStatusCode == "AVAI");
                    break;
                case "SOLD":
                    products = products.OrderByDescending(p => p.AvailabilityStatusCode == "SOLD");
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            ViewBag.Brand = brand;
            ViewBag.Sort = sortBy;

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return View(products.ToPagedList(pageNumber, pageSize));
        }
    }
}
