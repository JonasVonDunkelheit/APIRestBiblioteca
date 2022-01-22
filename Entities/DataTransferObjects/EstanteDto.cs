using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class EstanteDto
    {
        public Guid Id { get; set; }        
        public string Codigo { get; set; }        
        public Guid IdLibro { get; set; }                
        public Guid IdRevista { get; set; }
    }
}
