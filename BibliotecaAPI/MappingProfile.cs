using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Autor, AutorDto>();
            CreateMap<Estante, EstanteDto>();
            CreateMap<Estanteria, EstanteriaDto>();
            CreateMap<Libro, LibroDto>();
            CreateMap<Revista, RevistaDto>();
        }
    }
}
