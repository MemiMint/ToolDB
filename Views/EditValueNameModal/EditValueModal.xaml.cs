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
    /// Lógica de interacción para EditValueModal.xaml
    /// </summary>
    public partial class EditValueModal : Window
    {
        private ValueController valueController = new ValueController();
        private ValueModel Value;

        public EditValueModal(ValueModel model)
        {
            InitializeComponent();
            Value = model;
        }

        private void BtnChangeValueName_Click(object sender, RoutedEventArgs e)
        {
            if (txtValueName.Text == string.Empty)
            {
                new WarningModal("Empty Fields Are Not Allowed").ShowDialog();
            }

            else
            {
                EditValueName();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void EditValueName()
        {
            Value.ValueName = valueController.SetValueName(txtValueName.Text);
            Close();
        }
    }
}
