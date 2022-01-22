using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class EstanteriaDto
    {
        public Guid Id { get; set; }        
        public string Codigo { get; set; }        
        public string DimAlto { get; set; }        
        public string DimAncho { get; set; }        
        public Guid IdEstante { get; set; }
    }
}
