namespace UD25_EJ1.Models
{
    public class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int Fabricante { get; set; }

        public Fabricante Fabricantes { get; set; }
    }
}
