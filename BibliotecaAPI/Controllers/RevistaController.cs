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
    [Route("api/revista")]
    [ApiController]
    public class RevistaController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public RevistaController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = "RevistaById")]
        public IActionResult GetRevistaById(Guid id)
        {
            try
            {
                var revistas = _repository.Revista.GetRevistaById(id);

                if(revistas == null)
                {
                    _logger.LogInfo($"La revista con el id: {id}, no se encuentra en la base de datos.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"La revista con id: {id}");

                    var revistasResult = _mapper.Map<RevistaDto>(revistas);
                    return Ok(revistasResult);
                }                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal con la acción GetRevistaById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRevista([FromBody]RevistaForCreationDto revista)
        {
            try
            {
                if (revista == null)
                {
                    _logger.LogError("El objeto Revista enviado desde el cliente es nulo.");
                    return BadRequest("El objeto Revista es nulo.");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto Revista enviado desde el cliente es inválido.");
                    return BadRequest("Modelo de objeto inválido");
                }
                var revistaEntity = _mapper.Map<Revista>(revista);
                _repository.Revista.CreateRevista(revistaEntity);
                _repository.Save();
                var createdRevista = _mapper.Map<RevistaDto>(revistaEntity);
                return CreatedAtRoute("RevistaById", new { id = createdRevista }, createdRevista);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal dentro de la acción CreateRevista: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRevista(Guid id, [FromBody] RevistaForUpdateDto revista)
        {
            try
            {
                if (revista == null)
                {
                    _logger.LogError("El objeto Revista enviado desde el cliente es nulo.");
                    return BadRequest("El objeto Revista es nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto Revista enviado desde el cliente es inválido.");
                    return BadRequest("Modelo de objeto inválido");
                }

                var revistaEntity = _repository.Revista.GetRevistaById(id);
                if (revistaEntity == null)
                {
                    _logger.LogError($"La Revista con id: {id}, no se encontró en la base de datos.");
                    return NotFound();
                }

                _mapper.Map(revista, revistaEntity);

                _repository.Revista.UpdateRevista(revistaEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"SAlgo salío mal dentro de la acción UpdateRevista: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRevista(Guid id)
        {
            try
            {
                var revista = _repository.Revista.GetRevistaById(id);
                if (revista == null)
                {
                    _logger.LogError($"La Revista con el id: {id}, No se encontró en la base de datos.");
                    return NotFound();
                }

                _repository.Revista.DeleteRevista(revista);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal con la acción DeleteRevista: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
