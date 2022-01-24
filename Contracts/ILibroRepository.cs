using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface ILibroRepository : IRepositoryBase<Libro>
    {
        IEnumerable<Libro> GetAllLibros();
        Libro GetLibroById(Guid IdLibro);
        void CreateLibro(Libro libro);
        void UpdateLibro(Libro libro);
    }
}
