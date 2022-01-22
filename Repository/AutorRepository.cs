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
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public AutorRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {
        }

        public IEnumerable<Autor> GetAllAutors()
        {
            return FindAll()
                .OrderBy(au => au.Nombre)
                .ToList();
        }

        public Autor GetAutorById(Guid IdAutor)
        {
            return FindByCondition(autor => autor.Id.Equals(IdAutor)).FirstOrDefault();
        }
    }
}
