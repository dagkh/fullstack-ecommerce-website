using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Unity;

using LuigiiLuxury.Domain.Interfaces.Services;
using LuigiiLuxury.Domain.ViewModels;

namespace LuigiiLuxury.Api
{
    public class BrandsController : ApiController
    {
        private readonly IBrandsService _brandsService;

        public BrandsController(IBrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        //  GET: /Api/Brands/GetAll
        [HttpGet]
        [Route("Api/Brands/GetAll")]
        public IEnumerable<BrandViewModel> GetAll()
        {
            var brands = _brandsService.GetAll();

            return brands;
        }


        //  GET: /Api/Brands/GetById
        [HttpGet]
        [Route("Api/Brands/GetById")]
        public IHttpActionResult GetById(int brandId)
        {
            var brand = _brandsService.Get(brandId);

            if (brand == null)
                return NotFound();

            return Ok(brand);
        }


        // POST: /Api/Brands/Create
        [HttpPost]
        [Route("Api/Brands/Create")]
        public IHttpActionResult Create(BrandFormViewModel brandForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                _brandsService.Add(brandForm);

                return Created(new Uri(Request.RequestUri + "/" + brandForm.Id), brandForm);
            }
        }


        // PUT: /Api/Brands/Update
        [HttpPut]
        [Route("Api/Brands/Update")]
        public IHttpActionResult Update(int brandId, BrandFormViewModel brandForm)
        {
            _brandsService.Update(brandId, brandForm);

            return Ok(brandForm);
        }


        // DELETE: /Api/Brands/Delete
        [HttpDelete]
        [Route("Api/Brands/Delete")]
        public void Delete(int brandId)
        {
            var brand = _brandsService.Get(brandId);

            if (brand == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _brandsService.Delete(brandId);
        }
    }
}
