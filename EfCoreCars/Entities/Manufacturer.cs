using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCars.Entities
{
    public class Manufacturer
    {
        private ILazyLoader _LazyLoader;

        private Location _Location;

        public int ManufacturerId { get; set; }

        [StringLength(10)]
        public string Name { get; set;} = string.Empty;

        public List<Car> Cars { get; set; } = default!;

        public Location Location { 
            get => _LazyLoader.Load(this, ref _Location); 
            set => _Location = value; 
        }

    }
}
