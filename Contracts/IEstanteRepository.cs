using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IEstanteRepository : IRepositoryBase<Estante>
    {
        IEnumerable<Estante> GetAllEstantes();
        Estante GetEstanteById(Guid IdEstante);
        void CreateEstante(Estante estante);
        void UpdateEstante(Estante estante);
        void DeleteEstante(Estante estante);
    }
}
