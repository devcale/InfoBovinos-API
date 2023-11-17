using InfoBovinosAPI.Interfaces;
using InfoBovinosAPI.Mappers;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Helpers
{
    public class RazaAssociationChecker
    {
        private readonly IAnimalRepository _animalRepository;
        public RazaAssociationChecker(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }
        public bool RazaHasAssociatedAnimals(Raza raza)
        {
            return _animalRepository.GetAnimales().Any(animal => animal.RazaId == raza.RazaId);
        }
    }
}
