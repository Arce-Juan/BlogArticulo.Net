using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogArticulos.AccesoADatos.Entidades;
using BlogArticulos.AccesoADatos.Modelo;

namespace BlogArticulos.AccesoADatos.Repositorios
{
    public class ArticuloRepositorio
    {
        private BlogNoticiasEntities contexto;

        public ArticuloRepositorio()
        {
            contexto = new BlogNoticiasEntities();
        }

        public List<Articulo> ObtenerArticulos()
        {
            try
            {
                return contexto.Articulo
                    .OrderBy(x => x.idArticulo)
                    .Include(x => x.TipoArticulo)
                    .Include(x => x.Usuario)
                    .Include(x => x.Comentario.Select(y => y.Usuario))
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public Articulo ObtenerArticuloPorId(int id)
        {
            return ObtenerArticulos().Where(x => x.idArticulo == id).FirstOrDefault();
        }

    }
}
