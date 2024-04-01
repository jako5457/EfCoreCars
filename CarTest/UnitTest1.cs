using CarTest.TestTools;
using Dumpify;
using EfCoreCars;
using EfCoreCars.Entities;
using EfCoreCars.Services;
using Microsoft.EntityFrameworkCore;

namespace CarTest
{
    public class UnitTest1
    {

        [Fact]
        public void TestCarCount()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = DbcontextCreator.Create();

            int ExpectedCarCount = 1;
            ICarService service = new CarService(context);

            // Act
            int CarCount = service.GetCars().Count();

            // Assert
            Assert.Equal(ExpectedCarCount,CarCount);
        }

        [Fact]
        public void TestFindCar()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = new CarDbContext();

            int ExpectedCarId = 1;
            ICarService service = new CarService(context);

            // Act
            var car = service.GetCar(ExpectedCarId);

            // Assert
            Assert.Equal(ExpectedCarId, car.CarIdentifer);
        }

        [Fact]
        public void TestCreateCar()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = DbcontextCreator.Create();

            Car CarToCreate = new Car() { Name = "Corolla", Consumption = 1, ManufacturerId = 1 };
            ICarService service = new CarService(context);

            // Act
            var CreatedCar = service.CreateCar(CarToCreate);

            Assert.NotEqual(default,CreatedCar.CarIdentifer);
            Assert.Equal(CarToCreate.Name, CreatedCar.Name);
            Assert.Equal(CarToCreate.Consumption , CreatedCar.Consumption);
            Assert.Equal(CarToCreate.ManufacturerId, CreatedCar.ManufacturerId);
        }

        [Fact]
        public void TestUpdateCar()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = DbcontextCreator.Create();

            Car CarToUpdate = new Car() { CarIdentifer = 1 , Name = "Corolla", Consumption = 1, ManufacturerId = 1 };
            ICarService service = new CarService(context);

            // Act
            service.UpdateCar(CarToUpdate);

            Car? UpdatedCar = context.Cars.AsNoTracking().Where(c => c.CarIdentifer == 1).FirstOrDefault();

            // Assert
            Assert.NotNull(UpdatedCar);
            Assert.NotEqual(default, UpdatedCar.CarIdentifer);
            Assert.Equal(CarToUpdate.Name, UpdatedCar.Name);
            Assert.Equal(CarToUpdate.Consumption, UpdatedCar.Consumption);
            Assert.Equal(CarToUpdate.ManufacturerId, UpdatedCar.ManufacturerId);
        }

        [Fact]
        public void TestDeleteCar()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = DbcontextCreator.Create();

            ICarService service = new CarService(context);

            // Act
            service.RemoveCar(1);

            // Assert
            Assert.False(context.Cars.Any());

        }
    }
}