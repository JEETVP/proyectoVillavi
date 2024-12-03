using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0] debe tener maximo {1] caracteres")]
        [Display(Name = "Empresa")]
        public string? Name { get; set; }
        public City? City { get; set; }
    }
}
