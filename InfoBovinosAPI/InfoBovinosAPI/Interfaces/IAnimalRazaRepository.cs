using InfoBovinosAPI.DTOs;

namespace InfoBovinosAPI.Interfaces
{
    public interface IAnimalRazaRepository
    {
        Dictionary<string, int> GetActiveAnimalCountByBreed();
    }
}
