using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class LibroRepository : RepositoryBase<Libro>, ILibroRepository
    {
        public LibroRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {
        }

        public IEnumerable<Libro> GetAllLibros()
        {
            return FindAll()
                .OrderBy(li => li.Titulo)
                .ToList();
        }

        public Libro GetLibroById(Guid IdLibro)
        {
            return FindByCondition(libro => libro.Id.Equals(IdLibro)).FirstOrDefault();
        }

        public void CreateLibro(Libro libro)
        {
            Create(libro);
        }

        public void UpdateLibro(Libro libro)
        {
            Update(libro);
        }
    }
}
