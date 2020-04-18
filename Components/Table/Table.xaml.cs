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
    /// Lógica de interacción para Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {

        private double firstXpos, firstYpos, firstArrowXpos, firstArrowYpos;
        private object MovingObject;
        public TableModel tableModel = new TableModel();

        public Table()
        {
            InitializeComponent();
            DataContext = tableModel;
        }

        private void UserControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e) => MovingObject = null;

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            firstXpos = e.GetPosition(sender as Control).X;
            firstYpos = e.GetPosition(sender as Control).Y;
            firstArrowXpos = e.GetPosition((sender as Control).Parent as Control).X - firstXpos;
            firstArrowYpos = e.GetPosition((sender as Control).Parent as Control).Y - firstYpos;

            MovingObject = sender;
        }

        private void BtnEditTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => new EditTableNameModal(tableModel).ShowDialog();

        private void BtnRemoveTable_Click(object sender, RoutedEventArgs e)
        {
            ((Canvas)Parent).Children.Remove(this);
        }

        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (MovingObject != null)
                {
                    (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty, e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - firstXpos);
                    (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty, e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - firstYpos);
                }

                else
                {
                    MovingObject = null;
                }
            }
        }

        private void BtnAddValue_Click(object sender, RoutedEventArgs e)
        {
            wrapper.Children.Add(new Value()
            {
                Margin = new Thickness(0, 3, 0, 0)
            });

            tableModel.Values = GetValueModels();
        }

        public List<ValueModel> GetValueModels()
        {
            List<ValueModel> valueModels = new List<ValueModel>();

            foreach (Value item in wrapper.Children)
            {
                valueModels.Add(item.valueModel);
            }

            return valueModels;
        }
    }
}
