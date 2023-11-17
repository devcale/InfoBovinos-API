using InfoBovinosAPI.DTOs;
using InfoBovinosAPI.Enums;
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

        public Animal DTOToAnimal(AnimalDTO dto)
        {
            Enum.TryParse<SexoEnum>(dto.Sexo, out SexoEnum sexo);
            Enum.TryParse<EstadoEnum>(dto.Estado, out EstadoEnum estado);
            return new Animal
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                FechaNacimiento = dto.FechaNacimiento,
                Sexo = sexo,
                Precio = dto.Precio,
                Estado = estado,
                Comentarios = dto.Comentarios,
                RazaId = dto.RazaId,
            };
        }
    }
}
