using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoBovinosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazaController : Controller
    {
        private readonly IRazaRepository _razaRepository;

        public RazaController(IRazaRepository razaRepository)
        {
            _razaRepository = razaRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Raza>))]
        public IActionResult GetRazas()
        {
            var razas = _razaRepository.GetRazas();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(razas);
        }
    }
}
