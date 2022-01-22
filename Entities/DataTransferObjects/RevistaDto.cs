using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RevistaDto
    {
        public Guid Id { get; set; }
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string IdEjemplar { get; set; }
    }
}
