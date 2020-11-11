using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogArticulo.Datos.Contexto;
using BlogArticulo.Datos.Dominio;

namespace BlogArticulo.Datos.Repositorios
{
    public class PerfilRepositorio
    {
        private BlogArticuloContexto contexto;

        public PerfilRepositorio()
        {
            contexto = new BlogArticuloContexto();
        }

        public List<Perfil> ObtenerPerfiles()
        {
            try
            {
                return contexto.Perfiles
                    .OrderBy(x => x.Nombre)
                    .ToList();
            }
            catch
            {
                return null;
            }
        }
    }

}
