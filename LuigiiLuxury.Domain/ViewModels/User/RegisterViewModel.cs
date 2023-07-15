using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name can't be blank")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Alphabets only")]
        //[MinLength(1, ErrorMessage = "First Name should contain at least 1 characters")]
        //[MaxLength(50, ErrorMessage = "First Name can be maximum 50 characters long")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name can't be blank")]
        //[RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Alphabets only")]
        //[MinLength(1, ErrorMessage = "Last Name should contain at least 1 characters")]
        //[MaxLength(50, ErrorMessage = "Last Name can be maximum 50 characters long")]
        public string LastName { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email can't be blank")]
        //[RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        //[MaxLength(100, ErrorMessage = "Email can be maximum 100 characters long")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password can't be blank")]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match.")]
        //[Required(ErrorMessage = "Confirm Password can't be blank")]
        public string ConfirmPassword { get; set; }
    }
}
