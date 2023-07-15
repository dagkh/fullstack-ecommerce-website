using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [MaxLength(255)]
        public string Email { get; set; }


        [Required]
        [MaxLength(255)]
        public string ShipFullName { get; set; }


        [Required]
        [MaxLength(255)]
        public string ShipPhoneNumber { get; set; }


        [Required]
        [MaxLength(255)]
        public string ShipAddress { get; set; }


        [Required]
        [MaxLength(255)]
        public string ShipCity { get; set; }


        [Required]
        [MaxLength(255)]
        public string ShipRegion { get; set; }


        public string Note { get; set; }


        public DateTime? OrderDate { get; set; }


        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }


        [Required]
        [MaxLength(2)]
        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public virtual Country Country { get; set; }


        [Required]
        [ForeignKey("OrderStatus")]
        [MaxLength(100)]
        public string OrderStatusCode { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
