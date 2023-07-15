using System.Collections.Generic;
using LuigiiLuxury.Services;
using LuigiiLuxury.Domain.ViewModels;

namespace LuigiiLuxury.Domain.Interfaces.Services
{
    public interface ICartService
    {
        List<ItemViewModel> Items { get; set; }
        double CartTotal { get; set; }
        void Add(int productId);
        void Remove(int productId);
        void SaveOrderDetails(List<ItemViewModel> items, int orderId);
    }
}
