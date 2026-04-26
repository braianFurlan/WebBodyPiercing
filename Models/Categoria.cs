using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebBodyPiercing.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        //  Categoria → MUCHAS Piezas
        public List<Pieza> Piezas { get; set; } = new();
    }
}