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
        [HttpGet]
        public IActionResult GetAllEstantes()
        {
            try
            {
                var estantes = _repository.Estante.GetAllEstantes();
                _logger.LogInfo($"Returned all owners from database.");
                return Ok(estantes);

                var estantesResult = _mapper.Map<IEnumerable<EstanteDto>>(estantes);
                return Ok(estantesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
