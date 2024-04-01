using EfCoreCars.Entities;

namespace EfCoreCars.Services
{
    public interface ICarService
    {
        Car? GetCar(int id);

        List<Car> GetCars();

        Car CreateCar(Car car);

        Car UpdateCar(Car car);

        void RemoveCar(int id);
    }
}