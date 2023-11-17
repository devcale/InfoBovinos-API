using InfoBovinosAPI.Data;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Interfaces;

namespace InfoBovinosAPI.Repository
{
    public class AnimalRazaRepository : IAnimalRazaRepository
    {
        private readonly DataContext _context;

        public AnimalRazaRepository(DataContext context)
        {
            _context = context;
        }

        public Dictionary<string, int> GetActiveAnimalCountByBreed()
        {
            var razas = _context.Razas;
            var activeAnimals = _context.Animales.Where(a => a.Estado == 0);

            var dictionary = razas
                .Join(
                    activeAnimals, 
                    r => r.RazaId, 
                    a => a.RazaId, 
                    (r, a) => new { raza = r.Nombre }
                )
                .ToList()
                .GroupBy(a => a.raza)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count()
                );

            
            return dictionary;
        }

    }
}
