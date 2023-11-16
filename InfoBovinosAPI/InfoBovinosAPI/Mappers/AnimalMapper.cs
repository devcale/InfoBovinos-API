using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Models;

namespace InfoBovinosAPI.Mappers
{
    public class AnimalMapper
    {
        public AnimalDTO AnimalToDTO(Animal animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                Nombre = animal.Nombre,
                FechaNacimiento = animal.FechaNacimiento,
                Sexo = animal.Sexo.ToString(),
                Precio = animal.Precio,
                Estado = animal.Estado.ToString(),
                Comentarios = animal.Comentarios,
                RazaId = animal.RazaId,
            };
        }
    }
}
