using InfoBovinosAPI.Data;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Repository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly DataContext _context;
        public AnimalRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Animal> GetAnimales()
        {
            return _context.Animales.OrderBy(a => a.Id).ToList();
        }
    }
}
