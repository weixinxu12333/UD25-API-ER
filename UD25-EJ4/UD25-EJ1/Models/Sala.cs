namespace UD25_EJ1.Models
{
    public class Sala
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Pelicula { get; set; }

        public Pelicula Peliculas { get; set; }
    }
}
