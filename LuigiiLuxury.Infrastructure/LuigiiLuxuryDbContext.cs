using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LuigiiLuxury.Domain.Entities;

namespace LuigiiLuxury.Infrastructure
{
    public class LuigiiLuxuryDbContext : DbContext
    {
        public LuigiiLuxuryDbContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<AvailabilityStatus> AvailabilityStatus { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
