using InfoBovinosAPI.Data;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Repository
{
    public class RazaRepository : IRazaRepository
    {
        private readonly DataContext _context;
        public RazaRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Raza> GetRazas()
        {
            return _context.Razas.OrderBy(r => r.RazaId).ToList();
        }
    }
}
