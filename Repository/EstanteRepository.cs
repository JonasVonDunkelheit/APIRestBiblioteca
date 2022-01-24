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
    public class EstanteRepository : RepositoryBase<Estante>, IEstanteRepository
    {
        public EstanteRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {
        }

        public IEnumerable<Estante> GetAllEstantes()
        {
            return FindAll()
                .OrderBy(est => est.Codigo)
                .ToList();
        }

        public Estante GetEstanteById(Guid IdEstante)
        {
            return FindByCondition(estante => estante.Id.Equals(IdEstante)).FirstOrDefault();
        }
        
        public void CreateEstante(Estante estante)
        {
            Create(estante);
        }

        public void UpdateEstante(Estante estante)
        {
            Update(estante);
        }
    }
}
