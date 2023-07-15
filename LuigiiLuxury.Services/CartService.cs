using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LuigiiLuxury.Domain.ViewModels;
using LuigiiLuxury.Domain;
using LuigiiLuxury.Domain.Entities;
using LuigiiLuxury.Domain.Interfaces;
using LuigiiLuxury.Domain.Interfaces.Services;

namespace LuigiiLuxury.Services
{
    public class CartService : ICartService
    {
        public List<ItemViewModel> Items { get; set; }
        public double CartTotal { get; set; }

        private readonly IProductsService _productsService;
        private readonly IOrderDetailsService _ordersDetailsService;

        public CartService(IProductsService productsService, IOrderDetailsService orderDetailsService)
        {
            _productsService = productsService;
            _ordersDetailsService = orderDetailsService;
            CartTotal = 0;
            Items = new List<ItemViewModel>();
        }

        private ItemViewModel CreateItem(int productId)
        {
            var item = new ItemViewModel
            {
                Product = _productsService.Get(productId),
                Quantity = 1,
                TotalPrice = _productsService.Get(productId).Price
            };

            return item;
        }

        private bool IsExistingInCart(ItemViewModel item)
        {
            var existingProduct = Items.SingleOrDefault(i => i.Product.Id == item.Product.Id);

            if (existingProduct != null)
                return true;
            return false;
        }

        //  - Nếu sản phẩm đã tồn tại trong giỏ hàng thì kiểm tra:
        //      + Nếu sản phẩm có số lượng là 1 thì không làm gì cả.
        //      + Nếu sản phẩm có số lượng từ 2 trở lên thì cộng thêm 1 cho item.
        //  - Nếu sản phầm chưa tồn tại trong giỏ hàng:
        //      + Thêm mới sản phẩm vào giỏ hàng
        public void Add(int productId)
        {
            var product = _productsService.Get(productId);

            if (product != null)
            {
                var newItem = CreateItem(product.Id);

                if (!IsExistingInCart(newItem)) // nếu item chưa tồn tại trong Cart thì thêm vào.
                {
                    Items.Add(newItem);

                    // tính tổng tiền cho cart
                    if (product.NumberOfProducts > 1)
                        CartTotal += newItem.Product.Price;
                    else if (product.NumberOfProducts == 1)
                        CartTotal += newItem.TotalPrice;
                }
                else 
                {
                    if (product.NumberOfProducts > 1) // nếu số lượng sản phầm nhiều hơn 1 thì cộng dồn số lượng lên và tính lại tiền.
                    {
                        var exstingItem = Items.SingleOrDefault(i => i.Product.Id == productId);

                        if (!(exstingItem.Quantity == product.NumberOfProducts))
                        {
                            exstingItem.Quantity += 1;
                            exstingItem.TotalPrice = product.Price * exstingItem.Quantity;

                            // tính tổng tiền cho cart
                            if (product.NumberOfProducts > 1)
                                CartTotal += exstingItem.Product.Price;
                            else if (product.NumberOfProducts == 1)
                                CartTotal += exstingItem.TotalPrice;
                        }
                    }
                }
            }
        }

        public void Remove(int productId)
        {
            var product = _productsService.Get(productId);

            if (product != null)
            {
                var item = Items.SingleOrDefault(i => i.Product.Id == productId);

                if (item != null)
                {
                    if (item.Quantity == 1)
                    {
                        CartTotal -= item.TotalPrice;
                        item.TotalPrice -= product.Price;

                        Items.Remove(item);
                    }
                    else if (item.Quantity > 1)
                    {
                        item.Quantity -= 1;
                        item.TotalPrice -= product.Price;
                        CartTotal -= item.Product.Price;
                    }
                }
            }
        }

        private OrderDetailsViewModel CreateOrderDetails(ItemViewModel item, int orderId)
        {
            var orderDetails = new OrderDetailsViewModel()
            {
                UnitPrice = item.Quantity * item.Product.Price,
                Quantity = item.Quantity,
                Discount = 0,
                OrderId = orderId,
                ProductId = item.Product.Id
            };

            return orderDetails;
        }

        public void SaveOrderDetails(List<ItemViewModel> items, int orderId)
        {
            foreach (var item in items)
            {
                var orderDetails = CreateOrderDetails(item, orderId);
                _ordersDetailsService.Add(orderDetails);
            }
        }
    }
}
