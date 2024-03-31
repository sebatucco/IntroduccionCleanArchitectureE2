using IntroduccionCleanArchitectureE2.NorthWindEntities.POCOentites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindRepositoriesEFCore.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id).HasMaxLength(5).IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name).IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .Property(c => c.Name).IsRequired().HasMaxLength(40);

            modelBuilder.Entity<Order>()
                .Property(c => c.Id).IsRequired().HasMaxLength(5).IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress).IsRequired().HasMaxLength(60);

            modelBuilder.Entity<Order>()
                .Property(s => s.ShipCity).HasMaxLength(15);

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCountry).HasMaxLength(15);

            modelBuilder.Entity<Order>()
              .Property(o => o.ShipPostalCode).HasMaxLength(10);

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            // relaciones

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderDetail>()
              .HasOne<Product>()
              .WithMany()
              .HasForeignKey(o => o.ProductId);

            // prueba

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = 1, Name = "Chai"},
                new Product { Id = 2, Name = "Chang" },
                new Product { Id = 3, Name = "Aniseed Syrup" }
                );

            modelBuilder.Entity<Customer>()
               .HasData(
               new Customer { Id = "ALFKI", Name = "Alfreds F." },
               new Customer { Id = "ANATR", Name = "Ana Trujillo" },
               new Customer { Id = "ANTON", Name = "Antonio Moreno" }
               );


            base.OnModelCreating(modelBuilder);
        }
    }
}
