using GenericRepositoryPattern.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepositoryPattern.DataContext
{
    public class SampleDataContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Your sqlServer connection string here.....
            optionsBuilder.UseSqlServer("YourConnString");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
