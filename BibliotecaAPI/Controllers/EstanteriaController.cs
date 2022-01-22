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
        [HttpGet("{id}")]
        public IActionResult GetEstanteriaById(Guid id)
        {
            try
            {
                var estanterias = _repository.Estanteria.GetEstanteriaById(id);

                if(estanterias == null)
                {
                    _logger.LogInfo($"La estantería con el id: {id}, no se encuentra en la base de datos.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"La estantería con el id: {id}");

                    var estanteriasResult = _mapper.Map<EstanteriaDto>(estanterias);
                    return Ok(estanteriasResult);
                }                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal con la acción GetEstanteriaById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
