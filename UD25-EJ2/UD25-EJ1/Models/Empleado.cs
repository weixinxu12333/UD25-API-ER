namespace UD25_EJ1.Models
{
    public class Empleado
    {
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Dep { get; set; }

        public Departamento Departamentos { get; set; }
    }
}
