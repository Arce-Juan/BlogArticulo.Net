using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using BlogArticulos.WebService.Validadores;
using BlogArticulo.Datos.Repositorios;
using BlogArticulo.Datos.Dominio;
//using BlogArticulos.WebService.Models;

namespace BlogArticulos.WebService.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de ArticuloServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ArticuloServicioWeb : System.Web.Services.WebService
    {
        private ArticuloRepositorio _repositorio;

        #region Constructor
        public ArticuloServicioWeb()
        {
            _repositorio = new ArticuloRepositorio();
        }

        [WebMethod]
        public List<Articulo> ObtenerArticulos()
        {
            return _repositorio.ObtenerArticulos();
        }
        
        [WebMethod]
        public Articulo ObtenerArticuloPorId(string idArticulo, ref string mensajeError)
        {
            if (!int.TryParse(idArticulo, out int number))
            {
                mensajeError = "Uno de los datos ingresados no es valido";
                return null;
            }

            var articulo = _repositorio.ObtenerArticuloPorId(int.Parse(idArticulo));

            if (articulo == null)
            {
                mensajeError = "No se encontró el Id Buscado";
                return null;
            }
            return articulo;
        }

        [WebMethod]
        public List<Articulo> ObtenerArticuloPorTipo(string idTipo, ref string mensajeError)
        {
            if (!int.TryParse(idTipo, out int number))
            {
                mensajeError = "Uno de los datos ingresados no es valido";
                return null;
            }

            var articulos = _repositorio.ObtenerArticulosPorTipo(int.Parse(idTipo));

            if (articulos == null)
            {
                mensajeError = "No hay Articulos de ese tipo para mostrar";
                return null;
            }
            return articulos;
        }


    }
}
