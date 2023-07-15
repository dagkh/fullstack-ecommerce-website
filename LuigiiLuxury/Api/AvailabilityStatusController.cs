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
    public class AvailabilityStatusController : ApiController
    {
        private readonly IAvailabilityStatusService _availabilityStatus;

        public AvailabilityStatusController(IAvailabilityStatusService availabilityStatus)
        {
            _availabilityStatus = availabilityStatus;
        }

        //  GET: /Api/AvailabilityStatus/GetAll
        [HttpGet]
        [Route("Api/AvailabilityStatus/GetAll")]
        public IEnumerable<AvailabilityStatusViewModel> GetAll()
        {
            var viewModels = _availabilityStatus.GetAll();

            return viewModels;
        }


        //  GET: /Api/AvailabilityStatus/GetByCode
        [HttpGet]
        [Route("Api/AvailabilityStatus/GetByCode")]
        public IHttpActionResult GetByCode(string code)
        {
            var viewModel = _availabilityStatus.Get(code);

            if (viewModel == null)
                return NotFound();

            return Ok(viewModel);
        }


        // POST: /Api/AvailabilityStatus/Create
        [HttpPost]
        [Route("Api/AvailabilityStatus/Create")]
        public IHttpActionResult Create(AvailabilityStatusFormViewModel availabilityStatusForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                _availabilityStatus.Add(availabilityStatusForm);

                return Created(new Uri(Request.RequestUri + "/" + availabilityStatusForm.Code), availabilityStatusForm);
            }
        }


        // PUT: /Api/AvailabilityStatus/Update
        [HttpPut]
        [Route("Api/AvailabilityStatus/Update")]
        public IHttpActionResult Update(string code, AvailabilityStatusFormViewModel availabilityStatusForm)
        {
            _availabilityStatus.Update(code, availabilityStatusForm);

            return Ok(availabilityStatusForm);
        }


        // DELETE: /Api/AvailabilityStatus/Delete
        [HttpDelete]
        [Route("Api/AvailabilityStatus/Delete")]
        public void Delete(string code)
        {
            var viewModel = _availabilityStatus.Get(code);

            if (viewModel == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _availabilityStatus.Delete(viewModel.Code);
        }
    }
}
