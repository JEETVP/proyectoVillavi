using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Nombre de Orden")]
        public string? OrderName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Piezas")]
        public string? Pieces { get; set; }
        [Required]
        [Range(0, 100000)]
        public int Cost { get; set; }

        public int MechanicId { get; set; }
        public Mechanic? Mechanic { get; set; } 
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; } 
    }
}
