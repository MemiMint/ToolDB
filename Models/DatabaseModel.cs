using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ToolDB.Models
{
    /*
     * DatabaseModel is the script basic's data 
     * the database name, tables and store procedures are stored in this class
     */

    public class DatabaseModel : INotifyPropertyChanged
    {
        private string name = "Database Name"; // set as default value "database name" in case that doesn't have a name

        public string Name //database name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public List<TableModel> Tables = new List<TableModel>(); //list that stores every table in the program

        public List<StoreProcedureModel> storeProcedures = new List<StoreProcedureModel>(); //list that stores every store procedure in the program

        public event PropertyChangedEventHandler PropertyChanged; //event handler that notifies any change to the view
    }
}
