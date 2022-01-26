using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace BibliotecaAPI.Controllers
{
    [Route("api/estanteria")]
    [ApiController]
    public class EstanteriaController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public EstanteriaController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEstanteria()
        {
            var estanterias = _repository.Estanteria.GetAllEstanterias();

            var estanteriaDto = _mapper.Map<IEnumerable<EstanteriaDto>>(estanterias);

            return Ok(estanteriaDto);
        }

        [HttpGet("{id}", Name = "EstanteriaById")]
        public IActionResult GetEstanteriaById(Guid id)
        {
            var estanterias = _repository.Estanteria.GetEstanteriaById(id);
            if (estanterias == null)
            {
                _logger.LogInfo($"La Estanteria con id: {id}, no se encuentra en la base de datos.");
                return NotFound();
            }

            var estanteriaResult = _mapper.Map<EstanteriaDto>(estanterias);

            return Ok(estanteriaResult);

            //try
            //{
            //    var estanterias = _repository.Estanteria.GetEstanteriaById(id);

            //    if(estanterias == null)
            //    {
            //        _logger.LogInfo($"La estantería con el id: {id}, no se encuentra en la base de datos.");
            //        return NotFound();
            //    }
            //    else
            //    {
            //        _logger.LogInfo($"La estantería con el id: {id}");

            //        var estanteriasResult = _mapper.Map<EstanteriaDto>(estanterias);
            //        return Ok(estanteriasResult);
            //    }                
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Algo salió mal con la acción GetEstanteriaById: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }

        [HttpPost]
        public IActionResult CreateEstanteria([FromBody]EstanteriaForCreationDto estanteria)
        {
            if (estanteria == null)
            {
                _logger.LogError("El objeto Estanteria enviado desde el cliente es nulo.");
                return BadRequest("El objeto Estanteria es nulo.");
            }

            var estanteriaEntity = _mapper.Map<Estanteria>(estanteria);
            _repository.Estanteria.CreateEstanteria(estanteriaEntity);
            _repository.Save();

            var createdEstanteria = _mapper.Map<EstanteriaDto>(estanteriaEntity);
            return CreatedAtRoute("EstanteriaById", new { id = createdEstanteria }, createdEstanteria);

            //try
            //{
            //    if (estanteria == null)
            //    {
            //        _logger.LogError("El objeto Estanteria enviado desde el cliente es nulo.");
            //        return BadRequest("El objeto Estanteria es nulo.");
            //    }
            //    if (!ModelState.IsValid)
            //    {
            //        _logger.LogError("El objeto Estanteria enviado desde el cliente es inválido.");
            //        return BadRequest("Modelo de objeto inválido");
            //    }
            //    var estanteriaEntity = _mapper.Map<Estanteria>(estanteria);
            //    _repository.Estanteria.CreateEstanteria(estanteriaEntity);
            //    _repository.Save();
            //    var createdEstanteria = _mapper.Map<EstanteriaDto>(estanteriaEntity);
            //    return CreatedAtRoute("EstanteriaById", new { id = createdEstanteria }, createdEstanteria);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Algo salió mal dentro de la acción CreateEstanteria: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEstanteria(Guid id, [FromBody] EstanteriaForUpdateDto estanteria)
        {
            if (estanteria == null)
            {
                _logger.LogError("El objeto Estanteria enviado desde el cliente es nulo.");
                return BadRequest("El objeto Estanteria es nulo");
            }

            var estanteriaEntity = _repository.Estanteria.GetEstanteriaById(id);
            if (estanteriaEntity == null)
            {
                _logger.LogError($"La Estanteria con id: {id}, no se encontró en la base de datos.");
                return NotFound();
            }

            _mapper.Map(estanteria, estanteriaEntity);

            _repository.Estanteria.UpdateEstanteria(estanteriaEntity);
            _repository.Save();

            return NoContent();

            //try
            //{
            //    if (estanteria == null)
            //    {
            //        _logger.LogError("El objeto Estanteria enviado desde el cliente es nulo.");
            //        return BadRequest("El objeto Estanteria es nulo");
            //    }

            //    if (!ModelState.IsValid)
            //    {
            //        _logger.LogError("El objeto Estanteria enviado desde el cliente es inválido.");
            //        return BadRequest("Modelo de objeto inválido");
            //    }

            //    var estanteriaEntity = _repository.Estanteria.GetEstanteriaById(id);
            //    if (estanteriaEntity == null)
            //    {
            //        _logger.LogError($"La Estanteria con id: {id}, no se encontró en la base de datos.");
            //        return NotFound();
            //    }

            //    _mapper.Map(estanteria, estanteriaEntity);

            //    _repository.Estanteria.UpdateEstanteria(estanteriaEntity);
            //    _repository.Save();

            //    return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"SAlgo salío mal dentro de la acción UpdateEstanteria: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEstanteria(Guid id)
        {
            var estanteria = _repository.Estanteria.GetEstanteriaById(id);
            if (estanteria == null)
            {
                _logger.LogError($"La Estanteria con el id: {id}, No se encontró en la base de datos.");
                return NotFound();
            }

            _repository.Estanteria.DeleteEstanteria(estanteria);
            _repository.Save();
            return NoContent();

            //try
            //{
            //    var estanteria = _repository.Estanteria.GetEstanteriaById(id);
            //    if (estanteria == null)
            //    {
            //        _logger.LogError($"La estanteria con el id: {id}, No se encontró en la base de datos.");
            //        return NotFound();
            //    }

            //    _repository.Estanteria.DeleteEstanteria(estanteria);
            //    _repository.Save();

            //    return NoContent();
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError($"Algo salió mal con la acción DeleteEstanteria: {ex.Message}");
            //    return StatusCode(500, "Internal server error");
            //}
        }
    }
}
