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
using ToolDB.Controllers;
namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para Value.xaml
    /// </summary>
    public partial class Value : UserControl
    {
        public ValueModel valueModel = new ValueModel();
        private ValueController valueController = new ValueController();

        public Value()
        {
            InitializeComponent();
            DataContext = valueModel;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            valueModel.IsNull = valueController.SetNullableValue(true);
        }

        private void BtnPrimaryKey_Click(object sender, RoutedEventArgs e)
        {
            switch (valueModel.PrimaryKey)
            {
                case true:
                    valueModel.PrimaryKey = valueController.SetPrimaryKey(false);
                    break;
                case false:
                    valueModel.PrimaryKey = valueController.SetPrimaryKey(true);
                    break;
            }

            PrimaryValue();
        }

        private void BtnEditValue_Click(object sender, RoutedEventArgs e) => new EditValueModal(valueModel).ShowDialog();

        private void PrimaryValue()
        {
            switch (valueModel.PrimaryKey)
            {
                case true:
                    State(Brushes.Gold);
                    break;
                case false:
                    State(Brushes.CornflowerBlue);
                    break;
            }
        }

        private void State(Brush brush)
        {
            Brush brusher = brush;

            valueCell.BorderBrush = brush;
            lblValue.Foreground = brush;
            btnPrimaryKey.Background = brush;
            chkboxIsNull.Foreground = brush;
            chkboxIsNull.BorderBrush = brush;
            cmbValueType.Foreground = brush;
            cmbValueType.BorderBrush = brush;
            Resources["DynamicColor"] = brush;

            foreach (ComboBoxItem item in cmbValueType.Items)
            {
                item.Foreground = brush;
            }

            if (valueModel.PrimaryKey)
            {
                btnPrimaryKey.Background = brush;
                Key.Source = new BitmapImage(new Uri(@"../../Resources/icons8-contraseña-blanco-60.png", UriKind.Relative));
                chkboxIsNull.IsChecked = true;
            }

            else
            {
                btnPrimaryKey.Background = Brushes.Transparent;
                Key.Source = new BitmapImage(new Uri(@"../../Resources/icons8-contraseña-1-60.png", UriKind.Relative));
            }
        }

        private void CmbValueType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            valueModel.Type = ((ComboBoxItem)cmbValueType.SelectedItem).Content.ToString();
        }
    }
}
