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
    /// Lógica de interacción para StoreProcedure.xaml
    /// </summary>
    public partial class StoreProcedure : UserControl
    {
        private StoreProcedureModel model;
        private List<StoreProcedureModel> procedures;

        public StoreProcedure(StoreProcedureModel storeProcedure, List<StoreProcedureModel> storeProcedures)
        {
            InitializeComponent();
            model = storeProcedure;
            procedures = storeProcedures;
        }

        private void BtnEditProcedure_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
            new EditStoreProcedure(model).ShowDialog();
        }

        private void BtnRemoveStoreProcedure_Click(object sender, RoutedEventArgs e)
        {
            RemoveProcedure();
        }

        private void RemoveProcedure()
        {
            ((WrapPanel)Parent).Children.Remove(this);
            procedures.Remove(model);
        }
    }
}
