using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuigiiLuxury.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        public int? NumberOfProducts { get; set; }


        [Required]
        public double Price { get; set; }


        public double? DiscountPrice { get; set; }


        public string Thumbnail { get; set; }


        public string Description { get; set; }


        public string Condition { get; set; }


        public bool? IsDeleted { get; set; }


        [MaxLength(4)]
        [ForeignKey("AvailabilityStatus")]
        public string AvailabilityStatusCode { get; set; }
        public virtual AvailabilityStatus AvailabilityStatus { get; set; }


        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
