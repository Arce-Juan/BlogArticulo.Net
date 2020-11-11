using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Presentacion.Web.Models;
using Presentacion.Web.BlogArticuloWebService;
using Microsoft.Ajax.Utilities;
using System.Web.Services.Protocols;
using Presentacion.Web.Extenciones;

namespace Presentacion.Web.Controllers
{
    public class ArticuloController : Controller
    {
        private BlogArticulosServicioWebSoapClient _blogArticuloServicio;

        private string mensaje;

        #region Constructor
        public ArticuloController()
        {
            _blogArticuloServicio = new BlogArticulosServicioWebSoapClient();
        }
        #endregion

        #region Pagina Principal
        // GET: Articulo
        public ActionResult Index(string idTipoArticulo = "")
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var _model = new IndexViewModels();

            if (idTipoArticulo != "")
            {
                _model.TipoDeArticulo = _blogArticuloServicio.ObtenerTipoArticuloPorId(idTipoArticulo, ref mensaje);
                _model.Articulos = _blogArticuloServicio.ObtenerArticuloPorTipo(idTipoArticulo, ref mensaje).ToList();
            }
            else
            {
                _model.TipoDeArticulo = new TipoArticulo()
                {
                    Id = 0,
                    Nombre = "TODAS"
                };
                _model.Articulos = _blogArticuloServicio.ObtenerArticulosActivos().ToList();
            }
            return View(_model);
        }

        #endregion

        #region Ver un Articulo
        public ActionResult VerArticulo(string idArticulo, string mensajeError = "")
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            mensaje = "";
            var _model = new VerArticuloViewModels()
            {
                Usuario = _blogArticuloServicio.ObtenerUsuarioPorId(Session["Session_Usuario_Id"].ToString(), ref mensaje),
                Articulo = _blogArticuloServicio.ObtenerArticuloPorId(idArticulo, ref mensaje),
                ErrorVerArticulo = mensajeError
            };
            if (mensaje != "")
            {
                _model.Articulo = null;
                _model.ErrorVerArticulo = mensaje;
            }

            return View(_model);
        }

        [HttpPost]
        public ActionResult GuardarComentario(FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var idArticulo = collection["nArticuloComentado"].ToString();
            var detalle = collection["comentario"].ToString();
            if (!string.IsNullOrEmpty(detalle))
            {
                var comentario = new Comentario()
                {
                    Detalle = detalle,
                    FechaHora = DateTime.Now,
                    Usuario_Id = int.Parse(Session["Session_Usuario_Id"].ToString()),
                };
                _blogArticuloServicio.GuardarComentario(idArticulo, comentario, ref mensaje);
                return RedirectToAction("VerArticulo", "Articulo", new { idArticulo = idArticulo });
            }
            else
                return RedirectToAction("VerArticulo", "Articulo", new { idArticulo = idArticulo, mensajeError = "Error. se debe completar el campo para comentar." });
        }

        #endregion

        #region Lista Articulos Para ABM
        public ActionResult ListaArticulos(string filtroBuscar = "")
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var _model = new ListaArticulosViewModels()
            {
                Usuario = _blogArticuloServicio.ObtenerUsuarioPorId(Session["Session_Usuario_Id"].ToString(), ref mensaje)
            };

            if (_model.Usuario.Perfil.Nombre == "Administrador")
                _model.Articulos = _blogArticuloServicio.ObtenerArticulosParaAdmin(filtroBuscar).ToList();
            else
                _model.Articulos = _blogArticuloServicio.ObtenerArticulosPorIdUsuario(_model.Usuario.Id.ToString(), ref mensaje, filtroBuscar).ToList();

            return View(_model);
        }

        [HttpPost]
        public ActionResult BuscarArticulosPorFiltro(FormCollection collection)
        {
            var filtro = collection["searchText"].ToString();
            return RedirectToAction("ListaArticulos", "Articulo", new { filtroBuscar = filtro });
        }

        [HttpPost]
        public ActionResult RestablecerArticulo(FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var idArticulo = collection["nHiddenRestablecer"];
            var idEstado = "1";
            _blogArticuloServicio.CambiarEstadoArticulo(idArticulo, idEstado, ref mensaje);
            return RedirectToAction("ListaArticulos", "Articulo");
        }

        [HttpPost]
        public ActionResult EliminarArticulo(FormCollection collection)
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var idArticulo = collection["nHiddenEliminar"];
            var idEstado = "0";
            _blogArticuloServicio.CambiarEstadoArticulo(idArticulo, idEstado, ref mensaje);
            return RedirectToAction("ListaArticulos", "Articulo");
        }

        #endregion

        #region Gestion Articulo - Alta Modificacion
        public ActionResult GestionarArticulo(string tipoGestion, string idArticulo = "")  // tipoGestion Solo puede tomar "alta", "modi"
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            var _model = new GestionarArticuloViewModels()
            {
                TipoGestion = tipoGestion == TipoDeGestion.ALTA.ToString() ? TipoDeGestion.ALTA : tipoGestion == "MODIFICACION" ? TipoDeGestion.MODIFICACION : (TipoDeGestion?)null,
                TiposDeArticulo = _blogArticuloServicio.ObtenerTiposArticulos().ToList()
            };

            switch (_model.TipoGestion)
            {
                case TipoDeGestion.ALTA:
                    _model.Articulo = new Articulo();
                    break;
                
                case TipoDeGestion.MODIFICACION:
                    if (!int.TryParse(idArticulo, out int number))
                        RedirectToAction("Login", "Home");

                    _model.Articulo = _blogArticuloServicio.ObtenerArticuloPorId(idArticulo, ref mensaje);
                    _model.TxtTitulo = _model.Articulo.Titulo;
                    _model.TxtCabecera = _model.Articulo.Cabecera;
                    _model.TxtCuerpo = _model.Articulo.Cuerpo;
                    break;

                default:
                    RedirectToAction("Login", "Home");
                    break;
            }
            return View(_model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GestionarArticulo(GestionarArticuloViewModels model, FormCollection collection) 
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            if (!ModelState.IsValid)
                return View(model);

            var imagen = collection["nHiddenImagen"].ToString() == "" && collection["nImagen"].ToString() == "" ? "none.jpg" : collection["nImagen"].ToString() == "" ? collection["nHiddenImagen"].ToString() : collection["nImagen"].ToString();
            
            model.Articulo = new Articulo()
            {
                Id = int.Parse(collection["nHiddenIdArticulo"].ToString()),
                Titulo = model.TxtTitulo,
                Cabecera = model.TxtCabecera,
                Cuerpo = model.TxtCuerpo,
                Imagen = imagen,
                Activo = 1,
                FechaPublicacion = DateTime.Now,
                TipoArticulo_Id = int.Parse(collection["nTipoArticulo"].ToString()),
                Usuario_Id = int.Parse(Session["Session_Usuario_Id"].ToString())
            };

            if (collection["nHiddenTipoGestion"] == TipoDeGestion.ALTA.ToString())
                _blogArticuloServicio.GestionArticulo(TipoGestionWS.ALTA, model.Articulo, ref mensaje);
            
            if (collection["nHiddenTipoGestion"] == TipoDeGestion.MODIFICACION.ToString())
                _blogArticuloServicio.GestionArticulo(TipoGestionWS.MODIFICACION, model.Articulo, ref mensaje);

            return RedirectToAction("ListaArticulos", "Articulo");
        }

        #endregion


    }
}