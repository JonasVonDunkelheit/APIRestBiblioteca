using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IAutorRepository : IRepositoryBase<Autor>
    {
        IEnumerable<Autor> GetAllAutors();
        Autor GetAutorById(Guid IdAutor);
        void CreateAutor(Autor autor);
    }
}
