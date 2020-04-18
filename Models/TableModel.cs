using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ToolDB.Models
{
    /*
     * TableModel is the class that contains all the data stored in a table
     * table's name and values are stored in this class
     */

    public class TableModel : INotifyPropertyChanged
    {
        private string tableName = "Table Name"; //set as default "Table Name" in case that doesn't have a name

        public string TableName //table's name
        {
            get
            {
                return tableName;
            }

            set
            {
                tableName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("tableName"));
            }
        }

        public List<ValueModel> Values = new List<ValueModel>(); //list that stores all the values in a table

        public event PropertyChangedEventHandler PropertyChanged; //event handler that notifies any change to the view
    }
}
