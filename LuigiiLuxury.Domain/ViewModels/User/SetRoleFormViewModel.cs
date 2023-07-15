using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class SetRoleFormViewModel
    {
        [Required]
        public int UserId { get; set; }
        public RoleFormViewModel Role { get; set; }
    }
}
