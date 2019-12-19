using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Terme.Core.Domain.Categories.Entities;
using Terme.Core.Domain.Customers.Entities;
using Terme.Core.Domain.Masters.Entities;
using Terme.Core.Domain.Orders.Entities;
using Terme.Core.Domain.Photos.Entities;

namespace Terme.Infrastructures.Data.SqlServer
{
    public class TermeDbContext : DbContext
    {
        public TermeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Master> Masters { get; set; }
        public DbSet<MasterProduct> MasterProducts { get; set; }
        public DbSet<MasterProductPhoto> MasterProductPhotos { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public Order Where { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        }

    }
}
