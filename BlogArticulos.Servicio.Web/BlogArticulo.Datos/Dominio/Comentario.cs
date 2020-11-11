using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogArticulo.Datos.Dominio
{
    public class Comentario
    {
        public int Id { get; set; }
        [Required]
        public string Detalle { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
        [Required]
        public int Usuario_Id { get; set; }
        [ForeignKey("Usuario_Id")]
        public Usuario Usuario { get; set; }
        
    }
}
