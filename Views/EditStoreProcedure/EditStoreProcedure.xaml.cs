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
using ToolDB.Models;

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para EditStoreProcedure.xaml
    /// </summary>
    public partial class EditStoreProcedure : Window
    {
        private StoreProcedureModel storeProcedure;

        public EditStoreProcedure(StoreProcedureModel model)
        {
            InitializeComponent();

            storeProcedure = model;
            txtProcedureName.Text = model.Name;
            txtScript.Text = model.Script;

            foreach (ParameterModel parameter in model.parameters)
            {
                wrapper.Children.Add(new Parameter()
                {
                    lblParameter = { Content = parameter.Name },
                    cmbValueType = { Text = parameter.Type },
                    Margin = new Thickness(0, 0, 0, 3)
                });
            }
        }

        private void BtnEditProcedure_Click(object sender, RoutedEventArgs e)
        {
            if (txtProcedureName.Text == string.Empty || txtScript.Text == string.Empty)
            {
                new WarningModal("Empty fields are now allowed").ShowDialog();
            }

            else
            {
                EditProcedure();
            }
        }

        private void TxtProcedureName_KeyDown(object sender, KeyEventArgs e) => EnterIsPressed(e);

        private void BtnChangeProcedureName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => EnableKeyboard(false);

        private void BtnAddParameter_Click(object sender, RoutedEventArgs e) => AddParemeter();

        private void BtnClean_Click(object sender, RoutedEventArgs e) => Clean();

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void Clean()
        {
            wrapper.Children.Clear();
            txtProcedureName.Text = "Procedure Name";
            txtScript.Clear();
        }

        private void EnableKeyboard(bool enabled)
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

        private void AddParemeter()
        {
            wrapper.Children.Add(new Parameter() {
                Margin = new Thickness(0, 0, 0, 3)
            });
        }

        private void EditProcedure()
        {
            storeProcedure.Name = txtProcedureName.Text;
            storeProcedure.Script = txtScript.Text;
            storeProcedure.parameters.Clear();

            foreach (Parameter parameter in wrapper.Children)
            {
                storeProcedure.parameters.Add(new ParameterModel()
                {
                    Name = parameter.lblParameter.Content.ToString(),
                    Type = parameter.cmbValueType.Text
                });
            }

            Close();
        }

        private void EnterIsPressed(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EnableKeyboard(true);
            }
        }
    }
}
