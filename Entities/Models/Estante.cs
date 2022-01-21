using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("Estante")]
    public class Estante
    {
        public Guid IdEstante { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Codigo { get; set; }        

        [ForeignKey(nameof(Libro))]
        public Guid IdLibro { get; set; }
        public Libro Libro { get; set; }

        [ForeignKey(nameof(Revista))]
        public Guid IdRevista { get; set; }
        public Revista Revista { get; set; }
        
    }
}
