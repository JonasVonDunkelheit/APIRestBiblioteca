using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AutorForCreationDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Los apellidos son requeridos")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "La nacionalidad es requerida")]
        public string Nacionalidad { get; set; }
        [Required(ErrorMessage = "El id del libro es requerido")]
        public int IdLibro { get; set; }
    }
}
