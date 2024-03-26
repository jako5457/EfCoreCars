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
        [Key]
        public int CarIdentifer { get; set; } // Primary

        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public double Consumption { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; } = default!;

    }
}
