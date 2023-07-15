using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class ProductFormViewModel
    {
        [Required]
        [Display(Name = "ID")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Name cant be blank.")]
        [MaxLength(255)]
        public string Name { get; set; }


        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price cant be blank.")]
        public double Price { get; set; }


        [Display(Name = "Number Of Products")]
        public int? NumberOfProducts { get; set; }


        [Display(Name = "Discount Price")]
        public double? DiscountPrice { get; set; }


        [Display(Name = "Image")]
        public string Thumbnail { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Condition")]
        public string Condition { get; set; }


        [Display(Name = "Availability Status")]
        [Required(ErrorMessage = "availability status cant be blank.")]
        [ForeignKey("AvailabilityStatus")]
        public string AvailabilityStatusCode { get; set; }
        public virtual AvailabilityStatusViewModel AvailabilityStatus { get; set; }


        [Display(Name = "Brand")]
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public virtual BrandViewModel Brand { get; set; }
    }
}
