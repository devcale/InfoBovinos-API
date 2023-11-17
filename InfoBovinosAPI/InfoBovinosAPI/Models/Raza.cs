namespace InfoBovinosAPI.Models
{
    public class Raza
    {
        public int RazaId { get; set; }
        public string Nombre { get; set; }
        public ICollection<Animal> Animales { get; set; }
    }
}
