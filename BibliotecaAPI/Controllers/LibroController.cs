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

        [HttpGet]
        public IActionResult GetLibro()
        {
            var libros = _repository.Libro.GetAllLibros();

            var libroDto = _mapper.Map<IEnumerable<LibroDto>>(libros);

            return Ok(libroDto);
        }

        [HttpGet("{id}", Name = "LibroById")]
        public IActionResult GetLibroById(Guid id)
        {
            var libros = _repository.Libro.GetLibroById(id);
            if (libros == null)
            {
                _logger.LogInfo($"El Libro con id: {id}, no se encuentra en la base de datos.");
                return NotFound();
            }

            var libroResult = _mapper.Map<LibroDto>(libros);

            return Ok(libroResult);

            //try
            //{
            //    var libros = _repository.Libro.GetLibroById(id);

            //    if(libros == null)
            //    {
            //        _logger.LogInfo($"El libro con el id: {id}, no se encuentra en la base de datos.");
            //        return NotFound();
            //    }
            //    else
            //    {
            //        _logger.LogInfo($"El libro con el id: {id}");

            //        var librosResult = _mapper.Map<LibroDto>(libros);
            //        return Ok(librosResult);
            //    }                                
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Algo salió mal con la acción GetLibroById: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }

        [HttpPost]
        public IActionResult CreateLibro([FromBody]LibroForCreationDto libro)
        {
            if (libro == null)
            {
                _logger.LogError("El objeto Libro enviado desde el cliente es nulo.");
                return BadRequest("El objeto Libro es nulo.");
            }

            var libroEntity = _mapper.Map<Libro>(libro);
            _repository.Libro.CreateLibro(libroEntity);
            _repository.Save();

            var createdLibro = _mapper.Map<LibroDto>(libroEntity);
            return CreatedAtRoute("LibroById", new { id = createdLibro }, createdLibro);

            //try
            //{
            //    if (libro== null)
            //    {
            //        _logger.LogError("El objeto Libro enviado desde el cliente es nulo.");
            //        return BadRequest("El objeto Libro es nulo.");
            //    }
            //    if (!ModelState.IsValid)
            //    {
            //        _logger.LogError("El objeto Libro enviado desde el cliente es inválido.");
            //        return BadRequest("Modelo de objeto inválido");
            //    }
            //    var libroEntity = _mapper.Map<Libro>(libro);
            //    _repository.Libro.CreateLibro(libroEntity);
            //    _repository.Save();
            //    var createdLibro = _mapper.Map<LibroDto>(libroEntity);
            //    return CreatedAtRoute("LibroById", new { id = createdLibro }, createdLibro);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Algo salió mal dentro de la acción CreateLibro: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLibro(Guid id, [FromBody] LibroForUpdateDto libro)
        {
            if (libro == null)
            {
                _logger.LogError("El objeto Libro enviado desde el cliente es nulo.");
                return BadRequest("El objeto Libro es nulo");
            }

            var libroEntity = _repository.Libro.GetLibroById(id);
            if (libroEntity == null)
            {
                _logger.LogError($"El Libro con id: {id}, no se encontró en la base de datos.");
                return NotFound();
            }

            _mapper.Map(libro, libroEntity);

            _repository.Libro.UpdateLibro(libroEntity);
            _repository.Save();

            return NoContent();

            //try
            //{
            //    if (libro == null)
            //    {
            //        _logger.LogError("El objeto Libro enviado desde el cliente es nulo.");
            //        return BadRequest("El objeto Libro es nulo");
            //    }

            //    if (!ModelState.IsValid)
            //    {
            //        _logger.LogError("El objeto Libro enviado desde el cliente es inválido.");
            //        return BadRequest("Modelo de objeto inválido");
            //    }

            //    var libroEntity = _repository.Libro.GetLibroById(id);
            //    if (libroEntity == null)
            //    {
            //        _logger.LogError($"El Libro con id: {id}, no se encontró en la base de datos.");
            //        return NotFound();
            //    }

            //    _mapper.Map(libro, libroEntity);

            //    _repository.Libro.UpdateLibro(libroEntity);
            //    _repository.Save();

            //    return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"SAlgo salío mal dentro de la acción UpdateLibro: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLibro(Guid id)
        {
            var libro = _repository.Libro.GetLibroById(id);
            if (libro == null)
            {
                _logger.LogError($"El Libro con el id: {id}, No se encontró en la base de datos.");
                return NotFound();
            }

            _repository.Libro.DeleteLibro(libro);
            _repository.Save();
            return NoContent();

            //try
            //{
            //    var libro = _repository.Libro.GetLibroById(id);
            //    if (libro == null)
            //    {
            //        _logger.LogError($"El Libro con el id: {id}, No se encontró en la base de datos.");
            //        return NotFound();
            //    }

            //    _repository.Libro.DeleteLibro(libro);
            //    _repository.Save();

            //    return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Algo salió mal con la acción DeleteLibro: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }
    }
}
