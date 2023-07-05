using Empleados.Context;
using Empleados.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Empleados.Services
{
    public class EmpleadoServices
    {
        public void Add(Empleado request)
        {
			try
            {   //Habre la cadena de conexion y todo lo que se encuentre en using entrará a la DB
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = new Empleado()
                    {
                        Nombre = request.Nombre,
                        Apellido = request.Apellido,
                        Correo = request.Correo,
                        FechaRegistro = DateTime.Now,
                    };
                    _context.Empleados.Add(empleado);
                    _context.SaveChanges();
                }
			}
			catch (Exception ex)
			{
				throw new Exception("Sucedió un error" + ex.Message);
			}
        }
        public Empleado Red (int Id)
        {
            try
            {
                Empleado empleado = new Empleado();
                using (var _context = new ApplicationDbContext())
                {
                    empleado = _context.Empleados.FirstOrDefault(x => x.PkEmpleado == Id);
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }
        public void Delete(int Id)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado empleado = _context.Empleados.Find(Id);
                    if (empleado != null)
                    {
                        _context.Empleados.Remove(empleado);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("NO HAY REGISTRO");
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ERROR: " + ex.Message);
            }
        }
        public void Update(Empleado request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Empleado update = _context.Empleados.Find(request.PkEmpleado);
                    update.Nombre = request.Nombre;
                    update.Apellido = request.Apellido;
                    update.Correo = request.Correo;
                    update.FechaRegistro = request.FechaRegistro;
                    _context.Empleados.Update(update);
                    //_context.Entry(update).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }
    }
}
