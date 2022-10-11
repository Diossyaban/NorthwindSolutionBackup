using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Northwind.Domain.Entities;
using System;


namespace Northwind.Persistence
{
    public class ShopeeDbContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        public ShopeeDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
