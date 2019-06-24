using System;
using Microsoft.EntityFrameworkCore;
using TestProject.Domain.Models;

namespace TestProject.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Customer>().HasKey(p => p.CustomerId);
            builder.Entity<Customer>().Property(p => p.CustomerId).IsRequired();
            builder.Entity<Customer>().Property(p => p.CustomerName).IsRequired().HasMaxLength(30);
            builder.Entity<Customer>().Property(p => p.Email).IsRequired().HasMaxLength(25);
            builder.Entity<Customer>().Property(p => p.Mobile).IsRequired().HasMaxLength(10);

            builder.Entity<Customer>().HasData
            (
                new Customer { CustomerId = 100001, CustomerName = "FirstName1 LastName1", Email = "FirstName1@gmail.com", Mobile = "0843232123" },
                new Customer { CustomerId = 100002, CustomerName = "FirstName2 LastName2", Email = "FirstName2@gmail.com", Mobile = "0431213434" },
                new Customer { CustomerId = 100003, CustomerName = "FirstName3 LastName3", Email = "FirstName3@gmail.com", Mobile = "0123456789" }
            );

            builder.Entity<Transaction>().ToTable("Transaction");
            builder.Entity<Transaction>().HasKey(p => p.TransactionId);
            builder.Entity<Transaction>().Property(p => p.CustomerId).IsRequired();
            builder.Entity<Transaction>().Property(p => p.TransactionId).IsRequired();
            builder.Entity<Transaction>().Property(p => p.TransactionDate).IsRequired();
            builder.Entity<Transaction>().Property(p => p.Amount).IsRequired();
            builder.Entity<Transaction>().Property(p => p.Currency).IsRequired();
            builder.Entity<Transaction>().Property(p => p.Status).IsRequired();

            builder.Entity<Transaction>().HasData
            (
                new Transaction { TransactionId = 1, CustomerId = 100002, TransactionDate = System.DateTime.Now.AddDays(-3), Amount = 500, Currency = "USD", Status = "Success" },
                new Transaction { TransactionId = 2, CustomerId = 100003, TransactionDate = System.DateTime.Now.AddDays(-2), Amount = 1000, Currency = "USD", Status = "Success" },
                new Transaction { TransactionId = 3, CustomerId = 100003, TransactionDate = System.DateTime.Now.AddDays(-1), Amount = 2000, Currency = "USD", Status = "Success" },
                new Transaction { TransactionId = 4, CustomerId = 100003, TransactionDate = System.DateTime.Now, Amount = 3000, Currency = "USD", Status = "Failed" }
            );
        }
    }
}