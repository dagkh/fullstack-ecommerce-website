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
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductsService _productsService;
        private IMapper _mapper;

        public OrderDetailsService(IUnitOfWork unitOfWork, IProductsService productsService)
        {
            _unitOfWork = unitOfWork;
            _productsService = productsService;
            _mapper = MapperExtension.CreateMapper();
        }

        public OrderDetailsViewModel Get<T>(T identity)
        {
            var entity = _unitOfWork.OrderDetails.Get(identity);
            var orderDetails = _mapper.Map<OrderDetails, OrderDetailsViewModel>(entity);

            return orderDetails;
        }

        public IEnumerable<OrderDetailsViewModel> GetAll()
        {
            var entities = _unitOfWork.OrderDetails.GetAll();

            if (entities != null)
            {
                var listOrderDetails = _mapper.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailsViewModel>>(entities);
                return listOrderDetails;
            }

            return null;
        }

        public void Delete<T>(T identity)
        {
            var orderDetails = Get(identity);

            if (orderDetails != null)
            {
                var entity = _unitOfWork.OrderDetails.Get(identity);
                _unitOfWork.OrderDetails.Delete(entity);
                _unitOfWork.Complete();
            }
        }

        public OrderDetailsViewModel Details(int id)
        {
            var orderDetails = Get(id);

            if (orderDetails != null)
                return orderDetails;
            return null;
        }

        private IEnumerable<OrderDetailsViewModel> GetListOrderDetailsById(IEnumerable<OrderViewModel> orders, out int size, List<int> ListOfId)
        {
            var entities = GetAll();
            var ListOrderDetailsById = new List<OrderDetailsViewModel>();

            size = 0;

            foreach (var order in orders)
            {
                int orderId = order.Id;

                foreach (var item in entities)
                {
                    if (order.Id == item.Id)
                    {
                        ListOrderDetailsById.Add(item);
                    }
                }

                size++;
                ListOfId.Add(orderId);
            }
            return ListOrderDetailsById;
        }

        public void Add(OrderDetailsViewModel orderDetails)
        {
            var entity = _mapper.Map<OrderDetailsViewModel, OrderDetails>(orderDetails);
            var product = _productsService.Get(entity.ProductId);

            if (product != null)
            {
                for (int i = 0; i < orderDetails.Quantity; i++)
                {
                    product.NumberOfProducts--;

                    if (product.NumberOfProducts == 0)
                        _unitOfWork.Products.SetAvailibilityStatus(product.Id, "SOLD");
                }
            }

            _unitOfWork.OrderDetails.Add(entity);
            _unitOfWork.Complete();
        }

        public void Update(int id, OrderDetailsFormViewModel orderDetailsForm)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetailsViewModel> GetOrderDetailsByOrderId(int orderId)
        {
            var listOrderDetails = GetAll().Where(e => e.OrderId == orderId);

            return listOrderDetails;
        }
    }
}
