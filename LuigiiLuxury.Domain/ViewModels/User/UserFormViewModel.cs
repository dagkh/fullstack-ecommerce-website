using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class UserFormViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [MaxLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Address")]
        public string Address { get; set; }


        [MaxLength(255)]
        [Display(Name = "City")]
        public string City { get; set; }


        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
