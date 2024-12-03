using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Nombre del Proveedor")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Direccion")]
        public string? Address { get; set; }
        public ICollection<Order>? Orders { get; set; } 
    }
}
