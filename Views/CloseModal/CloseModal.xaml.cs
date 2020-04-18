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

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para CloseModal.xaml
    /// </summary>
    public partial class CloseModal : Window
    {
        public CloseModal()
        {
            InitializeComponent();
        }

        private void BtnYes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
