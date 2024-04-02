using CarTest.TestTools;
using Dumpify;
using EfCoreCars;
using EfCoreCars.Entities;
using EfCoreCars.Services;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace CarTest
{
    public class UnitTest1
    {

        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async Task TestCarCount()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = DbcontextCreator.Create();

            int ExpectedCarCount = 1;
            ICarService service = new CarService(context);

            // Act
            var Cars = await service.GetCarsAsync();
            output.WriteLine(Cars.DumpText());

            // Assert
            Assert.Equal(ExpectedCarCount,Cars.Count);
        }

        [Fact]
        public async Task TestFindCar()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = new CarDbContext();

            int ExpectedCarId = 1;
            ICarService service = new CarService(context);

            // Act
            var car = await service.GetCarAsync(ExpectedCarId);
            output.WriteLine(car.DumpText());

            // Assert
            Assert.Equal(ExpectedCarId, car.CarIdentifer);
        }

        [Fact]
        public async Task TestCreateCar()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = DbcontextCreator.Create();

            Car CarToCreate = new Car() { Name = "Corolla", Consumption = 1, ManufacturerId = 1 };
            ICarService service = new CarService(context);

            await Task.Delay(500);

            // Act
            var CreatedCar = await service.CreateCarAsync(CarToCreate);
            output.WriteLine(CreatedCar.DumpText());

            Assert.NotEqual(default,CreatedCar.CarIdentifer);
            Assert.Equal(CarToCreate.Name, CreatedCar.Name);
            Assert.Equal(CarToCreate.Consumption , CreatedCar.Consumption);
            Assert.Equal(CarToCreate.ManufacturerId, CreatedCar.ManufacturerId);
        }

        [Fact]
        public async Task TestUpdateCar()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = DbcontextCreator.Create();

            Car CarToUpdate = new Car() { CarIdentifer = 1 , Name = "Corolla", Consumption = 1, ManufacturerId = 1 };
            ICarService service = new CarService(context);

            // Act
            await service.UpdateCarAsync(CarToUpdate);

            Car? UpdatedCar = context.Cars.AsNoTracking().Where(c => c.CarIdentifer == 1).FirstOrDefault();
            output.WriteLine(UpdatedCar.DumpText());

            // Assert
            Assert.NotNull(UpdatedCar);
            Assert.NotEqual(default, UpdatedCar.CarIdentifer);
            Assert.Equal(CarToUpdate.Name, UpdatedCar.Name);
            Assert.Equal(CarToUpdate.Consumption, UpdatedCar.Consumption);
            Assert.Equal(CarToUpdate.ManufacturerId, UpdatedCar.ManufacturerId);
        }

        [Fact]
        public async void TestDeleteCar()
        {
            // Arrange
            DbcontextCreator.RecreateDatabase();
            CarDbContext context = DbcontextCreator.Create();

            ICarService service = new CarService(context);

            await Task.Delay(500);

            // Act
            await service.RemoveCarAsync(1);

            // Assert
            Assert.False(context.Cars.Any());

        }
    }
}