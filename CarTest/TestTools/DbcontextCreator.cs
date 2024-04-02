using EfCoreCars;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarTest.TestTools
{
    public class DbcontextCreator
    {
        public static CarDbContext Create([CallerMemberName] string Name = "")
        {
            DbContextOptionsBuilder<CarDbContext> builder = new DbContextOptionsBuilder<CarDbContext>();

            //builder.UseSqlServer("Server=localhost;Database=CarDB;User Id=SA;Password=P@ssw0rd;TrustServerCertificate=True");

            builder.UseInMemoryDatabase(Name);

            return new CarDbContext(builder.Options);
        }

        public static void RecreateDatabase([CallerMemberName] string Name = "")
        {
            using (var context = Create(Name))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
