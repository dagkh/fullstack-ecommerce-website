using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Services.IServices;

namespace LuigiiLuxury.Domain.Interfaces.Services
{
    public interface IOrderDetailsService : IService<OrderDetailsViewModel>
    {
        void Add(OrderDetailsViewModel orderDetails);
        void Update(int id, OrderDetailsFormViewModel orderDetailsForm);
        OrderDetailsViewModel Details(int id);
        IEnumerable<OrderDetailsViewModel> GetOrderDetailsByOrderId(int orderId);
    }
}
