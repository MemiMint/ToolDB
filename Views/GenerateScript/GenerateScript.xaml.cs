using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ToolDB.Controllers;
using ToolDB.Models;
using System.IO;

namespace ToolDB
{
    /// <summary>
    /// Lógica de interacción para GenerateScript.xaml
    /// </summary>
    public partial class GenerateScript : Window
    {
        private DatabaseModel databaseModel; 
        private DatabaseController databaseController = new DatabaseController();

        public GenerateScript(DatabaseModel model)
        {
            InitializeComponent();
            databaseModel = model;
        }

        private void BtnSqlServer_MouseEnter(object sender, MouseEventArgs e) => ShowSqlType(new BitmapImage(new Uri(@"Resources/icons8-windows-10-100.png", UriKind.Relative)), "Sql Server");

        private void BtnSqlServer_MouseLeave(object sender, MouseEventArgs e) => SqlType.Visibility = Visibility.Hidden;

        private void BtnMySql_MouseEnter(object sender, MouseEventArgs e) => ShowSqlType(new BitmapImage(new Uri(@"Resources/icons8-logo-de-mysql-100 (1).png", UriKind.Relative)), "MySql");

        private void BtnMySql_MouseLeave(object sender, MouseEventArgs e) => SqlType.Visibility = Visibility.Hidden;

        private void BtnClose_Click(object sender, RoutedEventArgs e) => Close();

        private void BtnSqlServer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                databaseController.GenerateScript(() =>
                {
                    string directoryPath = @"C:\Users\" + Environment.UserName + "\\Scripts";
                    string filePath = @"C:\Users\"+Environment.UserName+"\\Scripts\\"+databaseModel.Name+".sql";

                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.WriteLine("CREATE DATABASE '" + databaseModel.Name + "'");

                        foreach (TableModel table in databaseModel.Tables)
                        {
                            writer.WriteLine("CREATE TABLE '" + table.TableName + "'(");

                            foreach (ValueModel value in table.Values)
                            {
                                if (value.PrimaryKey)
                                {
                                    writer.WriteLine("\t['" + value.ValueName + "'] ['" + value.Type + "'] PRIMARY KEY IDENTITY,");
                                }

                                else
                                {
                                    if (value.IsNull)
                                    {
                                        writer.WriteLine("\t['" + value.ValueName + "'] ['" + value.Type + "'] NOT NULL,");
                                    }

                                    else
                                    {
                                        writer.WriteLine("\t['" + value.ValueName + "'] ['" + value.Type + "'] NULL,");
                                    }
                                }

                            }

                            writer.WriteLine(")");
                        }

                        foreach (StoreProcedureModel storeProcedure in databaseModel.storeProcedures)
                        {
                            writer.WriteLine(storeProcedure.Script);
                        }
                    }

                    new SucessModal().ShowDialog();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnMySql_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                databaseController.GenerateScript(() =>
                {
                    string directoryPath = @"C:\Users\" + Environment.UserName + "\\Scripts";

                    string filePath = @"C:\Users\"+Environment.UserName+"\\Scripts\\"+databaseModel.Name+".sql";

                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.WriteLine("DROP DATABASE IF EXISTS '" + databaseModel.Name + "'");
                        writer.WriteLine("CREATE DATABASE '" + databaseModel.Name + "'");
                        writer.WriteLine("USE '" + databaseModel.Name + "';");

                        foreach (TableModel table in databaseModel.Tables)
                        {
                            writer.WriteLine("CREATE TABLE '"+table.TableName+"' (");

                            foreach (ValueModel value in table.Values)
                            {
                                if (value.PrimaryKey)
                                {
                                    writer.WriteLine("\t" + value.ValueName + " " + value.Type + " NOT NULL AUTO_INCREMENT PRIMARY KEY");
                                }

                                else
                                {
                                    if (value.IsNull)
                                    {
                                        writer.WriteLine("\t" + value.ValueName + " " + value.Type + " NOT NULL");
                                    }

                                    else
                                    {
                                        writer.WriteLine("\t" + value.ValueName + " " + value.Type + " NULL");
                                    }
                                }
                            }

                            writer.WriteLine(")");
                        }

                        foreach (StoreProcedureModel storeProcedure in databaseModel.storeProcedures)
                        {
                            writer.WriteLine(storeProcedure.Script);
                        }
                    }

                    new SucessModal().ShowDialog();
                });
            }

            catch (Exception)
            {
                new WarningModal("There Was An Error").ShowDialog();
            }
        }

        private Visibility ShowSqlType(BitmapImage sqlTypeLogo, string sqlName)
        {
            sqlTypeImage.Source = sqlTypeLogo;
            sqlTypeName.Text = sqlName;

            return SqlType.Visibility == Visibility.Hidden ? SqlType.Visibility = Visibility.Visible : SqlType.Visibility = Visibility.Hidden;
        }
    }
}
