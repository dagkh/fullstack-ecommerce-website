using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class OrderStatusFormViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Order Status Code")]
        public string Code { get; set; }


        [Required]
        [Display(Name = "Order Status Name")]
        public string Name { get; set; }
    }
}
