using InfoBovinosAPI.DTOs;

namespace InfoBovinosAPI.Interfaces
{
    public interface IRazaRepository
    {
        ICollection<RazaDTO> GetRazas();
        RazaDTO GetRaza(int id);
        bool RazaExists(int id);
    }
}
