using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table ("Autor")]
    public class Autor
    {
        [Column("IdAutor")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nacionalidad { get; set; }

        [ForeignKey(nameof(Libro))]
        public Guid IdLibro { get; set; }
        public Libro Libro { get; set; }
    }
}
