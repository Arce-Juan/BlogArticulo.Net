using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogArticulo.Datos.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Contrasena { get; set; }
        public string Imagen { get; set; }
        [Required]
        public int Activo { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public int Perfil_Id { get; set; }
        //public List<Articulo> ListaArticulos { get; set; }
        //public List<Comentario> ListaComentarios { get; set; }
        [ForeignKey("Perfil_Id")]
        public Perfil Perfil { get; set; }
    }
}
