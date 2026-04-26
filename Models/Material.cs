using System.ComponentModel.DataAnnotations;

namespace WebBodyPiercing.Models
{
    public class Material
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Url]
        public string LogoUrl { get; set; }
        public List<Pieza> Piezas { get; set; } = new List<Pieza>();

    }
}
