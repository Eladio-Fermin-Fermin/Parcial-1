using Parcial1.BLL;
using Parcial1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Parcial1.IU.Registro
{
    /// <summary>
    /// Interaction logic for Formulario.xaml
    /// </summary>
    public partial class Formulario : Window
    {
        private Entidades.Articulos articulos = new Entidades.Articulos();

        public Formulario()
        {
            InitializeComponent();
            this.DataContext = articulos;
        }

        private void Limpiar()
        {
            this.articulos = new Entidades.Articulos();
            this.DataContext = articulos;
        }

        //Metodo Validar.
        private bool Validar()
        {
            bool valido = true;

            if (ArticuloIdTextBox.Text.Length == 0 || DescripcionTextBox.Text.Length == 0 || ExistenciaTextBox.Text.Length == 0) 
            {
                valido = false;
                MessageBox.Show("Verifique que no allá campos vacíos.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
            else if (ArticuloIdTextBox.Text.Length == 0)
            {
                valido = false;
                MessageBox.Show("Ingrese un Articulo Id valido.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return valido;

        }

        //Boton Buscar.
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var articulos = ArticulosBLL.Buscar(int.Parse(ArticuloIdTextBox.Text));
            if (articulos != null)
            {
                this.articulos = articulos;
            }
            else
            {
                this.articulos = new Entidades.Articulos();
            }
            this.DataContext = this.articulos;
        }

        //Boto Nuevo.
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

            Limpiar();

        }

        //Boton Guardar
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }
                
            var paso = ArticulosBLL.Guardar(articulos);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Se completo con existo!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se Completo exitosamente.", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Boton Eliminar.
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if(ArticulosBLL.Eliminar(int.Parse(ArticuloIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Articulo Eliminado con existo!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se pudo Eliminar el Articuo con existo", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TextChanged();
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TextChanged();
        }

        /*private int TextChanged()
        {
            int valorInvertario, existente, costo;
            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text) || ExistenciaTextBox.Text == "0")
            {
                ExistenciaTextBox.Text = "0";
            }
           
        }*/

    }
}
