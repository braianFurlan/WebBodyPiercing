namespace WebBodyPiercing.Models
{
    public class Favorito
    {

        public int Id { get; set; }

        //  Relación con Pieza 
        public int PiezaId { get; set; }
        public Pieza Pieza { get; set; }

        //  Relación con Usuario 
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int Rating { get; set; }
        public string Comentario { get; set; }

        public DateTime Fecha { get; set; }
    }
}
