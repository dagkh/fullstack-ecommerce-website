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
    public class OrderStatusController : ApiController
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        // GET: /Api/OrderStatus/GetAll
        [HttpGet]
        [Route("Api/OrderStatus/GetAll")]
        public IEnumerable<OrderStatusViewModel> GetAll()
        {
            var orderStatus = _orderStatusService.GetAll();

            return orderStatus;
        }


        // GET: /Api/OrderStatus/GetById
        [HttpGet]
        [Route("Api/OrderStatus/GetById")]
        public IHttpActionResult GetById(int orderStatusId)
        {
            var orderStatus = _orderStatusService.Get(orderStatusId);

            if (orderStatus == null)
                return NotFound();

            return Ok(orderStatus);
        }


        // POST: /Api/OrderStatus/Create
        [HttpPost]
        [Route("Api/OrderStatus/Create")]
        public IHttpActionResult Create(OrderStatusFormViewModel orderStatusForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                _orderStatusService.Add(orderStatusForm);

                return Created(new Uri(Request.RequestUri + "/" + orderStatusForm.Id), orderStatusForm);
            }
        }


        // PUT: /Api/OrderStatus/Update
        [HttpPut]
        [Route("Api/OrderStatus/Update")]
        public IHttpActionResult Update(string code, OrderStatusFormViewModel orderStatusForm)
        {
            _orderStatusService.Update(code, orderStatusForm);

            return Ok(orderStatusForm);
        }


        // DELETE: /Api/OrderStatus/Delete
        [HttpDelete]
        [Route("Api/OrderStatus/Delete")]
        public void Delete(int orderStatusId)
        {
            var orderStatus = _orderStatusService.Get(orderStatusId);

            if (orderStatus == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _orderStatusService.Delete(orderStatus.Code);
        }
    }
}
