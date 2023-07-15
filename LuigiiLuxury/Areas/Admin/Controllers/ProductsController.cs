using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using LuigiiLuxury.Services;
using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public ActionResult Index()
        {

            if (Session["Admin"] == null)
                return HttpNotFound();
            else
                return View();
        }

        public ActionResult Details(int productId)
        {

            if (Session["Admin"] == null)
                return HttpNotFound();
            else
            {
                var product = _productsService.Get(productId);

                var productForm = new ProductFormViewModel
                {
                    Id = product.Id,
                    Thumbnail = product.Thumbnail,
                    Name = product.Name,
                    Price = product.Price,
                    NumberOfProducts = product.NumberOfProducts,
                    DiscountPrice = product.DiscountPrice,
                    Description = product.Description,
                    Condition = product.Condition,
                    AvailabilityStatusCode = product.AvailabilityStatusCode,
                    BrandId = product.BrandId
                };

                return View(productForm);
            }
        }
        public ActionResult Create()
        {
            if (Session["Admin"] == null)
                return HttpNotFound();
            else
                return View();
        }
        [HttpPost]
        public ActionResult Create(ProductFormViewModel productForm, HttpPostedFileBase image)
        {
            if (Session["Admin"] == null)
                return HttpNotFound();
            else
            {
                if (image != null && image.ContentLength > 0)
                {
                    string fileName = image.FileName;
                    string path = Path.Combine(Server.MapPath("/Images/UploadProductImages/"), fileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                        image.SaveAs(path);
                    }
                    else
                        image.SaveAs(path);

                    productForm.Thumbnail = "/Images/UploadProductImages/" + fileName;
                }

                if (ModelState.IsValid)
                {
                    this._productsService.Add(productForm);

                    return RedirectToAction("Index");
                }
                else
                    return View(productForm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductFormViewModel productForm, HttpPostedFileBase image)
        {
            if (Session["Admin"] == null)
                return HttpNotFound();
            else
            {
                if (image != null && image.ContentLength > 0)
                {
                    string fileName = image.FileName;
                    string path = Path.Combine(Server.MapPath("/Images/UploadProductImages/"), fileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                        image.SaveAs(path);
                    }
                    else
                        image.SaveAs(path);

                    productForm.Thumbnail = "/Images/UploadProductImages/" + fileName;
                }

                if (ModelState.IsValid)
                {
                    this._productsService.Update(productForm.Id, productForm);

                    var existingProduct = this._productsService.Get(productForm.Id);
                    var newForm = new ProductFormViewModel
                    {
                        Id = existingProduct.Id,
                        Thumbnail = existingProduct.Thumbnail,
                        Name = existingProduct.Name,
                        Price = existingProduct.Price,
                        NumberOfProducts = existingProduct.NumberOfProducts,
                        DiscountPrice = existingProduct.DiscountPrice,
                        Description = existingProduct.Description,
                        Condition = existingProduct.Condition,
                        AvailabilityStatusCode = existingProduct.AvailabilityStatusCode,
                        BrandId = existingProduct.BrandId
                    };

                    return View("Details", newForm);
                }
                else
                    return View("Details", productForm);
            }
        }
    }
}