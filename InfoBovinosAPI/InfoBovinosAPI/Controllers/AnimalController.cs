using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoBovinosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AnimalDTO>))]
        public IActionResult GetAnimales(int page = 1, int pageSize = 10) {
            ICollection<AnimalDTO> animales = _animalRepository.GetAnimales();
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

            AnimalDTO animal = _animalRepository.GetAnimal(animalId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(animal);
        }


    }
}
