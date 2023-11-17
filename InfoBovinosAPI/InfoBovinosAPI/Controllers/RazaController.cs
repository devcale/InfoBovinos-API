using FluentValidation;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Helpers;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
using InfoBovinosAPI.Models;
using InfoBovinosAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace InfoBovinosAPI.Controllers
{
    [Route("api/raza")]
    [ApiController]
    public class RazaController : Controller
    {
        private readonly IRazaRepository _razaRepository;
        private readonly RazaMapper _mapper;
        private readonly RazaAssociationChecker _associationChecker;
        private readonly IValidator<RazaDTO> _razaValidator;

        public RazaController(IRazaRepository razaRepository, RazaMapper mapper, RazaAssociationChecker razaAssociationChecker, IValidator<RazaDTO> razaValidator)
        {
            _razaRepository = razaRepository;
            _mapper = mapper;
            _associationChecker = razaAssociationChecker;
            _razaValidator = razaValidator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Raza>))]
        public IActionResult GetRazas(int page = 1, int pageSize = 10)
        {
            ICollection<RazaDTO> razas = _razaRepository.GetRazas().Select(raza => _mapper.RazaToDTO(raza)).ToList();
            int totalCount = razas.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            ICollection<RazaDTO> razasPerPage = razas
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(razasPerPage);
        }

        [HttpGet("{razaId}")]
        [ProducesResponseType(200, Type = typeof(RazaDTO))]
        [ProducesResponseType(400)]
        public IActionResult GetRaza(int razaId)
        {
            if (!_razaRepository.RazaExists(razaId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            RazaDTO raza = _mapper.RazaToDTO(_razaRepository.GetRaza(razaId));

            return Ok(raza);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRaza([FromBody] RazaDTO razaCreate)
        {
            var validationResult = _razaValidator.Validate(razaCreate);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var razaDTO = _mapper.DTOToRaza(razaCreate);
            bool success = _razaRepository.CreateRaza(razaDTO);
            if (!success)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar crear la raza.");
                return StatusCode(500, ModelState);
            }

            return Ok("Se ha creado la raza correctamente");
        }

        [HttpPut("{razaId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRaza(int razaId, [FromBody] RazaDTO razaUpdate)
        {
            var validationResult = _razaValidator.Validate(razaUpdate);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            if (razaId != razaUpdate.RazaId)
                return BadRequest(ModelState);

            if(!_razaRepository.RazaExists(razaId))
                return NotFound();

            Raza raza = _mapper.DTOToRaza(razaUpdate);
            bool success = _razaRepository.UpdateRaza(raza);

            if (!success)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar actualizar la raza");
                return StatusCode(500, ModelState);
            }

            return NoContent();
                
        }

        [HttpDelete("{razaId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRaza(int razaId)
        {
            if(!_razaRepository.RazaExists(razaId))
                return NotFound();

            var razaToDelete = _razaRepository.GetRaza(razaId);

            if (_associationChecker.RazaHasAssociatedAnimals(razaToDelete))
            {
                ModelState.AddModelError("", "Esta raza esta asociada a uno o más animales. Borra o actualiza los animales correspondientes e intentalo de nuevo.");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!_razaRepository.DeleteRaza(razaToDelete))
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar la raza");
            }

            return NoContent();
        }

        
    }
}
