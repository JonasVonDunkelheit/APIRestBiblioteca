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

            CreateMap<AutorForCreationDto, Autor>();
            CreateMap<EstanteForCreationDto, Estante>();
            CreateMap<EstanteriaForCreationDto, Estanteria>();
            CreateMap<LibroForCreationDto, Libro>();
            CreateMap<RevistaForCreationDto, Revista>();

            CreateMap<AutorForUpdateDto, Autor>();            
            CreateMap<EstanteForUpdateDto, Estante>();
            CreateMap<EstanteriaForUpdateDto, Estanteria>();
            CreateMap<LibroForUpdateDto, Libro>();
            CreateMap<RevistaForUpdateDto, Revista>();
        }
    }
}
