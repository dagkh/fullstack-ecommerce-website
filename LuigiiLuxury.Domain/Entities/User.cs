using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }


        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }


        public string Address { get; set; }


        [MaxLength(255)]
        public string City { get; set; }


        public DateTime CreatedAt { get; set; }


        public DateTime? UpdatedAt { get; set; }


        public bool IsDeleted { get; set; }


        [Required]
        [ForeignKey("Role")]
        [MaxLength(20)]
        public string RoleCode { get; set; }
        public virtual Role Role { get; set; }
    }
}
