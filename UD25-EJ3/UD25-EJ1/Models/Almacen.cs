using System.Collections.Generic;

namespace UD25_EJ1.Models
{
    public class Almacen
    {
        public int Codigo { get; set; }
        public string Lugar { get; set; }
        public int Capacidad { get; set; }

        public ICollection<Caja> Cajas { get; set; }
    }
}
