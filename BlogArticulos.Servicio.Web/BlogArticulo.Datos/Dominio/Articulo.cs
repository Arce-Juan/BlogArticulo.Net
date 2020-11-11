using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogArticulo.Datos.Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Cabecera { get; set; }
        [Required]
        public string Cuerpo { get; set; }
        public string Imagen { get; set; }
        [Required]
        public int Activo { get; set; }
        [Required]
        public DateTime FechaPublicacion { get; set; }
        [Required]
        public int TipoArticulo_Id { get; set; }
        [Required]
        public int Usuario_Id { get; set; }
        [ForeignKey("TipoArticulo_Id")]
        public TipoArticulo TipoArticulo { get; set; }

        [ForeignKey("Usuario_Id")]
        public Usuario Usuario { get; set; }

        public List<Comentario> Comentarios { get; set; }
    }
}
