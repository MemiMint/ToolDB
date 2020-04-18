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
    /// Lógica de interacción para EditTableNameModal.xaml
    /// </summary>
    public partial class EditTableNameModal : Window
    {
        private TableController tableController = new TableController();
        private TableModel table;

        public EditTableNameModal(TableModel model)
        {
            InitializeComponent();
            table = model;
        }

        private void BtnChangeTableName_Click(object sender, RoutedEventArgs e)
        {
            if (txtTableName.Text == string.Empty)
            {
                new WarningModal("Empty Fields Are Not Allowed").ShowDialog();
            }

            else
            {
                EditTableName();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void EditTableName()
        {
            table.TableName = tableController.SetTableName(txtTableName.Text);
            Close();
        }
    }
}
