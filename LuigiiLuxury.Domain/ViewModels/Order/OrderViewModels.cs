using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        [Display(Name = "Order ID")]
        public int Id { get; set; }


        //[RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Enter a full name")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Alphabets only")]
        public string ShipFullName { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Enter a phone number")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone number only digits")]
        public string ShipPhoneNumber { get; set; }


        [Required(ErrorMessage = "Enter a address")]
        [Display(Name = "Address")]
        public string ShipAddress { get; set; }


        [Required(ErrorMessage = "Enter a city")]
        [Display(Name = "City")]
        public string ShipCity { get; set; }



        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }


        [Display(Name = "Note")]
        public string Note { get; set; }


        [Display(Name = "Ship Region")]
        public string ShipRegion { get; set; }


        [ForeignKey("User")]
        [Display(Name = "User ID")]
        public int? UserId { get; set; }
        public virtual UserViewModel User { get; set; }


        [ForeignKey("CountryCode")]
        [Display(Name = "Country")]
        public string CountryCode { get; set; }
        public virtual CountryViewModel Country { get; set; }



        [ForeignKey("OrderStatus")]
        [Display(Name = "Order Status")]
        public string OrderStatusCode { get; set; }
        public virtual OrderStatusViewModel OrderStatus { get; set; }
    }
}
