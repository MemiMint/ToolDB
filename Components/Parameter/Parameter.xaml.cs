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
using ToolDB.Models;

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para Parameter.xaml
    /// </summary>
    public partial class Parameter : UserControl
    {
        public ParameterModel model = new ParameterModel();

        public Parameter()
        {
            InitializeComponent();
            DataContext = model;
        }

        private void BtnRemoveParameter_Click(object sender, RoutedEventArgs e)
        {
            ((WrapPanel)Parent).Children.Remove(this);
        }

        private void BtnEditValue_Click(object sender, RoutedEventArgs e)
        {
            new EditParameterModal(model).ShowDialog();
        }
    }
}
