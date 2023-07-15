using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;

using Unity;

using LuigiiLuxury.Domain.Interfaces.Services;
using LuigiiLuxury.Domain.ViewModels;

namespace LuigiiLuxury.Api
{
    public class ProductsController : ApiController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        #region GET

        // GET: /Api/Products/GetAll
        [HttpGet]
        [Route("Api/Products/GetAll")]
        public IEnumerable<ProductViewModel> GetAll()
        {
            var products = _productsService.GetAll();

            return products;
        }


        // GET: /Api/Products/GetById
        [HttpGet]
        [Route("Api/Products/GetById")]
        public IHttpActionResult GetById(int productId)
        {
            var product = _productsService.Get(productId);

            if (product == null)
                return NotFound();

            return Ok(product);
        }


        // GET: /Api/Products/GetByAvailibilityStatus
        [HttpGet]
        [Route("Api/Products/GetByAvailibilityStatus")]
        public IHttpActionResult GetByAvailibilityStatus(string availibilityStatusCode, AvailabilityStatusViewModel availabilityStatus)
        {
            var products = _productsService.GetByAvailibilityStatus(availibilityStatusCode);

            if (products == null)
                return NotFound();

            return Ok(products);
        }


        // GET: /Api/Products/GetByBrand
        [HttpGet]
        [Route("Api/Products/GetByBrand")]
        public IHttpActionResult GetByBrand(int brandId, BrandViewModel brand)
        {
            var products = _productsService.GetByBrand(brandId);

            if (products == null)
                return NotFound();

            return Ok(products);
        }

        // GET: /Api/Products/GetBySorted
        [HttpGet]
        [Route("Api/Products/GetBySorted")]
        public IHttpActionResult GetBySorted(string sorted)
        {
            var products = _productsService.GetBySorted(sorted);

            if (products == null)
                return NotFound();

            return Ok(products);
        }
        #endregion


        // POST: /Api/Products/Create
        [HttpPost]
        [Route("Api/Products/Create")]
        public IHttpActionResult Create(ProductFormViewModel productForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                _productsService.Add(productForm);

                return Created(new Uri(Request.RequestUri + "/" + productForm.Id), productForm);
            }
        }


        // PUT: /Api/Products/Update
        [HttpPut]
        [Route("Api/Products/Update")]
        public IHttpActionResult Update(int productId, ProductFormViewModel productForm, HttpPostedFileBase image)
        {
            _productsService.Update(productId, productForm);

            return Ok(productForm);
        }


        // PUT: /Api/Products/SetAvailibilityStatus
        [HttpPut]
        [Route("Api/Products/SetAvailibilityStatus")]
        public void SetAvailibilityStatus(int productId, AvailabilityStatusViewModel availabilityStatus)
        {
            _productsService.SetAvailibilityStatus(productId, availabilityStatus.Code);
        }


        // DELETE: /Api/Products/Delete
        [HttpDelete]
        [Route("Api/Products/Delete")]
        public void Delete(int productId)
        {
            var product = _productsService.Get(productId);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _productsService.Delete(product.Id);
        }
    }
}
