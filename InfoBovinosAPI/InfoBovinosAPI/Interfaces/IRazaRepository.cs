using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Interfaces
{
    public interface IRazaRepository
    {
        ICollection<Raza> GetRazas();
    }
}
