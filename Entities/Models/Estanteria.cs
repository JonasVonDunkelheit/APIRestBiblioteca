using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table ("Estanteria")]
    public class Estanteria
    {
        [Column("IdEstanteria")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string DimAlto { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string DimAncho { get; set; }

        [ForeignKey(nameof(Estante))]
        public Guid IdEstante { get; set; }
        public Estanteria Estante { get; set; }
    }
}
