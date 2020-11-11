using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using BlogArticulo.Datos.Dominio;
using BlogArticulo.Datos.Repositorios;
using BlogArticulos.WebService.Extenciones;

namespace BlogArticulos.WebService.ServiciosWeb
{
    /// <summary>
    /// Descripción breve de BlogArticulosServicioWeb
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class BlogArticulosServicioWeb : System.Web.Services.WebService
    {
        private ArticuloRepositorio _articuloRepositorio;
        private UsuarioRepositorio _usuarioRepositorio;
        private TipoArticuloRepositorio _tipoArticuloRepositorio;
        private ComentarioRepositorio _comentarioRepositorio;
        private PerfilRepositorio _perfilRepositorio;

        #region Constructor
        public BlogArticulosServicioWeb()
        {
            _articuloRepositorio = new ArticuloRepositorio();
            _usuarioRepositorio = new UsuarioRepositorio();
            _tipoArticuloRepositorio = new TipoArticuloRepositorio();
            _comentarioRepositorio = new ComentarioRepositorio();
            _perfilRepositorio = new PerfilRepositorio();
        }
        #endregion

        #region ARTICULO
        [WebMethod]
        public List<Articulo> ObtenerArticulosActivos()
        {
            return _articuloRepositorio.ObtenerArticulosActivos();
        }

        [WebMethod]
        public Articulo ObtenerArticuloPorId(string idArticulo, ref string mensajeError)
        {
            if (!int.TryParse(idArticulo, out int number))
            {
                mensajeError = "Uno de los datos ingresados no es valido";
                return null;
            }

            var articulo = _articuloRepositorio.ObtenerArticuloPorId(int.Parse(idArticulo));

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

            var articulos = _articuloRepositorio.ObtenerArticulosPorTipo(int.Parse(idTipo));

            if (articulos == null)
            {
                mensajeError = "No hay Articulos de ese tipo para mostrar";
                return null;
            }
            return articulos;
        }

        [WebMethod]
        public List<Articulo> ObtenerArticulosParaAdmin(string filtro = "")
        {
            var articulos = _articuloRepositorio.ObtenerArticulosParaAdmin();
            if (filtro != "")
                articulos = articulos.Where(art => art.Titulo.Contains(filtro) || art.Cabecera.Contains(filtro)).ToList();
            return articulos;
        }

        [WebMethod]
        public List<Articulo> ObtenerArticulosPorIdUsuario(string idUsuario, ref string mensajeError, string filtro = "")
        {
            if (!int.TryParse(idUsuario, out int number))
            {
                mensajeError = "Uno de los datos ingresados no es valido";
                return null;
            }

            var articulos = _articuloRepositorio.ObtenerArticulosPorIdUsuario(int.Parse(idUsuario));
            if (filtro != "")
                articulos = articulos.Where(art => art.Titulo.Contains(filtro) || art.Cabecera.Contains(filtro)).ToList();
            return articulos;
        }

        [WebMethod]
        public void GestionArticulo(TipoGestionWS tipoGestion, Articulo articulo, ref string mensajeError)
        {
            try
            {
                switch (tipoGestion)
                {
                    case TipoGestionWS.ALTA:
                        _articuloRepositorio.AltaArticulo(articulo);
                        break;
                    case TipoGestionWS.MODIFICACION:
                        _articuloRepositorio.ModificarArticulo(articulo);
                        break;
                    case TipoGestionWS.BAJA:
                        _articuloRepositorio.EliminarArticulo(articulo);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
            }
        }

        [WebMethod]
        public void CambiarEstadoArticulo(string idArticulo, string idEstado, ref string mensajeError)
        {
            if (!int.TryParse(idArticulo, out int number) || !int.TryParse(idEstado, out int number2) || (idEstado != "1" && idEstado != "2"))
                mensajeError = "Uno de los datos ingresados no es valido";

            var articulo = _articuloRepositorio.ObtenerArticulosParaAdmin().Where(art => art.Id == int.Parse(idArticulo)).FirstOrDefault();

            if (articulo == null)
            {
                mensajeError = "El Articulo no existe";
                return;
            }

            articulo.Activo = int.Parse(idEstado);
            _articuloRepositorio.ModificarArticulo(articulo);
        }

        #endregion

        #region USUARIO
        [WebMethod]
        public List<Usuario> ObtenerUsuarios(string filtro = "")
        {
            var listaUsuarios = _usuarioRepositorio.ObtenerUsuarios();

            if (filtro != "")
                listaUsuarios = listaUsuarios.Where(usu => usu.NickName.Contains(filtro) || usu.Apellido.Contains(filtro) || usu.Nombre.Contains(filtro)).ToList();
            return listaUsuarios;
        }

        [WebMethod]
        public Usuario ObtenerUsuarioPorId(string idUsuario, ref string mensajeError)
        {
            if (!int.TryParse(idUsuario, out int number))
            {
                mensajeError = "Uno de los datos ingresados no es valido";
                return null;
            }

            var usuario = _usuarioRepositorio.ObtenerUsuarioPorId(int.Parse(idUsuario));

            if (usuario == null)
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

            var usuario = _usuarioRepositorio.ObtenerUsuarioPorNickYContrasena(nick, contrasena);

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

        [WebMethod]
        public void GestionUsuario(TipoGestionWS tipoGestion, Usuario usuario, ref string mensajeError)
        {
            if (usuario == null)
                mensajeError = "No hay usuario para editar";
            try
            {
                switch (tipoGestion)
                {
                    case TipoGestionWS.ALTA:
                        if (_usuarioRepositorio.ObtenerUsuarios().Where(usu => usu.NickName == usuario.NickName).Count() > 0)
                            mensajeError = "Ya existe un usuario con el NickName: " + usuario.NickName;
                        _usuarioRepositorio.AltaUsuario(usuario);
                        break;
                    case TipoGestionWS.MODIFICACION:
                        _usuarioRepositorio.ModificarUsuario(usuario);
                        break;
                    case TipoGestionWS.BAJA:
                        _usuarioRepositorio.EliminarUsuario(usuario);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
            }
        }

        [WebMethod]
        public void EditarPerfil(Usuario usuario, ref string mensajeError)
        {
            if (usuario == null)
                mensajeError = "No hay usuario para editar";
            try
            {
                _usuarioRepositorio.ModificarPerfilUsuario(usuario);
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
            }
        }

        [WebMethod]
        public void ModificarActivoYTipoPefil(Usuario usuario, ref string mensajeError)
        {
            if (usuario == null)
                mensajeError = "No hay usuario para editar";
            try
            {
                _usuarioRepositorio.ModificarActivoYTipoPefil(usuario);
            }
            catch (Exception ex)
            {
                mensajeError = ex.Message;
            }
        }

        #endregion

        #region TIPO_ARTICULO

        [WebMethod]
        public List<TipoArticulo> ObtenerTiposArticulos()
        {
            return _tipoArticuloRepositorio.ObtenerTiposArticulos();
        }

        [WebMethod]
        public TipoArticulo ObtenerTipoArticuloPorId(string idTipoArticulo, ref string mensajeError)
        {
            if (!int.TryParse(idTipoArticulo, out int number))
            {
                mensajeError = "Uno de los datos ingresados no es valido";
                return null;
            }

            var tipoArticulo = _tipoArticuloRepositorio.ObtenerTipoArticuloPorId(int.Parse(idTipoArticulo));

            if (tipoArticulo == null)
            {
                mensajeError = "No se encontró el Id Buscado";
                return null;
            }
            return tipoArticulo;
        }

        #endregion

        #region COMENTARIO

        [WebMethod]
        public void GuardarComentario(string idArticulo, Comentario comentario, ref string mensajeError)
        {
            if (!int.TryParse(idArticulo, out int id) || string.IsNullOrEmpty(comentario.Detalle))
            {
                mensajeError = "Se debe escribir un comentario para guardar";
                return;
            }

            _comentarioRepositorio.AltaComentario(id, comentario);
        }

        #endregion

        #region PERFIL

        [WebMethod]
        public List<Perfil> ObtenerPerfiles()
        {
            return _perfilRepositorio.ObtenerPerfiles();
        }

        #endregion

    }
}
