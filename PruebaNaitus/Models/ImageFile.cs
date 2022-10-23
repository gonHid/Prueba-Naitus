
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_Naitus.Models
{
    [Keyless]
    public class ImageFile
    {
        [ForeignKey("User"),Required]
        public string Rut { get; set; }

        [Required]
        public string FileName { get; set; }
    }
}
