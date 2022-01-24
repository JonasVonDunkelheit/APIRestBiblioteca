using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IRevistaRepository :IRepositoryBase<Revista>
    {
        IEnumerable<Revista> GetAllRevistas();
        Revista GetRevistaById(Guid IdRevista);
        void CreateRevista(Revista revista);
        void UpdateRevista(Revista revista);
        void DeleteRevista(Revista revista);
    }
}
