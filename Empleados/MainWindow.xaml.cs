using Empleados.Entities;
using Empleados.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Empleados23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
            EmpleadoServices services = new EmpleadoServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Correo = txtCorreo.Text,
                FechaRegistro = DateTime.Now,
            };
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Faltan campos");
            }
            else
            {
                services.Add(empleado);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                MessageBox.Show("Registrado");
            }
        }
        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            Empleado empleado = services.Red(Id);
            txtId.Text = empleado.PkEmpleado.ToString();
            txtNombre.Text = empleado.Nombre.ToString();
            txtApellido.Text = empleado.Apellido.ToString();
            txtCorreo.Text = empleado.Correo.ToString();
            txtFecha.Text = empleado.FechaRegistro.ToString();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Falta ID");
            }
            else
            {
                services.Delete(Id);
                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                txtFecha.Clear();
                MessageBox.Show("Eliminado exitosamente!!");
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int Id = int.Parse(txtId.Text);

            

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Faltan acmpos");
            }
            else
            {
                Empleado empleado = new Empleado();
                empleado.PkEmpleado = Id;
                empleado.Nombre = txtNombre.Text;
                empleado.Apellido = txtApellido.Text;
                empleado.Correo = txtCorreo.Text;
                empleado.FechaRegistro = DateTime.Now;
                services.Update(empleado);

                txtNombre.Clear();
                txtApellido.Clear();
                txtCorreo.Clear();
                txtFecha.Clear();
                MessageBox.Show("Modificación correcta");
            }
        }

        private void BtnRestart_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtFecha.Clear();
            txtId.Clear();
        }
    }
}
