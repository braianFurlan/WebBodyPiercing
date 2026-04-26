using System.ComponentModel.DataAnnotations;

namespace WebBodyPiercing.Models
{
    public class Pieza
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        [Range(0, 999999)]
        public decimal Precio { get; set; }

        [Required]
        [Url]
        public string ImagenUrl { get; set; } = string.Empty;

        public bool Disponible { get; set; } = true;

        // Relación con Categoría
        [Required]
        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        // 🔗 1 Pieza → MUCHAS Reviews
        public List<Review> Reviews { get; set; } = new();
    }
}