using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table ("Libro")]
    public class Libro
    {
        [Column("IdLibro")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Formato { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public int NumPag { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string IdEjemplar { get; set; }
    }
}
