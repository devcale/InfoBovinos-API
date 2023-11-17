using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
using InfoBovinosAPI.Models;
using InfoBovinosAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InfoBovinosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly AnimalMapper _mapper;

        public AnimalController(IAnimalRepository animalRepository, AnimalMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
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

            AnimalDTO animal = _mapper.AnimalToDTO(_animalRepository.GetAnimal(animalId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(animal);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAnimal([FromBody] AnimalDTO animalCreate)
        {
            if (animalCreate == null)
                return BadRequest(ModelState);

            var animal = _animalRepository.GetAnimales()
                .Where(a => a.Nombre.Trim().ToUpper() == animalCreate.Nombre.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (animal != null)
            {
                ModelState.AddModelError("", "Ya existe un animal con ese nombre. El id es " + animal.Id);
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animalDTO = _mapper.DTOToAnimal(animalCreate);

            if (!_animalRepository.CreateAnimal(animalDTO))
            {
                ModelState.AddModelError("", "Algo ha salido mal al intentar crear el animal.");
                return StatusCode(500, ModelState);
            }
            return Ok("Se ha creado el animal correctamente");

        }

        [HttpPut("{animalId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAnimal(int animalId, [FromBody] AnimalDTO updatedAnimal)
        {
            if (updatedAnimal == null)
                return BadRequest(ModelState);

            if (animalId != updatedAnimal.Id)
                return BadRequest(ModelState);

            if (!_animalRepository.AnimalExists(animalId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            Animal animal = _mapper.DTOToAnimal(updatedAnimal);

            if (!_animalRepository.UpdateAnimal(animal))
            {
                ModelState.AddModelError("", "Algo ha salido mal al intentar actualizar la raza");
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
