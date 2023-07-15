using System.ComponentModel.DataAnnotations;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class AvailabilityStatusViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Required]
        [MaxLength(4)]
        public string Code { get; set; }
    }
}
