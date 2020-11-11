using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentacion.Web.Models;
using Presentacion.Web.BlogArticuloWebService;

namespace Presentacion.Web.Controllers
{
    public class HomeController : Controller
    {
        private BlogArticulosServicioWebSoapClient _blogArticuloServicio;
        private string mensaje;
        public HomeController()
        {
            _blogArticuloServicio = new BlogArticulosServicioWebSoapClient();
        }

        public ActionResult Login(string esInvitado = "NO")
        {
            if (esInvitado == "SI")
            {
                Session["Session_Usuario_Id"] = "2";
                return RedirectToAction("Index", "Articulo");
            }
            else
                Session["Session_Usuario_Id"] = null;

            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl, string esInvitado)
        {
            if (!ModelState.IsValid)
                return View(model);

            string mensaje = "";
            var usuario = _blogArticuloServicio.ObtenerUsuarioPorNickYPass(model.Nick, model.Password, ref mensaje);

            if (!string.IsNullOrEmpty(mensaje))
            {
                model.ErrorLogin = mensaje;
                return View(model);
            }
            Session["Session_Usuario_Id"] = usuario.Id;
            return RedirectToAction("Index", "Articulo");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register(string mensajeError = "")
        {
            var _model = new RegisterViewModel()
            {
                MensajeError = mensajeError
            };
            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model, FormCollection collection)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Contrasena != model.ConfirmarContrasena)
            {
                model.MensajeError = "Las contraseñas no coinciden";
                return View(model);
            }

            var usuario = new Usuario()
            {
                NickName = model.Nick,
                Contrasena = model.Contrasena,
                Imagen = "default.png",
                Activo = 1,
                Apellido = model.Apellidos,
                Nombre = model.Nombres,
                Mail = model.Mail,
                Perfil_Id = 7
            };
            
            _blogArticuloServicio.GestionUsuario(TipoGestionWS.ALTA, usuario, ref mensaje);

            if (mensaje != "")
            {
                model.MensajeError = mensaje;
                return View(model);
            }
            return RedirectToAction("Login", "Home");
        }

    }
}