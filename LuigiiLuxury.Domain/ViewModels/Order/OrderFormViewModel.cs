using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class OrderFormViewModel
    {
        public int Id { get; set; }


        //[RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "full name")]
        [Required(ErrorMessage = "Enter a full name")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Alphabets only")]
        public string ShipFullName { get; set; }


        [Display(Name = "phone number")]
        [Required(ErrorMessage = "Enter a phone number")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone number only digits")]
        public string ShipPhoneNumber { get; set; }


        [Required(ErrorMessage = "Enter a address")]
        [Display(Name = "address")]
        public string ShipAddress { get; set; }



        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }


        [Display(Name = "Note")]
        public string Note { get; set; }


        [Required(ErrorMessage = "ship region can't be blank.")]
        [Display(Name = "Ship Region")]
        public string ShipRegion { get; set; }


        [Required(ErrorMessage = "ship city can't be blank.")]
        [Display(Name = "Ship City")]
        public string ShipCity { get; set; }


        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual UserViewModel User { get; set; }


        [Required]
        [Display(Name = "Country")]
        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public virtual CountryViewModel Country { get; set; }


        [Display(Name = "Order Status")]
        [ForeignKey("OrderStatus")]
        public string OrderStatusCode { get; set; }
        public virtual OrderStatusViewModel OrderStatus { get; set; }
    }
}
