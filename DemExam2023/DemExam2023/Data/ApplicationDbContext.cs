using DemExam2023.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemExam2023.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string connectionString = "Server=DESKTOP-I8L1GP6; Database=ClothStoreDb; TrustServerCertificate=true; Trusted_Connection = true";
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
