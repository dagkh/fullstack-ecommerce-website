using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.ViewModels
{
    public class UserViewModel
    {
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


        [ForeignKey("Role")]
        public string RoleCode { get; set; }
        public virtual RoleViewModel Role { get; set; }
    }
}
