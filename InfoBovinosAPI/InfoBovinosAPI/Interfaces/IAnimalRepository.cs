using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Interfaces
{
    public interface IAnimalRepository
    {
        ICollection<Animal> GetAnimales();
        Animal GetAnimal(int id);
        bool CreateAnimal(Animal animal);
        Animal UpdateAnimal(Animal animal);
        void DeleteAnimal(int id);
        bool AnimalExists(int id);
        bool Save();

    }
}
