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
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private Autor autorEntity;

        public AutorController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = "AutorById")]
        public IActionResult GetAutorbyId(Guid id)
        {
            try
            {
                var autors = _repository.Autor.GetAutorById(id);

                if (autors == null)
                {
                    _logger.LogInfo($"El Autor con id: {id}, no se encuentra en la base de datos.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Autor con el id: {id}");
                    var autorResult = _mapper.Map<AutorDto>(autors);
                    return Ok(autorResult);
                }                                    
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal con la acción GetAutorById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateAutor([FromBody]AutorForCreationDto autor)
        {
            try
            {
                if (autor == null)
                {
                    _logger.LogError("El objeto Autor enviado desde el cliente es nulo.");
                    return BadRequest("El objeto Autor es nulo.");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto Autor enviado desde el cliente es inválido.");
                    return BadRequest("Modelo de objeto inválido");
                }
                var autorEntity = _mapper.Map<Autor>(autor);
                _repository.Autor.CreateAutor(autorEntity);
                _repository.Save();
                var createdAutor = _mapper.Map<AutorDto>(autorEntity);
                return CreatedAtRoute("AutorById", new { id = createdAutor}, createdAutor);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salío mal dentro de la acción CreateAutor: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAutor(Guid id, [FromBody] AutorForUpdateDto autor)
        {
            try
            {
                if (autor == null)
                {
                    _logger.LogError("El objeto Autor enviado desde el cliente es nulo.");
                    return BadRequest("El objeto Autor es nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto Autor enviado desde el cliente es inválido.");
                    return BadRequest("Modelo de objeto inválido");
                }

                var autorEntity = _repository.Autor.GetAutorById(id);
                if (autorEntity == null)
                {
                    _logger.LogError($"El Autor con id: {id}, no se encontró en la base de datos.");
                    return NotFound();
                }

                _mapper.Map(autor, autorEntity);

                _repository.Autor.UpdateAutor(autorEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"SAlgo salío mal dentro de la acción UpdateAutor: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
