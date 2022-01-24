using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class EstanteriaForUpdateDto
    {
        [Required(ErrorMessage = "El código es requerido")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "La dimensión de la altura es requerida")]
        public string DimAlto { get; set; }
        [Required(ErrorMessage = "La dimensión del ancho es requerida")]
        public string DimAncho { get; set; }
        [Required(ErrorMessage = "El id del estante es requerido")]
        public string IdEstante { get; set; }
    }
}
