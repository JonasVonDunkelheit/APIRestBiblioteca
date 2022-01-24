using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class EstanteForUpdateDto
    {
        [Required(ErrorMessage = "El código es requerido")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El id del libro es requerido")]
        public int IdLibro { get; set; }
        [Required(ErrorMessage = "El id de la revista es requerido")]
        public int IdRevista { get; set; }
    }
}
