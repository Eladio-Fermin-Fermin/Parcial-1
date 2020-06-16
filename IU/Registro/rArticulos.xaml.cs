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
    private Articulos articulos = new Articulos();
        public Formulario()
        {
            InitializeComponent();
            this.DataContext = articulos;
        }

        private void Limpiar()
        {
            this.articulos = new Articulos();
            this.DataContext = articulos;
        }

        private bool Validar()
        {
            bool valido = true;

            if(ArticuloIdTextBox.Text.Length == 0 || DescripcionTextBox.Text.Length == 0)
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
