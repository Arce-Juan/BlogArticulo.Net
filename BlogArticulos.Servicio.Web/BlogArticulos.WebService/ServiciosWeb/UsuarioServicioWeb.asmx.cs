using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BlogArticulo.Datos.Dominio;
using BlogArticulo.Datos.Repositorios;
using BlogArticulos.WebService.Validadores;

namespace BlogArticulos.WebService.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de UsuarioServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class UsuarioServicioWeb : System.Web.Services.WebService
    {
        private UsuarioRepositorio _repositorio;

        public UsuarioServicioWeb()
        {
            _repositorio = new UsuarioRepositorio();
        }

        [WebMethod]
        public List<Usuario> ObtenerUsuarios()
        {
            return _repositorio.ObtenerUsuarios();
        }
        
        [WebMethod]
        public Usuario ObtenerUsuarioPorId(string idUsuario, ref string mensajeError)
        {
            if (!int.TryParse(idUsuario, out int number))
            {
                mensajeError = "Uno de los datos ingresados no es valido";
                return null;
            }
            
            var usuario = _repositorio.ObtenerUsuarioPorId(int.Parse(idUsuario));

            if (usuario ==  null)
            {
                mensajeError = "El ID ingresado no existe";
                return null;
            }

            return usuario;
        }

        [WebMethod]
        public Usuario ObtenerUsuarioPorNickYPass(string nick, string contrasena, ref string mensajeError)
        {
            if (string.IsNullOrEmpty(nick) || string.IsNullOrEmpty(contrasena))
            {
                mensajeError = "El Nick o la Contraseña no es fueron ingresados";
                return null;
            }

            var usuario = _repositorio.ObtenerUsuarioPorNickYContrasena(nick, contrasena);
            
            if (usuario == null)
            {
                mensajeError = "El Usuario no existe o Contraseña Incorrecta";
                return null;
            }

            if (usuario.Activo == 0)
            {
                mensajeError = "El Usuario se encuentra Inactivo";
                return null;
            }

            return usuario;
        }

    }
}
