using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Interfaces
{
    public interface IRazaRepository
    {
        bool CreateRaza(Raza raza);
        ICollection<Raza> GetRazas();
        Raza GetRaza(int id);        
        bool UpdateRaza(Raza raza);
        bool DeleteRaza(Raza raza);
        bool RazaExists(int id);
        bool Save();
    }
}
