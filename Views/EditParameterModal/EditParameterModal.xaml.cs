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
using ToolDB.Controllers;
using ToolDB.Models;

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para EditParameterModal.xaml
    /// </summary>
    public partial class EditParameterModal : Window
    {
        private ParameterModel parameter;
        private ParameterController Controller = new ParameterController();

        public EditParameterModal(ParameterModel model)
        {
            InitializeComponent();
            parameter = model;
        }

        private void BtnChangeParameterName_Click(object sender, RoutedEventArgs e)
        {
            if (txtParameterName.Text == string.Empty)
            {
                new WarningModal("Empty fields are now allowed").ShowDialog();
            }

            else
            {
                parameter.Name = Controller.SetParameterName(txtParameterName.Text);
                Close();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
    }
}
