using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class OrderDetailsFormViewModel
    {

        [Required]
        [Display(Name = "OrderDetails ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Discount")]
        public double Discount { get; set; }

        [ForeignKey("OrderId")]
        public virtual OrderViewModel Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual ProductViewModel Product { get; set; }
    }
}
