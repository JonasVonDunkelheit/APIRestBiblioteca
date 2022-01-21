using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Revista")]
    public class Revista
    {        
        public Guid IdRevista { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public DateTime FechaPublicacion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string IdEjemplar { get; set; }
    }
}
