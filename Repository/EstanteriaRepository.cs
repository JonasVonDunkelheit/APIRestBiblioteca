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
    public class EstanteriaRepository : RepositoryBase<Estanteria>, IEstanteriaRepository
    {
        public EstanteriaRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {
        }

        public IEnumerable<Estanteria> GetAllEstanterias()
        {
            return FindAll()
                .OrderBy(es => es.Codigo)
                .ToList();
        }

        public Estanteria GetEstanteriaById(Guid IdEstanteria)
        {
            return FindByCondition(estanteria => estanteria.Id.Equals(IdEstanteria)).FirstOrDefault();
        }

        public void CreateEstanteria(Estanteria estanteria)
        {
            Create(estanteria);
        }

        public void UpdateEstanteria(Estanteria estanteria)
        {
            Update(estanteria);
        }
    }
}
