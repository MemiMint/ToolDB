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
using System.ComponentModel;
using ToolDB.Models;
using ToolDB.Controllers;

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DatabaseModel databaseModel = new DatabaseModel();
        private DatabaseController DatabaseController = new DatabaseController();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = databaseModel;
            
        }

        private void BtnEditDatabaseName_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => new ChangeDBNameModal(databaseModel).ShowDialog();

        private void BtnCreateProcedure_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => new AddStoreProcedure(databaseModel.storeProcedures).ShowDialog();

        private void BtnComment_MouseEnter(object sender, MouseEventArgs e) => IsVisible(commentIndicator);

        private void BtnComment_MouseLeave(object sender, MouseEventArgs e) => IsVisible(commentIndicator);

        private void BtnCreateProcedure_MouseEnter(object sender, MouseEventArgs e) => IsVisible(procedureIndicator);

        private void BtnCreateProcedure_MouseLeave(object sender, MouseEventArgs e) => IsVisible(procedureIndicator);

        private void BtnGenerateScript_MouseEnter(object sender, MouseEventArgs e) => IsVisible(scriptIndicator);

        private void BtnGenerateScript_MouseLeave(object sender, MouseEventArgs e) => IsVisible(scriptIndicator);

        private void BtnCleanData_MouseEnter(object sender, MouseEventArgs e) => IsVisible(cleanIndicator);

        private void BtnCleanData_MouseLeave(object sender, MouseEventArgs e) => IsVisible(cleanIndicator);

        private void BtnCreateTable_Click(object sender, RoutedEventArgs e) => CreateTable();

        private void BtnEditDatabaseName_MouseEnter(object sender, MouseEventArgs e) => IsVisible(databaseIndicator);

        private void BtnEditDatabaseName_MouseLeave(object sender, MouseEventArgs e) => IsVisible(databaseIndicator);

        private void BtnProcedureSection_MouseEnter(object sender, MouseEventArgs e) => IsVisible(proceduresIndicator);

        private void BtnProcedureSection_MouseLeave(object sender, MouseEventArgs e) => IsVisible(proceduresIndicator);

        private void BtnExit_MouseEnter(object sender, MouseEventArgs e) => IsVisible(exitIndicator);

        private void BtnExit_MouseLeave(object sender, MouseEventArgs e) => IsVisible(exitIndicator);

        private void BtnExit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => new CloseModal().ShowDialog();

        private void BtnProcedureSection_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => new StoreProcedureSection(this.databaseModel.storeProcedures).ShowDialog();

        private void BtnGenerateScript_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => new GenerateScript(databaseModel).ShowDialog();

        private void BtnCleanData_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => CleanData();

        private void BtnComment_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => AddComment();

        private new Visibility IsVisible(Border navIndicator) => navIndicator.Visibility == Visibility.Visible ? navIndicator.Visibility = Visibility.Hidden : navIndicator.Visibility = Visibility.Visible;

        private void AddComment() => mainPanel.Children.Add(new Comment());

        private void CleanData()
        {
            mainPanel.Children.Clear();
            databaseModel.Tables.Clear();
            databaseModel.Name = "Database Name";
            databaseModel.storeProcedures.Clear();
        }

        private void CreateTable()
        {
            mainPanel.Children.Add(new Table());
            databaseModel.Tables = GetTableModels();
        }

        private List<TableModel> GetTableModels()
        {
            List<TableModel> tables = new List<TableModel>();

            foreach (Table table in mainPanel.Children)
            {
                tables.Add(table.tableModel);
            }

            return tables;
        }
    }

}
