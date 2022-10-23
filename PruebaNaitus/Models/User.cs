using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prueba_Naitus.Models
{
    public class User
    {
        [Key]
        [Required, StringLength(20)]
        public string Rut { get; set; } = string.Empty;
        [Required, StringLength(20)]
        public string Nombre { get; set; } = string.Empty;
        [Required, StringLength(20)]
        public string Apellido { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
