using InfoBovinosAPI.Enums;

namespace InfoBovinosAPI.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public SexoEnum Sexo { get; set; }
        public decimal Precio { get; set; }
        public EstadoEnum Estado { get; set; }
        public string Comentarios { get; set; }
        public int RazaId { get; set; }
        public Raza Raza { get; set; }
    }

}
