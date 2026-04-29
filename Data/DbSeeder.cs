using WebBodyPiercing.Models;


namespace WebBodyPiercing.Data
{
    public static class DbSeeder
    {
        public static void Seed(PiercingDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Piezas.Any() || context.Categorias.Any())
                return;

            // 🔥 Categorías
            var categorias = new List<Categoria>
        {
            new Categoria { Nombre = "Aros" },
            new Categoria { Nombre = "Barbell" },
            new Categoria { Nombre = "Septum" }
        };

            context.Categorias.AddRange(categorias);
            context.SaveChanges();

            // 🔥 Piezas
            var piezas = new List<Pieza>
        {
            new Pieza
            {
                Nombre = "Aro acero",
                Descripcion = "Aro clásico",
                Precio = 1500,
                ImagenUrl = "https://aghajewelry.co/cdn/shop/files/18g-Titanium-Nose-Hoop-G-Ring-Bf_2048x.jpg?v=1686680182",
                Disponible = true,
                CategoriaId = categorias[0].Id
            },
            new Pieza
            {
                Nombre = "Barbell titanio",
                Descripcion = "Barra resistente",
                Precio = 2500,
                ImagenUrl = "https://piercingytattoo.com/12731-superlarge_default/barbell-titanio-liso-16mm.jpg",
                Disponible = true,
                CategoriaId = categorias[1].Id
            }
        };

            context.Piezas.AddRange(piezas);
            context.SaveChanges();
        }
    }
}
