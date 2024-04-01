
using Dumpify;
using EfCoreCars;
using EfCoreCars.Entities;
using EfCoreCars.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

using (CarDbContext context = new CarDbContext())
{
    //context.Database.EnsureDeleted();
    //context.Database.EnsureCreated();
    
    if(context.Database.GetPendingMigrations().Count() != 0)
        context.Database.Migrate();

}

Car Car = null!;

using (CarDbContext context = new CarDbContext())
{
    ICarService carService = new CarService(context);

    Car car = carService.GetCar(1);

    car.Dump();
}








