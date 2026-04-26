using System.ComponentModel.DataAnnotations;

namespace WebBodyPiercing.Models
{
    public class Review
    {

        public int Id { get; set; }
        public int PiezaId { get; set; }
        public Pieza Pieza { get; set; }
        public string UsuarioId { get; set; } // Relación con Usuario
        public Usuario Usuario { get; set; }
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
        public int Rating { get; set; } 
        [Required(ErrorMessage = "El comentario es obligatorio.")]
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }
    }


}

