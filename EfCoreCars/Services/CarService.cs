using EfCoreCars.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCars.Services
{
    public class CarService(CarDbContext _context) : ICarService
    {

        //private readonly CarDbContext _Context;

        //public CarService(CarDbContext context)
        //{
        //    _Context = context;
        //}

        public async Task<Car?> GetCarAsync(int id)
        {
            return await _context.Cars.AsNoTracking()
                                .Where(c => c.CarIdentifer == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<List<Car>> GetCarsAsync()
        {
           return await _context.Cars.AsNoTracking().ToListAsync();
        }

        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);

            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            var CarToBeChanged = _context.Cars.Where(c => c.CarIdentifer == car.CarIdentifer).FirstOrDefault();

            CarToBeChanged.Name = car.Name;
            CarToBeChanged.ManufacturerId = car.ManufacturerId;
            CarToBeChanged.Consumption = car.Consumption;

            await _context.SaveChangesAsync();

            return car;
        }

        public async Task RemoveCarAsync(int id)
        {
            var Car = _context.Cars.Where(c => c.CarIdentifer == id).FirstOrDefault();

            _context.Cars.Remove(Car);

            await _context.SaveChangesAsync();
        }

    }
}
