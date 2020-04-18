using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para SucessModal.xaml
    /// </summary>
    public partial class SucessModal : Window
    {
        public SucessModal()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:\Users\" + Environment.UserName + "\\Scripts");
            Close();
        }
    }
}
