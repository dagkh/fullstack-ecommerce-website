using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class BrandFormViewModel
    {
        [Required(ErrorMessage = "Brand Id can't be blank.")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Brand Name can't be blank")]
        [Display(Name = "Brand Name")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
