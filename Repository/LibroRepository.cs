﻿using System;
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
    }
}
