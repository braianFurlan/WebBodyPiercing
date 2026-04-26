using System;
using System.ComponentModel.DataAnnotations;

namespace WebBodyPiercing.Models
{
    public class Consulta
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCliente { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Mensaje { get; set; } = string.Empty;

        public DateTime Fecha { get; set; } = DateTime.Now;

        //  Relación opcional con Pieza
        public int? PiezaId { get; set; }
        public Pieza? Pieza { get; set; }
    }
}