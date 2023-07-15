using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain;
using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Services;


namespace LuigiiLuxury.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OrderStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = MapperExtension.CreateMapper();
        }

        public void Add(OrderStatusFormViewModel orderStatusForm)
        {
            var entity = _mapper.Map<OrderStatusFormViewModel, OrderStatus>(orderStatusForm);

            _unitOfWork.OrderStatus.Add(entity);
            _unitOfWork.Complete();
        }

        public IEnumerable<OrderStatusViewModel> GetAll()
        {
            var entities = _unitOfWork.OrderStatus.GetAll();

            if (entities != null)
            {
                var orderStatuss = _mapper.Map<IEnumerable<OrderStatus>, IEnumerable<OrderStatusViewModel>>(entities);

                return orderStatuss;
            }
            else
                return null;
        }

        public OrderStatusViewModel Get<T>(T id)
        {
            var entity = _unitOfWork.OrderStatus.Get(id);

            if (entity != null)
            {
                var orderStatus = _mapper.Map<OrderStatus, OrderStatusViewModel>(entity);

                return orderStatus;
            }
            else
                return null;
        }

        private bool IsExsitingInDatabase<T>(T identity)
        {
            var orderStatus = Get(identity);

            if (orderStatus != null)
                return true;
            return false;
        }

        public void Update(string code, OrderStatusFormViewModel orderStatusForm)
        {
            if (IsExsitingInDatabase(code))
            {
                var entity = _unitOfWork.OrderStatus.Get(code);

                _unitOfWork.OrderStatus.Update(entity);
                _unitOfWork.Complete();
            }
        }

        public void Delete<T>(T identity)
        {
            if (IsExsitingInDatabase(identity))
            {
                var entity = _unitOfWork.OrderStatus.Get(identity);

                _unitOfWork.OrderStatus.Delete(entity);
                _unitOfWork.Complete();
            }
        }
    }
}