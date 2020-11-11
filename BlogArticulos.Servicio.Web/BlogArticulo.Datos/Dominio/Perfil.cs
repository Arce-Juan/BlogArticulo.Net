using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogArticulo.Datos.Dominio
{
    public class Perfil
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public List<Permiso> ListaPermisos { get; set; }
    }
}
