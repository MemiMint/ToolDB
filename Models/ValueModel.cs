using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ToolDB.Models
{
    /*
     * ValueModel is the class that contains all the data about a value into a table
     * value's name, type, primary key and is nullability are stored in this class
     */

    public class ValueModel : INotifyPropertyChanged
    {
        private string valueName = "Value"; //set as default "Value" in case that doesn't have a name

        private string type; 

        private bool primaryKey = false;

        private bool isNull;

        public string ValueName //value's name
        {
            get
            {
                return valueName;
            }

            set
            {
                if (valueName != value)
                {
                    valueName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("valueName"));
                }
            }
        }

        public string Type //value's type (INT, VARCHAR, BIT ...etc)
        {
            get
            {
                return type;
            }

            set
            {
                if (type != value)
                {
                    type = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("type"));
                }
            }
        }

        public bool PrimaryKey //set if value should be primary key (if value is primary key it will be auto incremented by default)
        {
            get
            {
                return primaryKey;
            }

            set
            {
                if (primaryKey != value)
                {
                    primaryKey = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("primaryKey"));
                }
            }
        }

        public bool IsNull //set nullability's value (if value is primary key it will be not null by default)
        {
            get
            {
                return isNull;
            }

            set
            {
                isNull = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isNull"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; //event handler that notifies the view any changes
    }
}
