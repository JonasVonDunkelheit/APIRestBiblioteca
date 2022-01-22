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
    [Route("api/libro")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public LibroController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public IActionResult GetLibroById(Guid id)
        {
            try
            {
                var libros = _repository.Libro.GetLibroById(id);

                if(libros == null)
                {
                    _logger.LogInfo($"El libro con el id: {id}, no se encuentra en la base de datos.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"El libro con el id: {id}");

                    var librosResult = _mapper.Map<LibroDto>(libros);
                    return Ok(librosResult);
                }                                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo salió mal con la acción GetLibroById: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
