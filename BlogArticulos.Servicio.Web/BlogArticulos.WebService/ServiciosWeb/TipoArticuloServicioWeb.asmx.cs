using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BlogArticulo.Datos.Dominio;
using BlogArticulo.Datos.Repositorios;

namespace BlogArticulos.WebService.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de TipoArticuloServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TipoArticuloServicioWeb : System.Web.Services.WebService
    {
        private TipoArticuloRepositorio _repositorio;

        public TipoArticuloServicioWeb()
        {
            _repositorio = new TipoArticuloRepositorio();
        }

        [WebMethod]
        public List<TipoArticulo> ObtenerTiposArticulos()
        {
            return _repositorio.ObtenerTiposArticulos();
        }

        [WebMethod]
        public TipoArticulo ObtenerTipoArticuloPorId(string idTipoArticulo, ref string mensajeError)
        {
            if (!int.TryParse(idTipoArticulo, out int number))
            {
                mensajeError = "Uno de los datos ingresados no es valido";
                return null;
            }

            var tipoArticulo = _repositorio.ObtenerTipoArticuloPorId(int.Parse(idTipoArticulo));

            if (tipoArticulo == null)
            {
                mensajeError = "No se encontró el Id Buscado";
                return null;
            }
            return tipoArticulo;
        }
    }
}
