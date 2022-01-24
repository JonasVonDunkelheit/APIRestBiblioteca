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
    public class RevistaRepository : RepositoryBase<Revista>, IRevistaRepository
    {
        public RevistaRepository(RepositoryContext repositoryContext) :base(repositoryContext)
        {
        }

        public IEnumerable<Revista> GetAllRevistas()
        {
            return FindAll()
                .OrderBy(re => re.Nombre)
                .ToList();
        }

        public Revista GetResvistaById(Guid IdRevista)
        {
            return FindByCondition(revista => revista.Id.Equals(IdRevista)).FirstOrDefault();
        }

        public void CreateRevista(Revista revista)
        {
            Create(revista);
        }
    }
}
