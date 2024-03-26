using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCars.Entities
{
    public class Car
    {
        private ILazyLoader _LazyLoader;

        private Manufacturer _Manufacturer;

        [Key]
        public int CarIdentifer { get; set; } // Primary

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public double Consumption { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer 
        {
            get => _LazyLoader.Load(this,ref _Manufacturer); 
            set => _Manufacturer = value; 
        }

    }
}
