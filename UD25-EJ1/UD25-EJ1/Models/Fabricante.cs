using System.Collections.Generic;

namespace UD25_EJ1.Models
{
    public class Fabricante
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<Articulo> Articulos { get; set; }
    }
}
