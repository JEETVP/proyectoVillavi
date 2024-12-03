using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class Client
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
        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Por favor, ingrese un número de teléfono válido.")]
        public string? Telephone { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Correo Electronico")]
        public string? Email { get; set; }
        public ICollection<Car>? Cars { get; set; } 
    }
}
