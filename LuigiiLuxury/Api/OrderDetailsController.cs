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
    public class OrderDetailsController : ApiController
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        // GET: /Api/OrderDetails/GetAll
        [HttpGet]
        [Route("Api/OrderDetails/GetAll")]
        public IEnumerable<OrderDetailsViewModel> GetAll()
        {
            var listOrderDetails = _orderDetailsService.GetAll();

            return listOrderDetails;
        }


        // GET: /Api/OrderDetails/GetAll
        [HttpGet]
        [Route("Api/OrderDetails/GetByOrderId")]
        public IEnumerable<OrderDetailsViewModel> GetByOrderId(int orderId)
        {
            var listOrderDetails = _orderDetailsService.GetOrderDetailsByOrderId(orderId);

            return listOrderDetails;
        }


        // GET: /Api/OrderDetails/GetById
        [HttpGet]
        [Route("Api/OrderDetails/GetById")]
        public IHttpActionResult GetById(int orderDetailsId)
        {
            var orderDetails = _orderDetailsService.Get(orderDetailsId);

            if (orderDetails == null)
                return NotFound();

            return Ok(orderDetails);
        }


        // PUT: /Api/OrderDetails/Update
        [HttpPut]
        [Route("Api/OrderDetails/Update")]
        public IHttpActionResult Update(int orderDetailsId, OrderDetailsFormViewModel orderDetailsForm)
        {
            _orderDetailsService.Update(orderDetailsId, orderDetailsForm);

            return Ok(orderDetailsForm);
        }


        // DELETE: /Api/OrderDetails/Delete
        [HttpDelete]
        [Route("Api/OrderDetails/Delete")]
        public void Delete(int orderDetailsId)
        {
            var orderDetails = _orderDetailsService.Get(orderDetailsId);

            if (orderDetails == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _orderDetailsService.Delete(orderDetailsId);
        }
    }
}
