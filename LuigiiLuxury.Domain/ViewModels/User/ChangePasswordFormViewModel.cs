using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class ChangePasswordFormViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter current password")]
        [Display(Name = "Enter current password")]
        public string CurrentPassword { get; set; }


        [Required(ErrorMessage = "password can't be blank")]
        [Display(Name = "New password")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm password can't be blank")]
        [Compare("Password")]
        [Display(Name = "Confirm new password")]
        public string ConfirmPassword { get; set; }
    }
}
