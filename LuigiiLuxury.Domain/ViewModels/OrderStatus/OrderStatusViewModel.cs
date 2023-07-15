using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class OrderStatusViewModel
    {
        [Required]
        [Display(Name = "Order Status Code")]
        public string Code { get; set; }


        [Required]
        [Display(Name = "Order Status Name")]
        public string Name { get; set; }
    }
}
