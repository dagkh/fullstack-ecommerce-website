using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class SetStatusViewModel
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int OrderStatusId { get; set; }

        [ForeignKey("OrderStatusId")]
        public virtual OrderStatusViewModel OrderStatus { get; set; }
    }
}
