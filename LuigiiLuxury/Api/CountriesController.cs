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
    public class CountriesController : ApiController
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        // GET: /Api/Countries/GetAll
        [HttpGet]
        [Route("Api/Countries/GetAll")]
        public IEnumerable<CountryViewModel> GetAll()
        {
            var countries = _countriesService.GetAll();

            return countries;
        }


        // GET: /Api/Countries/GetById
        [HttpGet]
        [Route("Api/Countries/GetById")]
        public IHttpActionResult GetById(int countryId)
        {
            var country = _countriesService.Get(countryId);

            if (country == null)
                return NotFound();

            return Ok(country);
        }


        // POST: /Api/Countries/Create
        [HttpPost]
        [Route("Api/Countries/Create")]
        public IHttpActionResult Create(CountryFormViewModel countryForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                _countriesService.Add(countryForm);

                return Created(new Uri(Request.RequestUri + "/" + countryForm.Code), countryForm);
            }
        }


        // PUT: /Api/Countries/Update
        [HttpPut]
        [Route("Api/Countries/Update")]
        public IHttpActionResult Update(int countryId, CountryFormViewModel countryForm)
        {
            _countriesService.Update(countryId, countryForm);

            return Ok(countryForm);
        }


        // DELETE: /Api/Countries/Delete
        [HttpDelete]
        [Route("Api/Countries/Delete")]
        public void Delete(int countryId)
        {
            var country = _countriesService.Get(countryId);

            if (country == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _countriesService.Delete(country.Code);
        }
    }
}
