using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Presentacion.Web.BlogArticuloWebService;

namespace Presentacion.Web.Models
{
    public class UsuarioViewModels
    {
        
    }

    public class VerPerfilViewModels
    {
        public Usuario Usuario { get; set; }

        public VerPerfilViewModels()
        {
            Usuario = new Usuario();
            Usuario.Perfil = new Perfil();
        }

        [Required]
        [Display(Name = "Mail")]
        public string TxtMail { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string TxtContrasena { get; set; }
        [Required]
        [Display(Name = "Confirmar Contraseña")]
        public string TxtConfirmaContrasena { get; set; }
    }

    public class ListaUsuariosViewModels
    {
        public List<Usuario> Usuarios { get; set; }
        public List<Perfil> Perfiles { get; set; }
    }
}