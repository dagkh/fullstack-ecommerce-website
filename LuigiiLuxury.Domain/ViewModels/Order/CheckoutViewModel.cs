using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "full name")]
        public string ShipFullName { get; set; }


        [Display(Name = "email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "phone number")]
        public string ShipPhoneNumber { get; set; }


        [Required]
        [Display(Name = "address")]
        public string ShipAddress { get; set; }


        [Display(Name = "note")]
        public string Note { get; set; }


        [Display(Name = "city")]
        public string ShipCity { get; set; }


        [Display(Name = "region")]
        public string ShipRegion { get; set; }


        public int? UserId { get; set; }


        [Required]
        [Display(Name = "country")]
        public string CountryCode { get; set; }
        [ForeignKey("CountryCode")]
        public virtual CountryViewModel Country { get; set; }


        [ForeignKey("UserId")]
        public virtual UserViewModel User { get; set; }
    }
}
