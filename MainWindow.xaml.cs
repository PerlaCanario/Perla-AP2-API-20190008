using Perla_AP2_API_20190008.UI.Consultas;
using Perla_AP2_API_20190008.UI.Registros;
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

namespace Perla_AP2_API_20190008
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

        private void rComprasItem_Click(object sender, RoutedEventArgs e)
        {
            new rCompras().Show();
        }

        private void cComprasItem_Click(object sender, RoutedEventArgs e)
        {
            new cCompras().Show();
        }

        private void cArticulosItem_Click(object sender, RoutedEventArgs e)
        {
            new cArticulos().Show();
        }
    }
}
