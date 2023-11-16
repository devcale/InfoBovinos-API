using InfoBovinosAPI.Data;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Repository
{
    public class RazaRepository : IRazaRepository
    {
        private readonly DataContext _context;
        private readonly RazaMapper _mapper;
        public RazaRepository(DataContext context, RazaMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public RazaDTO GetRaza(int id)
        {
            Raza raza = _context.Razas.Where(r => r.RazaId == id).FirstOrDefault();
            return _mapper.RazaToDTO(raza);
        }

        public ICollection<RazaDTO> GetRazas()
        {
            return _context.Razas.OrderBy(r => r.RazaId).Select(raza => _mapper.RazaToDTO(raza)).ToList();
        }

        public bool RazaExists(int id)
        {
            return _context.Razas.Any(a => a.RazaId == id);
        }
    }
}
