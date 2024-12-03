using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class DetailService
    {
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "El campo {0} deber tener maximo {1} caracter")]
        [Display(Name = "Detalle de Servicio")]
        public string? SubServiceName { get; set; }
        [Range(0, 100000)]
        public int? Cost { get; set; }
        public int ServiceId { get; set; }
        public required Service Service { get; set; }
    }
}
