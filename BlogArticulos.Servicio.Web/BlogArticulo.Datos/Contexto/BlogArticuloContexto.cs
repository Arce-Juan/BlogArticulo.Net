using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogArticulo.Datos.Dominio;

namespace BlogArticulo.Datos.Contexto
{
    public class BlogArticuloContexto : DbContext
    {
        public BlogArticuloContexto()
            :base("BlogArticulosConnection")
        {

        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<TipoArticulo> TiposArticulos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
