using FluentValidation;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
using InfoBovinosAPI.Models;
using InfoBovinosAPI.Validators;
using Microsoft.AspNetCore.Mvc;

namespace InfoBovinosAPI.Controllers
{
    [Route("api/animales")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly AnimalMapper _mapper;
        private readonly IValidator<AnimalDTO> _animalValidator;

        public AnimalController(IAnimalRepository animalRepository, AnimalMapper mapper, IValidator<AnimalDTO> animalValidator)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
            _animalValidator = animalValidator;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AnimalDTO>))]
        public IActionResult GetAnimales(int page = 1, int pageSize = 10) {
            ICollection<AnimalDTO> animales = _animalRepository.GetAnimales().Select(animal => _mapper.AnimalToDTO(animal)).ToList();
            int totalCount = animales.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            ICollection<AnimalDTO> animalsPerPage = animales
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok(animalsPerPage);
        }

        [HttpGet("{animalId}")]
        [ProducesResponseType(200, Type = typeof(AnimalDTO))]
        [ProducesResponseType(400)]
        public IActionResult GetAnimal(int animalId)
        {
            if(!_animalRepository.AnimalExists(animalId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AnimalDTO animal = _mapper.AnimalToDTO(_animalRepository.GetAnimal(animalId));

            return Ok(animal);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAnimal([FromBody] AnimalDTO animalCreate)
        {
            var validationResult = _animalValidator.Validate(animalCreate);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var animal = _mapper.DTOToAnimal(animalCreate);
            bool success = _animalRepository.CreateAnimal(animal);

            if (!success)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar crear el animal.");
                return StatusCode(500, ModelState);
            }

            return Ok("Se ha creado el animal correctamente");
        }

        [HttpPut("{animalId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAnimal(int animalId, [FromBody] AnimalDTO animalUpdate)
        {
            var validationResult = _animalValidator.Validate(animalUpdate);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            if (animalId != animalUpdate.Id)
                return BadRequest(ModelState);

            Animal animal = _mapper.DTOToAnimal(animalUpdate);
            bool success = _animalRepository.UpdateAnimal(animal);

            if (!success)
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar actualizar el animal.");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{animalId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAnimal(int animalId)
        {
            if (!_animalRepository.AnimalExists(animalId))
                return NotFound();

            var animalToDelete = _animalRepository.GetAnimal(animalId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_animalRepository.DeleteAnimal(animalToDelete))
            {
                ModelState.AddModelError("", "Ha ocurrido un error al intentar eliminar el animal");
            }

            return NoContent();
        }




    }
}
