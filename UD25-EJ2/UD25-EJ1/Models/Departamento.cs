using System.Collections.Generic;

namespace UD25_EJ1.Models
{
    public class Departamento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Presupuesto { get; set; }

        public ICollection<Empleado> Empleados { get; set; }

        public Departamento()
        {
            Empleados = new HashSet<Empleado>();
        }

    }
}
