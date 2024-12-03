using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class Service : DetailService
    {
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Nombre")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Tipo de servicio")]
        public string? ServiceType { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Observaciones")]
        public string? Observations { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; } 
        public int MechanicId { get; set; }
        public Mechanic? Mechanic { get; set; } 
        public ICollection<DetailService>? DetailServices { get; set; }
    }
}
