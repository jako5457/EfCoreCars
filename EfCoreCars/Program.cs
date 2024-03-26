
using Dumpify;
using EfCoreCars;
using EfCoreCars.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

using (CarDbContext context = new CarDbContext())
{
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
    
    if(context.Database.GetPendingMigrations().Count() != 0)
        context.Database.Migrate();

}

//EagerLoading();
//ExpilicitLoading();
SelectLoading();

void EagerLoading()
{
    using (CarDbContext context = new CarDbContext())
    {
        //Car car = context.Cars.FirstOrDefault();

        #region Include

        //Car car = context.Cars
        //                  .Include(c => c.Manufacturer)
        //                  .FirstOrDefault();

        #endregion

        #region Deep Include

        Car car = context.Cars
                            .Include(c => c.Manufacturer)
                            .ThenInclude(m => m.Location)
                            .FirstOrDefault();

        #endregion

        car.Dump();
    }
}

void ExpilicitLoading()
{
    using (CarDbContext context = new CarDbContext())
    {
        
        Manufacturer manufacturer = context.Manufacturer.FirstOrDefault();
        manufacturer.Dump();

        context.Entry(manufacturer)
               .Collection(m => m.Cars)
               .Load();
        manufacturer.Dump();

        context.Entry(manufacturer)
                   .Reference(m => m.Location)
                   .Load();
        manufacturer.Dump();
    }
}

void SelectLoading()
{
    using (CarDbContext context = new CarDbContext())
    {
        var car = context.Cars
                     .Select(c => new {
                         c.Name,
                         Manufacturer = c.Manufacturer.Name,
                         ManufacturerLocation = c.Manufacturer.Location.Name,
                         c.Consumption,
                     })
                     .FirstOrDefault();

        car.Dump();
    }
}