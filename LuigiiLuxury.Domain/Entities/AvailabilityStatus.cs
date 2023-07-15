using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.Entities
{
    public class AvailabilityStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [MaxLength(4)]
        public string Code { get; set; }


        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
