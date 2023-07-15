using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class SetOrderStatusFormViewModel
    {
        [Required]
        public int OrderId { get; set; }
        public OrderStatusViewModel OrderStatus { get; set; }
    }
}
