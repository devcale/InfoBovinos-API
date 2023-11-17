using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
using InfoBovinosAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InfoBovinosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RazaController : Controller
    {
        private readonly IRazaRepository _razaRepository;
        private readonly RazaMapper _mapper;

        public RazaController(IRazaRepository razaRepository, RazaMapper mapper)
        {
            _razaRepository = razaRepository;
            _mapper = mapper;
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

            RazaDTO raza = _mapper.RazaToDTO(_razaRepository.GetRaza(razaId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(raza);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRaza([FromBody] RazaDTO razaCreate)
        {
            if(razaCreate == null)
                return BadRequest(ModelState);
            
            var raza = _razaRepository.GetRazas()
                .Where(r => r.Nombre.Trim().ToUpper() == razaCreate.Nombre.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (raza != null)
            {
                ModelState.AddModelError("", "La raza ya existe. El id es " + raza.RazaId);
                return StatusCode(422, ModelState);
            }

            if(!ModelState.IsValid) 
            { 
                return BadRequest(ModelState); 
            }

            var razaDTO = _mapper.DTOToRaza(razaCreate);

            if (!_razaRepository.CreateRaza(razaDTO))
            {
                ModelState.AddModelError("", "Algo ha salido mal al intentar crear la raza.");
                return StatusCode(500, ModelState);
            }
            return Ok("Se ha creado la raza correctamente");
            
        }

        [HttpPut("{razaId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRaza(int razaId, [FromBody] RazaDTO updatedRaza)
        {
            if(updatedRaza == null) 
                return BadRequest(ModelState);

            if(razaId != updatedRaza.RazaId)
                return BadRequest(ModelState);

            if(!_razaRepository.RazaExists(razaId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            Raza raza = _mapper.DTOToRaza(updatedRaza);

            if(!_razaRepository.UpdateRaza(raza))
            {
                ModelState.AddModelError("", "Algo ha salido mal al intentar actualizar la raza");
                return StatusCode(500, ModelState);
            }

            return NoContent();
                
        }
    }
}
