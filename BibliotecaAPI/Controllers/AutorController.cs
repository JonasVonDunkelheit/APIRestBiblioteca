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
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
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
    }
}
