using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebBodyPiercing.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public string UrlImagenPerfil { get; set; }
        public List<Review>? Reviews { get; set; } = new List<Review>();
            public List<Favorito>? Favoritos { get; set; } = new List<Favorito>();

    }
}
