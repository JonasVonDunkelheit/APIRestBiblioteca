using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class AutorDto
    {
        public Guid Id { get; set; }     
        public string Nombre { get; set; }        
        public string Apellidos { get; set; }        
        public string Nacionalidad { get; set; }        
        public Guid IdLibro { get; set; }
    }
}
