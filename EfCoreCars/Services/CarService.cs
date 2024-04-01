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

        public Car? GetCar(int id)
        {
            return _context.Cars.AsNoTracking()
                                .Where(c => c.CarIdentifer == id)
                                .FirstOrDefault();
        }

        public List<Car> GetCars()
        {
           return _context.Cars.AsNoTracking().ToList();
        }

        public Car CreateCar(Car car)
        {
            _context.Cars.Add(car);

            _context.SaveChanges();

            return car;
        }

        public Car UpdateCar(Car car)
        {
            var CarToBeChanged = _context.Cars.Where(c => c.CarIdentifer == car.CarIdentifer).FirstOrDefault();

            CarToBeChanged.Name = car.Name;
            CarToBeChanged.ManufacturerId = car.ManufacturerId;
            CarToBeChanged.Consumption = car.Consumption;

            _context.SaveChanges();

            return car;
        }

        public void RemoveCar(int id)
        {
            var Car = _context.Cars.Where(c => c.CarIdentifer == id).FirstOrDefault();

            _context.Cars.Remove(Car);

            _context.SaveChanges();
        }

    }
}
