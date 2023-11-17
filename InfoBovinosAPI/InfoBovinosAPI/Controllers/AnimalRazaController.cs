using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InfoBovinosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalRazaController : Controller
    {
        private readonly IAnimalRazaRepository _animalRazaRepository;

        public AnimalRazaController(IAnimalRazaRepository animalRazaRepository)
        {
            _animalRazaRepository = animalRazaRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Dictionary<string, int>))]
        public IActionResult GetActiveAnimalsByBreed()
        {
            Dictionary<string, int> animals = _animalRazaRepository.GetActiveAnimalCountByBreed();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(animals);
        }
    }
}
