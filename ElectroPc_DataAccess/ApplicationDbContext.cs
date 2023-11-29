using ElectroPc_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroPc_DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Product 1",
                    Brand = "Brand 1",
                    Processor = "Processor 1",
                    RamSizeGB = 8,
                    StorageType = "SSD",
                    StorageCapacityGB = 256,
                    DisplaySizeInches = 15.6,
                    DisplayResolution = "1920x1080",
                    GraphicsCard = "Graphics Card 1",
                    OperatingSystem = "Windows 10",
                    BatteryLifeHours = 6.5,
                    WeightKg = 1.8,
                    Dimensions = "15 x 10 x 1 inches",
                    ImageUrl= "https://picsum.photos/200/300"
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Product 10",
                    Brand = "Brand 10",
                    Processor = "Processor 10",
                    RamSizeGB = 16,
                    StorageType = "HDD",
                    StorageCapacityGB = 512,
                    DisplaySizeInches = 14,
                    DisplayResolution = "1366x768",
                    GraphicsCard = "Graphics Card 10",
                    OperatingSystem = "Windows 10",
                    BatteryLifeHours = 8,
                    WeightKg = 2,
                    Dimensions = "13 x 9 x 1 inches",
                    ImageUrl = "https://picsum.photos/200/300"
                }
            );
        }
    }
}
