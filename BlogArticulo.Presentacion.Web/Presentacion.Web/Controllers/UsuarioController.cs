using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentacion.Web.BlogArticuloWebService;
using Presentacion.Web.Models;

namespace Presentacion.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private BlogArticulosServicioWebSoapClient _blogArticuloServicio;
        private string mensaje;

        public UsuarioController()
        {
            _blogArticuloServicio = new BlogArticulosServicioWebSoapClient();
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VerPerfil()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var _model = new VerPerfilViewModels();
            _model.Usuario = _blogArticuloServicio.ObtenerUsuarioPorId(Session["Session_Usuario_Id"].ToString(), ref mensaje);
            _model.TxtMail = _model.Usuario.Mail;
            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult VerPerfil(VerPerfilViewModels model, FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            model.Usuario = _blogArticuloServicio.ObtenerUsuarioPorId(collection["nIdHiddenIdUsuario"].ToString(), ref mensaje);

            if (!ModelState.IsValid)
                return View(model);

            var imagen = collection["nHiddenImagen"].ToString() == "" && collection["nImagen"].ToString() == "" ? "default.png" : collection["nImagen"].ToString() == "" ? collection["nHiddenImagen"].ToString() : collection["nImagen"].ToString();

            var usuario = new Usuario()
            {
                Id = int.Parse(collection["nIdHiddenIdUsuario"].ToString()),
                Mail = collection["TxtMail"].ToString(),
                Contrasena = collection["TxtContrasena"].ToString(),
                Imagen = imagen
            };

            _blogArticuloServicio.EditarPerfil(usuario, ref mensaje);

            return RedirectToAction("Index", "Articulo");
        }

        public ActionResult ListaUsuarios(string filtroBuscar = "")
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var _model = new ListaUsuariosViewModels()
            {
                Usuarios = _blogArticuloServicio.ObtenerUsuarios(filtroBuscar).ToList(),
                Perfiles = _blogArticuloServicio.ObtenerPerfiles().ToList()
            };

            return View(_model);
        }

        [HttpPost]
        public ActionResult BuscarUsuariosPorFiltro(FormCollection collection)
        {
            var filtro = collection["searchText"].ToString();
            return RedirectToAction("ListaUsuarios", "Usuario", new { filtroBuscar = filtro });
        }

        [HttpPost]
        public ActionResult ModificarActivoYTipoPefil(FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var usuario = new Usuario()
            {
                Id = int.Parse(collection["nHiddenIdUsuario"].ToString()),
                Activo = int.Parse(collection["nSelectActivo"].ToString()),
                Perfil_Id = int.Parse(collection["nSelectPerfil"].ToString())
            };
            _blogArticuloServicio.ModificarActivoYTipoPefil(usuario, ref mensaje);

            return RedirectToAction("ListaUsuarios", "Usuario");
        }
    }
}