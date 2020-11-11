using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Presentacion.Web.BlogArticuloWebService;
using Presentacion.Web.Extenciones;

namespace Presentacion.Web.Models
{
    public class ArticuloViewModels
    {

    }

    public class IndexViewModels
    {
        public TipoArticulo TipoDeArticulo { get; set; }
        public List<Articulo> Articulos { get; set; }
        public string ErrorIndex { get; set; }
    }

    public class VerArticuloViewModels
    {
        public Usuario Usuario { get; set; }
        public Articulo Articulo { get; set; }
        public string ErrorVerArticulo { get; set; }
    }

    public class ListaArticulosViewModels
    {
        public Usuario Usuario { get; set; }
        public List<Articulo> Articulos { get; set; }
    }

    public class GestionarArticuloViewModels
    {
        public TipoDeGestion? TipoGestion { get; set; }
        public Articulo Articulo { get; set; }
        public List<TipoArticulo> TiposDeArticulo { get; set; }
        public GestionarArticuloViewModels()
        {
            Articulo = new Articulo();
            TiposDeArticulo = new List<TipoArticulo>();
        }

        [Required]
        [Display(Name = "Titulo")]
        public string TxtTitulo { get; set; }
        [Required]
        [Display(Name = "Cabecera")]
        public string TxtCabecera { get; set; }
        [Required]
        [Display(Name = "Cuerpo")]
        public string TxtCuerpo { get; set; }
    }
}