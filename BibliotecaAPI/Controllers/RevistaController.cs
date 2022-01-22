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
        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var revistas = _repository.Revista.GetAllRevistas();
                _logger.LogInfo($"Returned all owners from database.");
                return Ok(revistas);

                var revistasResult = _mapper.Map<IEnumerable<RevistaDto>>(revistas);
                return Ok(revistasResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
