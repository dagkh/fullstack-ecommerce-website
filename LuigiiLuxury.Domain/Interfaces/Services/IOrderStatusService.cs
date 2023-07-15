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
    public interface IOrderStatusService : IService<OrderStatusViewModel>
    {
        void Add(OrderStatusFormViewModel orderStatusForm);
        void Update(string code, OrderStatusFormViewModel orderStatusForm);
    }
}
