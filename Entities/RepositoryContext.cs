using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new autorConfiguration());
        //    modelBuilder.ApplyConfiguration(new estanteConfiguration());
        //    modelBuilder.ApplyConfiguration(new estanteriaConfiguration());
        //    modelBuilder.ApplyConfiguration(new libroConfiguration());
        //    modelBuilder.ApplyConfiguration(new revistaConfiguration());
        //}

        public DbSet<Autor> Autors { get; set; }
        public DbSet<Estante> Estantes { get; set; }
        public DbSet<Estanteria> Estanterias { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Revista> Revistas { get; set; }
    }
}
