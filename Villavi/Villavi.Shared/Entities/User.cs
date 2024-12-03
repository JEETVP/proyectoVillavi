using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Villavi.Shared.Entities
{
    public class User: IdentityUser
    {
        [Required (ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener {1} maximo caracteres")]
        [Display (Name ="Nombre")]
        public string?FirstName { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener {1} maximo caracteres")]
        [Display(Name = "Apellidos")]
        public string? LastName { get; set; }
        [Display(Name = "Foto")]
        public string?Photo {  get; set; }
        [Display(Name = "Tipo de Usuario")]
        public UserType UserType { get; set; }
        public City? City { get; set; } 
        public int CityId { get; set; }
        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";
    }
}
