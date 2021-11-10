using Perla_AP2_API_20190008.BLL;
using Perla_AP2_API_20190008.Entidades;
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
using System.Windows.Shapes;

namespace Perla_AP2_API_20190008.UI.Registros
{
    /// <summary>
    /// Lógica de interacción para rCompras.xaml
    /// </summary>
    public partial class rCompras : Window
    {
        private Compras compras = new Compras();
        public rCompras()
        {
            InitializeComponent();
            IniciarCombobox();
            Limpiar();
        }
        private void IniciarCombobox()
        {
            ArticulosComboBox.ItemsSource = ArticulosBLL.GetList();
            ArticulosComboBox.SelectedValuePath = "ArticuloId";
            ArticulosComboBox.DisplayMemberPath = "Descripcion";
            Limpiar();
        }
        private void Cargar()
        {
            CostoTextBox.Clear();
            CantidadTextBox.Clear();
            this.DataContext = null;
            this.DataContext = compras;
            TotalTextBox.Text = compras.Total.ToString();
        }
        private void Limpiar()
        {
            this.compras = new Compras();
            this.compras.Fecha = DateTime.Now;
            this.DataContext = compras;
            TotalTextBox.Clear();
        }
        private bool ValidarAgregar()
        {
            bool esValido = true;
            if (CostoTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el costo", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (CantidadTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Inserte la Cantidad", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (ArticulosComboBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Seleccione un Articulo", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (ImporteTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Inserte una cantidad", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return esValido;
        }
        private bool ValidarGuardar()
        {
            bool esValido = true;
            if (DatosDataGrid.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Debe agregar tareas", "Advertencia",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Compras encontrado = ComprasBLL.Buscar(compras.ComprasId);

            if (encontrado != null)
            {
                compras = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "Mensaje",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar())
                return;
            compras.Total += Convert.ToInt32(CostoTextBox.Text);

            compras.Detalle.Add(new ComprasDetalle(compras.ComprasId,
                Convert.ToInt32(ArticulosComboBox.SelectedValue.ToString()),
                Convert.ToInt32(CostoTextBox.Text),
                CantidadTextBox.Text.ToString()));

            Cargar();
        }

        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if (DatosDataGrid.Items.Count >= 1 && DatosDataGrid.SelectedIndex <= DatosDataGrid.Items.Count - 1)
            {
                ComprasDetalle m = (ComprasDetalle)DatosDataGrid.SelectedValue;
                compras.Total -= m.Cantidad;
                compras.Detalle.RemoveAt(DatosDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Compras esValido = ComprasBLL.Buscar(compras.ComprasId);

            return (esValido != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarGuardar())
                return;
            bool paso = false;

            if (compras.ComprasId == 0)
                paso = ComprasBLL.Guardar(compras);
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = ComprasBLL.Guardar(compras);
                }

                else
                    MessageBox.Show("No existe en la base de datos", "Información");
            }
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Compras existe = ComprasBLL.Buscar(compras.ComprasId);

            if (existe == null)
            {
                MessageBox.Show("No existe el proyecto en la base de datos", "Mensaje",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
               ComprasBLL.Eliminar(compras.ComprasId);
                MessageBox.Show("Eliminado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
        }
    }
}
