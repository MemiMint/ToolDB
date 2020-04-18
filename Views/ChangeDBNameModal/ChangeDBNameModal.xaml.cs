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
    /// Lógica de interacción para ChangeDBNameModal.xaml
    /// </summary>
    public partial class ChangeDBNameModal : Window
    {
        private DatabaseController databaseController = new DatabaseController();
        private DatabaseModel DatabaseModel;

        public ChangeDBNameModal(DatabaseModel model)
        {
            InitializeComponent();
            DatabaseModel = model;
        }

        private void BtnChangeDatabaseName_Click(object sender, RoutedEventArgs e)
        {
            if (txtDatabaseName.Text == string.Empty)
            {
                new WarningModal("Empty Fields Are not allowed").ShowDialog();
            }

            else
            {
                DatabaseModel.Name = databaseController.SetDatabaseName(txtDatabaseName.Text);
                Close();
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();
    }
}
