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
    [Route("api/estante")]
    [ApiController]
    public class EstanteController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public EstanteController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("{id}", Name = "EstanteById")]
        public IActionResult GetEstanteById(Guid id)
        {
            try
            {
                var estantes = _repository.Estante.GetEstanteById(id);

                if(estantes == null)
                {
                    _logger.LogInfo($"El estante con el id: {id}, no se encuentra en la base de datos.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"El estante con el id: {id}");

                    var estantesResult = _mapper.Map<EstanteDto>(estantes);
                    return Ok(estantesResult);
                }                                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal con la acción GetEstanteById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateEstante([FromBody]EstanteForCreationDto estante)
        {
            try
            {
                if (estante == null)
                {
                    _logger.LogError("El objeto Estante enviado desde el cliente es nulo.");
                    return BadRequest("El objeto Estante es nulo.");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto Estante enviado desde el cliente es inválido.");
                    return BadRequest("Modelo de objeto inválido");
                }
                var estanteEntity = _mapper.Map<Estante>(estante);
                _repository.Estante.CreateEstante(estanteEntity);
                _repository.Save();
                var createdEstante = _mapper.Map<EstanteDto>(estanteEntity);
                return CreatedAtRoute("EstanteById", new { id = createdEstante }, createdEstante);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal dentro de la acción CreateEstante: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEstante(Guid id, [FromBody] EstanteForUpdateDto estante)
        {
            try
            {
                if (estante == null)
                {
                    _logger.LogError("El objeto Estante enviado desde el cliente es nulo.");
                    return BadRequest("El objeto Estante es nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El objeto Estante enviado desde el cliente es inválido.");
                    return BadRequest("Modelo de objeto inválido");
                }

                var estanteEntity = _repository.Estante.GetEstanteById(id);
                if (estanteEntity == null)
                {
                    _logger.LogError($"El Estante con id: {id}, no se encontró en la base de datos.");
                    return NotFound();
                }

                _mapper.Map(estante, estanteEntity);

                _repository.Estante.UpdateEstante(estanteEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"SAlgo salío mal dentro de la acción UpdateEstante: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
