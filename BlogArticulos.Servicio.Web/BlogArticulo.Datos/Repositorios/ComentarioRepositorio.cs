using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogArticulo.Datos.Contexto;
using BlogArticulo.Datos.Dominio;

namespace BlogArticulo.Datos.Repositorios
{
    public class ComentarioRepositorio
    {
        private BlogArticuloContexto contexto;
        private ArticuloRepositorio _articuloRepositorio;

        public ComentarioRepositorio()
        {
            contexto = new BlogArticuloContexto();
            _articuloRepositorio = new ArticuloRepositorio();
        }

        public void AltaComentario(int idArticulo, Comentario comentario)
        {
            var articulo = _articuloRepositorio.ObtenerArticuloPorId(idArticulo);
            articulo.Comentarios.Add(comentario);
            _articuloRepositorio.ModificarArticulo(articulo);
            //contexto.SaveChanges();
        }
    }
}
