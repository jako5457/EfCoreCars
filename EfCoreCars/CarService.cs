using EfCoreCars.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCars
{
    public class CarService(CarDbContext _context) : ICarService
    {

        //private readonly CarDbContext _Context;

        //public CarService(CarDbContext context)
        //{
        //    _Context = context;
        //}

        public Car GetCar(int id)
        {
            return _context.Cars.Where(c => c.CarIdentifer == id).FirstOrDefault();
        }


    }
}
