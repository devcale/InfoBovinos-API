using InfoBovinosAPI.DTOs;
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
        public IActionResult GetRazas(int page = 1, int pageSize = 10)
        {
            ICollection<RazaDTO> razas = _razaRepository.GetRazas();
            int totalCount = razas.Count();
            int totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);
            ICollection<RazaDTO> razasPerPage = razas
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(razasPerPage);
        }

        [HttpGet("{razaId}")]
        [ProducesResponseType(200, Type = typeof(RazaDTO))]
        [ProducesResponseType(400)]
        public IActionResult GetRaza(int razaId)
        {
            if (!_razaRepository.RazaExists(razaId))
            {
                return NotFound();
            }

            RazaDTO raza = _razaRepository.GetRaza(razaId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(raza);
        }
    }
}
