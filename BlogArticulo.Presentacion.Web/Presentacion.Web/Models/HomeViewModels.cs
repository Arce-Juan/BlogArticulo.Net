using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Presentacion.Web.Models
{
    public class HomeViewModels
    {

    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nick")]
        public string Nick { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        
        [Display(Name = "ErrorLogin")]
        public string ErrorLogin { get; set; }

        public LoginViewModel()
        {
            ErrorLogin = "";
        }
    }

    public class RegisterViewModel
    {
        public string MensajeError { get; set; }
        [Required]
        [Display(Name = "Nick")]
        public string Nick { get; set; }
        [Required]
        [Display(Name = "Mail")]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        
        [Required]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
        [Required]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmarContrasena { get; set; }
    }
}