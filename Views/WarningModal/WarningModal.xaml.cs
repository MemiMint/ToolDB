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
    /// Lógica de interacción para WarningModal.xaml
    /// </summary>
    public partial class WarningModal : Window
    {
        public WarningModal(string message)
        {
            InitializeComponent();
            lblWarning.Text = message;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e) => Close();
    }
}
