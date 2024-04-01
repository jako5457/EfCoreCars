using EfCoreCars;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarTest.TestTools
{
    public class DbcontextCreator
    {
        public static CarDbContext Create()
        {
            DbContextOptionsBuilder<CarDbContext> builder = new DbContextOptionsBuilder<CarDbContext>();

            builder.UseSqlServer("Server=localhost;Database=CarDB;User Id=SA;Password=P@ssw0rd;TrustServerCertificate=True");

            return new CarDbContext(builder.Options);
        }

        public static void RecreateDatabase()
        {
            using (var context = Create())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
