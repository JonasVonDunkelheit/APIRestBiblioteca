using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RevistaForUpdateDto
    {
        [Required(ErrorMessage = "El número es requerido")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La fecha de publicación es requerida")]
        public DateTime FechaPublicacion { get; set; }
        [Required(ErrorMessage = "El id del ejemplar es requerido")]
        public string IdEjemplar { get; set; }
    }
}
