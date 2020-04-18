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
using System.Text.RegularExpressions;
using ToolDB.Models;
using ToolDB.Controllers;

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para AddStoreProcedure.xaml
    /// </summary>
    public partial class AddStoreProcedure : Window
    {
        public StoreProcedureModel model = new StoreProcedureModel();
        private StoreProcedureController controller = new StoreProcedureController();
        private List<StoreProcedureModel> storeProcedures;

        public AddStoreProcedure(List<StoreProcedureModel> procedures)
        {
            InitializeComponent();
            DataContext = model;
            storeProcedures = procedures;
            txtScript.Text = GenerateScriptPlaceholder();
        }

        private void BtnAddParameter_Click(object sender, RoutedEventArgs e) => AddParameter();

        private void BtnCreateProcedure_Click(object sender, RoutedEventArgs e)
        {
            if ((txtProcedureName.Text == string.Empty || txtProcedureName.Text == "Procedure Name") || (txtScript.Text == string.Empty || txtScript.Text == GenerateScriptPlaceholder()))
            {
                new WarningModal("Empty fields are not allowed").ShowDialog();
            }

            else
            {
                CreateProcedure();
            }
        }

        private void BtnClean_Click(object sender, RoutedEventArgs e) => Clean();

        private void BtnChangeProcedureName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => EnableTextbox(false);

        private void TxtProcedureName_KeyDown(object sender, KeyEventArgs e) => EnterIsPressed(e);

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void EnableTextbox(bool enabled)
        {
            switch (enabled)
            {   
                case true:
                    txtProcedureName.IsReadOnly = enabled;
                    txtProcedureName.Background = Brushes.Transparent;
                    txtProcedureName.BorderBrush = Brushes.Transparent;
                    txtProcedureName.Foreground = Brushes.White;
                    break;

                case false:
                    txtProcedureName.IsReadOnly = enabled;
                    txtProcedureName.Background = Brushes.White;
                    txtProcedureName.BorderBrush = Brushes.White;
                    txtProcedureName.Foreground = Brushes.CornflowerBlue;
                    break;
            }
        }

        private void CreateProcedure()
        {
            List<ParameterModel> parameters = new List<ParameterModel>();

            foreach (Parameter item in wrapper.Children)
            {
                parameters.Add(new ParameterModel() {
                    Name = item.lblParameter.Content.ToString(),
                    Type = item.cmbValueType.Text
                });
            }

            model.Name = txtProcedureName.Text;
            model.Script = txtScript.Text;
            model.parameters = controller.Parameters(parameters);

            storeProcedures.Add(model);

            Close();
        }

        private void AddParameter()
        {
            wrapper.Children.Add(new Parameter()
            {
                Margin = new Thickness(0, 3, 0, 0)
            });
        }

        private void Clean()
        {
            txtProcedureName.Text = "Procedure Name";
            txtScript.Text = "";
            wrapper.Children.Clear();
        }

        private void EnterIsPressed(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EnableTextbox(true);
            }
        }

        private string GenerateScriptPlaceholder()
        {
            return "CREATE PROCEDURE ProcedureName(\n)\nAS\nBEGIN\nEND";
        }
    }
}
