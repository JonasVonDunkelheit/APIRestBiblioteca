using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class LibroDto
    {
        public Guid Id { get; set; }
        public string ISBN { get; set; }        
        public string Titulo { get; set; }        
        public string Formato { get; set; }        
        public int NumPag { get; set; }        
        public string IdEjemplar { get; set; }
    }
}
