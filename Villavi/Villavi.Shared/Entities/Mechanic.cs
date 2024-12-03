using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class Mechanic
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Nombre")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Apellido")]
        public string? LastName { get; set; }
        public ICollection<Service>? Services { get; set; } 
        public ICollection<Order>? Orders { get; set; }
    }
}
