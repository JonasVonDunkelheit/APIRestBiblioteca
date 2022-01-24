using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPI.Controllers
{
    [Route("api/libro")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public LibroController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = "LibroById")]
        public IActionResult GetLibroById(Guid id)
        {
            try
            {
                var libros = _repository.Libro.GetLibroById(id);

                if(libros == null)
                {
                    _logger.LogInfo($"El libro con el id: {id}, no se encuentra en la base de datos.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"El libro con el id: {id}");

                    var librosResult = _mapper.Map<LibroDto>(libros);
                    return Ok(librosResult);
                }                                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal con la acción GetLibroById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateLibro([FromBody]LibroForCreationDto libro)
        {
            try
            {
                if (libro== null)
                {
                    _logger.LogError("El objeto Libro enviado desde el cliente es nulo.");
                    return BadRequest("El objeto Libro es nulo.");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto Libro enviado desde el cliente es inválido.");
                    return BadRequest("Modelo de objeto inválido");
                }
                var libroEntity = _mapper.Map<Libro>(libro);
                _repository.Libro.CreateLibro(libroEntity);
                _repository.Save();
                var createdLibro = _mapper.Map<LibroDto>(libroEntity);
                return CreatedAtRoute("LibroById", new { id = createdLibro }, createdLibro);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal dentro de la acción CreateLibro: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
