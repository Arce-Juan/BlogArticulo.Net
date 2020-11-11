using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogArticulo.Datos.Contexto;
using BlogArticulo.Datos.Dominio;

namespace BlogArticulo.Datos.Repositorios
{
    public class TipoArticuloRepositorio
    {
        private BlogArticuloContexto contexto;

        public TipoArticuloRepositorio()
        {
            contexto = new BlogArticuloContexto();
        }

        public List<TipoArticulo> ObtenerTiposArticulos()
        {
            try
            {
                return contexto.TiposArticulos
                    .OrderBy(x => x.Nombre)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public TipoArticulo ObtenerTipoArticuloPorId(int id)
        {
            return ObtenerTiposArticulos().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
