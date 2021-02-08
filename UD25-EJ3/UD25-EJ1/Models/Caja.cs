namespace UD25_EJ1.Models
{
    public class Caja
    {
        public string NumReferencia { get; set; }
        public string Contenido { get; set; }
        public int Valor { get; set; }
        public int Almacen { get; set; }

        public Almacen Almacenes { get; set; }

    }
}
