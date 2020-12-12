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

namespace Weather_GUI
{
    /// <summary>
    /// Interaktionslogik für Select.xaml
    /// </summary>
    public partial class Select : Window
    {
        public Select()
        {
            InitializeComponent();
        }

        private void Current_Click(object sender, RoutedEventArgs e)
        {
            Weather_Now w = new Weather_Now();
            w.Show();
        }

        private void Forecast_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
        }
    }
}
