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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Animal>))]
        public IActionResult GetAnimales() {
            var animales = _animalRepository.GetAnimales();

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok(animales);
        }
    }
}
