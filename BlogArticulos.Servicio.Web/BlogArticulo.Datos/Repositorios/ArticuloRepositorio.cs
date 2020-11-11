using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Instrumentation;
using System.Data.Entity;
using BlogArticulo.Datos.Contexto;
using BlogArticulo.Datos.Dominio;

namespace BlogArticulo.Datos.Repositorios
{
    public class ArticuloRepositorio
    {
        private BlogArticuloContexto contexto;

        public ArticuloRepositorio()
        {
            contexto = new BlogArticuloContexto();
        }

        public List<Articulo> ObtenerArticulosActivos()
        {
            try
            {
                return contexto.Articulos
                    .Where(x => x.Activo == 1)
                    .OrderByDescending(x => x.FechaPublicacion)
                    .Include(x => x.TipoArticulo)
                    .Include(x => x.Usuario)
                    .Include(x => x.Comentarios.Select(y => y.Usuario))
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public List<Articulo> ObtenerArticulosParaAdmin()
        {
            try
            {
                return contexto.Articulos
                    .OrderByDescending(x => x.FechaPublicacion)
                    .Include(x => x.TipoArticulo)
                    .Include(x => x.Usuario)
                    .Include(x => x.Comentarios.Select(y => y.Usuario))
                    .ToList();
            }
            catch
            {
                return null;
            }
        }

        public Articulo ObtenerArticuloPorId(int id)
        {
            return ObtenerArticulosActivos().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Articulo> ObtenerArticulosPorTipo(int idTipo)
        {
            return ObtenerArticulosActivos().Where(art => art.TipoArticulo_Id == idTipo).ToList();
        }

        public List<Articulo> ObtenerArticulosPorIdUsuario(int idUsuario)
        {
            return ObtenerArticulosActivos().Where(art => art.Usuario_Id == idUsuario).ToList();
        }

        public void AltaArticulo(Articulo articulo)
        {
            contexto.Articulos.Add(articulo);
            contexto.SaveChanges();
        }

        public void ModificarArticulo(Articulo articulo)
        {
            Articulo _articulo = contexto.Articulos.FirstOrDefault(x => x.Id == articulo.Id);
            _articulo.Titulo = articulo.Titulo;
            _articulo.Cabecera = articulo.Cabecera;
            _articulo.Cuerpo = articulo.Cuerpo;
            _articulo.Imagen = articulo.Imagen;
            _articulo.TipoArticulo_Id = articulo.TipoArticulo_Id;
            _articulo.Usuario_Id= articulo.Usuario_Id;
            contexto.SaveChanges();
        }

        public void EliminarArticulo(Articulo articulo)
        {
            articulo.Activo = 0;
            ModificarArticulo(articulo);
        }
    }
}
