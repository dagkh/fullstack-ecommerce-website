using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain;
using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = MapperExtension.CreateMapper();
        }

        public int Add(OrderFormViewModel orderForm)
        {
            var entity = _mapper.Map<OrderFormViewModel, Order>(orderForm);
            entity.OrderDate = DateTime.Now;
            entity.OrderStatusCode = "processing";

            _unitOfWork.Orders.Save(entity);

            return entity.Id;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            var orders = _unitOfWork.Orders.GetAll();
            var ordersViewModel = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(orders);

            return ordersViewModel;
        }

        public OrderViewModel Get<T>(T id)
        {
            var entity = _unitOfWork.Orders.Get(id);
            var order = _mapper.Map<Order, OrderViewModel>(entity);

            return order;
        }

        public IEnumerable<OrderViewModel> GetAllByUserId(int userId)
        {
            var orders = GetAll().Where(o => o.UserId == userId);

            return orders;
        }

        public void Delete<T>(T identity)
        {
            var order = Get(identity);

            if (order != null)
            {
                var entity = _unitOfWork.Orders.Get(identity);

                _unitOfWork.Orders.Delete(entity);
                _unitOfWork.Complete();
            }
        }

        public void Update(int id, OrderFormViewModel orderForm)
        {
            var order = Get(id);

            if (order != null)
            {
                var entity = _mapper.Map<OrderFormViewModel, Order>(orderForm);

                _unitOfWork.Orders.Update(id, entity);
                _unitOfWork.Complete();
            }
        }

        public IEnumerable<OrderViewModel> GetOrdersByUserId(int userId)
        {
            var entities = _unitOfWork.Orders.GetAll().Where(e => e.UserId == userId);
            var orders = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(entities);

            return orders;
        }

        public void SetOrderStatus(SetOrderStatusFormViewModel setOrderStatusForm)
        {
            var order = Get(setOrderStatusForm.OrderId);

            if (order != null)
            {
                var entity = _unitOfWork.Orders.Get(order.Id);
                entity.OrderStatusCode = setOrderStatusForm.OrderStatus.Code;

                _unitOfWork.Complete();
            }
        }
    }
}
