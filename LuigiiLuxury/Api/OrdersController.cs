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
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService orderService)
        {
            _ordersService = orderService;
        }

        // GET: /Api/Orders/GetAll
        [HttpGet]
        [Route("Api/Orders/GetAll")]
        public IEnumerable<OrderViewModel> GetAll()
        {
            var orders = _ordersService.GetAll();

            return orders;
        }


        // GET: /Api/Orders/GetOrdersByUserId
        [HttpGet]
        [Route("Api/Orders/GetOrdersByUserId")]
        public IEnumerable<OrderViewModel> GetOrdersByUserId(int userId)
        {
            var orders = _ordersService.GetOrdersByUserId(userId);

            return orders;
        }


        // GET: /Api/Orders/GetById
        [HttpGet]
        [Route("Api/Orders/GetById")]
        public IHttpActionResult GetById(int orderId)
        {
            var order = _ordersService.Get(orderId);

            if (order == null)
                return NotFound();

            return Ok(order);
        }


        // POST: /Api/Orders/Create
        [HttpPost]
        [Route("Api/Orders/Create")]
        public IHttpActionResult Create(OrderFormViewModel orderForm)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            else
            {
                _ordersService.Add(orderForm);

                return Created(new Uri(Request.RequestUri + "/" + orderForm.Id), orderForm);
            }
        }


        // PUT: /Api/Orders/Update
        [HttpPut]
        [Route("Api/Orders/Update")]
        public IHttpActionResult Update(int orderId, OrderFormViewModel orderForm)
        {
            _ordersService.Update(orderId, orderForm);

            return Ok(orderForm);
        }


        // PUT: /Api/Orders/SetOrderStatus
        [HttpPut]
        [Route("Api/Orders/SetOrderStatus")]
        public IHttpActionResult SetOrderStatus(SetOrderStatusFormViewModel orderStatusForm)
        {
            _ordersService.SetOrderStatus(orderStatusForm);

            return Ok(orderStatusForm);
        }


        // DELETE: /Api/Orders/Delete
        [HttpDelete]
        [Route("Api/Orders/Delete")]
        public void Delete(int orderId)
        {
            var order = _ordersService.Get(orderId);

            if (order == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _ordersService.Delete(orderId);
        }
    }
}
