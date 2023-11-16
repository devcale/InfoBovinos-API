using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Interfaces
{
    public interface IAnimalRepository
    {
        ICollection<AnimalDTO> GetAnimales();
        AnimalDTO GetAnimal(int id);
        Animal CreateAnimal(Animal animal);
        Animal UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);
        bool AnimalExists(int id);

    }
}
