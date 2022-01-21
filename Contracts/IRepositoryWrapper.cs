using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IAutorRepository Autor { get; }
        IEstanteRepository Estante { get;  }
        IEstanteriaRepository Estanteria { get; }
        ILibroRepository Libro { get; }
        IRevistaRepository Revista { get; }
        void Save();
    }
}
