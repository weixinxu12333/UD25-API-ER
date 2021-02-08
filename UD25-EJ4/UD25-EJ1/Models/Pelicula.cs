using System.Collections.Generic;

namespace UD25_EJ1.Models
{
    public class Pelicula
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int CalificacionEdad { get; set; }

        public ICollection<Sala> Salas { get; set; }

    }
}
