using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }


        [Display(Name = "Name")]
        public string Name { get; set; }


        [Display(Name = "Number Of Products")]
        public int? NumberOfProducts { get; set; }


        [Display(Name = "Price")]
        public double Price { get; set; }


        [Display(Name = "Discount Price")]
        public double? DiscountPrice { get; set; }


        [Display(Name = "Thumbnail")]
        public string Thumbnail { get; set; }


        [Display(Name = "Description")]
        public string Description { get; set; }


        [Display(Name = "Condition")]
        public string Condition { get; set; }


        [Display(Name = "Is Deleted")]
        public bool? IsDeleted { get; set; }


        [Display(Name = "Availability Status")]
        [ForeignKey("AvailabilityStatus")]
        public string AvailabilityStatusCode { get; set; }
        public virtual AvailabilityStatusViewModel AvailabilityStatus { get; set; }


        [ForeignKey("Brand")]
        [Display(Name = "Brand")]
        public int? BrandId { get; set; }
        public virtual BrandViewModel Brand { get; set; }
    }
}
