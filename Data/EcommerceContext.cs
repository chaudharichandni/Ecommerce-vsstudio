using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;

namespace Ecommerce.Data
{
    public class EcommerceContext : DbContext
    {
       

        public EcommerceContext (DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }
        public DbSet<Ecommerce.Models.Brand> Brand { get; set; } = default!;
        public DbSet<Ecommerce.Models.Category> Category { get; set; } = default!;

        public DbSet<Ecommerce.Models.Cart>? Cart { get; set; }

        public DbSet<Ecommerce.Models.OrderDetail>? OrderDetail { get; set; }

        public DbSet<Ecommerce.Models.Product>? Product { get; set; }

        public DbSet<Ecommerce.Models.User>? User { get; set; }

        public DbSet<Ecommerce.Models.OrderMaster>? OrderMaster { get; set; }
    }
}
