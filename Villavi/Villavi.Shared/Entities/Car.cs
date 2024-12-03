using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Placas")]
        public string? Plate { get; set; }   
        public int? Year { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Modelo")]
        public string? Model { get; set; }
        [Required]
        [Range(1900, 2026)]
        public int Years { get; set; }
        public string? Brand { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; } 
        public ICollection<Service>? Services { get; set; } 
    }
}
