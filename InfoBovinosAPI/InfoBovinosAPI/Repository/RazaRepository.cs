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

        public bool CreateRaza(Raza raza)
        {
            _context.Add(raza);
            return Save();
        }

        public Raza GetRaza(int id)
        {
            return _context.Razas.Where(r => r.RazaId == id).FirstOrDefault();
            
        }

        public ICollection<Raza> GetRazas()
        {
            return _context.Razas.OrderBy(r => r.RazaId).ToList();
        }

        public bool UpdateRaza(Raza raza)
        {
            _context.Update(raza);
            return Save();
        }

        public bool DeleteRaza(Raza raza)
        {
            _context.Remove(raza);
            return Save();
        }

        public bool RazaExists(int id)
        {
            return _context.Razas.Any(a => a.RazaId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
