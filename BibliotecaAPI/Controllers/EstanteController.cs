using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
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
    }
}
