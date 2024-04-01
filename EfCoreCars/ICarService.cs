using EfCoreCars.Entities;

namespace EfCoreCars
{
    public interface ICarService
    {
        Car GetCar(int id);
    }
}