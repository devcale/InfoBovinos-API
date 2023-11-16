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
        private readonly AnimalMapper _mapper;
        public AnimalRepository(DataContext context, AnimalMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AnimalExists(int id)
        {
            return _context.Animales.Any(a => a.Id == id);
        }

        public Animal CreateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public void DeleteAnimal(int id)
        {
            throw new NotImplementedException();
        }

        public AnimalDTO GetAnimal(int id)
        {
            Animal animal = _context.Animales.Where(a => a.Id == id).FirstOrDefault();
            return _mapper.AnimalToDTO(animal);
        }

        public ICollection<AnimalDTO> GetAnimales()
        {
            List<AnimalDTO> animals = _context.Animales.OrderBy(a => a.Id).Select(animal => _mapper.AnimalToDTO(animal)).ToList();          
            return animals;
        }

        public Animal UpdateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        
    }
}
