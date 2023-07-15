using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class AvailabilityStatusFormViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Required]
        [MaxLength(4)]
        public string Code { get; set; }
    }
}
