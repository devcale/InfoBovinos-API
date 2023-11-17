using InfoBovinosAPI.Data;
using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Enums;
using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
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

        public bool AnimalExists(int id)
        {
            return _context.Animales.Any(a => a.Id == id);
        }

        public bool CreateAnimal(Animal animal)
        {
            _context.Add(animal);
            return Save();
        }

        public void DeleteAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public Animal GetAnimal(int id)
        {
            return _context.Animales.Where(a => a.Id == id).FirstOrDefault();
        }

        public ICollection<Animal> GetAnimales()
        {
            return _context.Animales.OrderBy(a => a.Id).ToList();          
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAnimal(Animal animal)
        {
            _context.Update(animal);
            return Save();
        }


    }
}
