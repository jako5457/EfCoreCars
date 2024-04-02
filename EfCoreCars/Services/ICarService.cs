using EfCoreCars.Entities;

namespace EfCoreCars.Services
{
    public interface ICarService
    {
        Task<Car?> GetCarAsync(int id);

        Task<List<Car>> GetCarsAsync();

        Task<Car> CreateCarAsync(Car car);

        Task<Car> UpdateCarAsync(Car car);

        Task RemoveCarAsync(int id);
    }
}