using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class EditAddressesFormViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required(ErrorMessage = "First Name can't be blank")]
        [Display(Name = "First Name")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Alphabets only")]
        [MinLength(1, ErrorMessage = "First Name should contain at least 1 characters")]
        [MaxLength(50, ErrorMessage = "First Name can be maximum 50 characters long")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name can't be blank")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Alphabets only")]
        [MinLength(1, ErrorMessage = "Last Name should contain at least 1 characters")]
        [MaxLength(50, ErrorMessage = "Last Name can be maximum 50 characters long")]
        public string LastName { get; set; }


        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number does'n empty")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone number only digits")]
        [MaxLength(20, ErrorMessage = "Phone Number can be maximum 20 characters long")]
        public string PhoneNumber { get; set; }


        [Display(Name = "Address")]
        //[RegularExpression(@"^[A-Za-z0-9]+(?:\s[A-Za-z0-9'_-]+)+$", ErrorMessage = "Alphabets only")]
        public string Address { get; set; }


        [Display(Name = "City")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Alphabets only")]
        public string City { get; set; }
    }
}
