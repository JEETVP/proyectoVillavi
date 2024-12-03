using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="El campo {0] debe tener maximo {1] caracteres")]
        [Display(Name="Ciudad")]
        public string? Name { get; set; }    
        public Country? Country { get; set; }
    }
}
