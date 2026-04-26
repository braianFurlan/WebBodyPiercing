using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebBodyPiercing.Models;

namespace WebBodyPiercing.Data
{
    public class PiercingDbContext : IdentityDbContext<Usuario>
    {
        public PiercingDbContext(DbContextOptions<PiercingDbContext> options) : base(options)
        {
        }
        public DbSet<Pieza> Piezas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }



    }
}
