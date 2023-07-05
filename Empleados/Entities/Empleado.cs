using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Entities
{
    public class Empleado
    {
        [Key]
        public int PkEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Correo { get; set; }
    }
}
