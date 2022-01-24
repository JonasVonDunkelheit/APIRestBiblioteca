using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class LibroForCreationDto
    {
        [Required(ErrorMessage = "El ISBN es requerido")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "El título es requerido")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El formato es requerido")]
        public string Formato { get; set; }
        [Required(ErrorMessage = "El número de páginas es requerido")]
        public int NumPag { get; set; }
        [Required(ErrorMessage = "El id del ejemplar es requerido")]
        public string IdEjemplar { get; set; }
    }
}
