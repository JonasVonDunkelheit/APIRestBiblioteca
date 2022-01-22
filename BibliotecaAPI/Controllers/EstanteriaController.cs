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
        public IActionResult GetAllOwners()
        {
            try
            {
                var estanterias = _repository.Estanteria.GetAllEstanterias();
                _logger.LogInfo($"Returned all owners from database.");
                return Ok(estanterias);

                var estanteriasResult = _mapper.Map<IEnumerable<EstanteriaDto>>(estanterias);
                return Ok(estanteriasResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
