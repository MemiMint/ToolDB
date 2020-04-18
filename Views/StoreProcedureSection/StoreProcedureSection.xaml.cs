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
    /// Lógica de interacción para StoreProcedureSection.xaml
    /// </summary>
    public partial class StoreProcedureSection : Window
    {

        public StoreProcedureSection(List<StoreProcedureModel> model)
        {
            InitializeComponent();

            if (model.Count < 1)
            {
                lblNoProcedures.Visibility = Visibility.Visible;
            }

            else
            {
                foreach (StoreProcedureModel item in model)
                {
                    wrapper.Children.Add(new StoreProcedure(item, model)
                    {
                        lblProcedureName = { Text = item.Name },
                        Margin = new Thickness(0, 0, 5, 5)
                    });
                }
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
