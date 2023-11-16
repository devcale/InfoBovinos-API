using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Interfaces
{
    public interface IAnimalRepository
    {
        ICollection<Animal> GetAnimales();
    }
}
