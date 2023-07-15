using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class RoleFormViewModel
    {
        [Required(ErrorMessage = "Role Id cant be blank.")]
        public string Code { get; set; }


        [Required(ErrorMessage = "Role Name cant be blank.")]
        public string Name { get; set; }
    }
}
