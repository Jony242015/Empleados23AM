using Empleados.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados.Context
{
    public class ApplicationDbContext : DbContext //Hereda una libreria de EntityFramework
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Cadena de conexion
            optionsBuilder.UseMySQL("server=localhost; database=Empleado23am; user=root; password=");
            //Si hay error con la mmigracion prueba esta
            //optionsBuilder.UseMySQL("Server=localhost;port=3306;User ID=root; Database=Empleados23BM");
        }
        //Mapeo de la BD
        public DbSet<Empleado> Empleados { get; set; }

    }
}
