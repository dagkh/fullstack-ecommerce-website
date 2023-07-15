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
    public interface IOrdersService : IService<OrderViewModel>
    {
        int Add(OrderFormViewModel orderStatusForm);
        void Update(int id, OrderFormViewModel orderForm);
        IEnumerable<OrderViewModel> GetOrdersByUserId(int userId);
        void SetOrderStatus(SetOrderStatusFormViewModel orderStatusForm);
    }
}
