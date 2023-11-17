using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Interfaces
{
    public interface IRazaRepository
    {
        ICollection<Raza> GetRazas();
        Raza GetRaza(int id);
        bool RazaExists(int id);
        bool CreateRaza(Raza raza);
        bool UpdateRaza(Raza raza);
        bool DeleteRaza(Raza raza);
        bool Save();
    }
}
