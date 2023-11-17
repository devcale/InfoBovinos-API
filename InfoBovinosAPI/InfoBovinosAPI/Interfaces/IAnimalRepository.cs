using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Interfaces
{
    public interface IAnimalRepository
    {
        bool CreateAnimal(Animal animal);
        ICollection<Animal> GetAnimales();
        Animal GetAnimal(int id);
        bool UpdateAnimal(Animal animal);
        bool DeleteAnimal(Animal animal);
        bool AnimalExists(int id);
        bool Save();

    }
}
