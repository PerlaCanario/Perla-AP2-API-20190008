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

namespace Perla_AP2_API_20190008.UI.Consultas
{
    /// <summary>
    /// Lógica de interacción para cArticulos.xaml
    /// </summary>
    public partial class cArticulos : Window
    {
        public cArticulos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Articulos>();
            string criterio = CriterioTextBox.Text.Trim();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ArticulosBLL.GetList(p => true);
                        break;
                    case 1:
                        listado = ArticulosBLL.GetList(p => p.Descripcion.ToLower().Contains(criterio.ToLower()));
                        break;
                    case 2:
                        listado = ArticulosBLL.GetList(p => p.ArticuloId == Convert.ToInt32(CriterioTextBox.Text));
                        break;
                }
            }
            else
            {
                listado = ArticulosBLL.GetList(p => true);
            }


            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
