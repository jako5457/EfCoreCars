using EfCoreCars.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCars
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DbSet<Manufacturer> Manufacturer { get; set; }

        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }
        public CarDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=CarDB;User Id=SA;Password=P@ssw0rd;TrustServerCertificate=True");
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLoggerFactory(new ServiceCollection()
                              .AddLogging(builder => builder.AddConsole()
                                                            .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                               .BuildServiceProvider().GetService<ILoggerFactory>());
                
            }
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(new Car() { Name = "Datsum", CarIdentifer = 1, Consumption = 200, ManufacturerId = 1 });

            modelBuilder.Entity<Manufacturer>().HasData(new Manufacturer() { ManufacturerId = 1, Name = "W"});

            modelBuilder.Entity<Location>().HasData(new Location() { LocationId = 1, Name = "Tyskland", ManufacturerId = 1 });

            modelBuilder.Entity<Car>()
                            .HasOne(c => c.Manufacturer)
                            .WithMany(m => m.Cars)
                            .HasForeignKey(c => c.ManufacturerId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
