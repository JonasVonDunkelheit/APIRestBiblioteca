using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IAutorRepository _autor;
        private IEstanteRepository _estante;
        private IEstanteriaRepository _estanteria;
        private ILibroRepository _libro;
        private IRevistaRepository _revista;

        public IAutorRepository Autor
        {
            get
            {
                if(_autor == null)
                {
                    _autor = new AutorRepository(_repoContext);
                }

                return _autor;
            }
        }

        public IEstanteRepository Estante
        {
            get
            {
                if (_estante == null)
                {
                    _estante = new EstanteRepository(_repoContext);
                }

                return _estante;
            }
        }

        public IEstanteriaRepository Estanteria
        {
            get
            {
                if (_estanteria == null)
                {
                    _estanteria = new EstanteriaRepository(_repoContext);
                }

                return _estanteria;
            }
        }

        public ILibroRepository Libro
        {
            get
            {
                if (_libro == null)
                {
                    _libro = new LibroRepository(_repoContext);
                }

                return _libro;
            }
        }

        public IRevistaRepository Revista
        {
            get
            {
                if (_revista == null)
                {
                    _revista = new RevistaRepository(_repoContext);
                }

                return _revista;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
