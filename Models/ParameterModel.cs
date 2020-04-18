using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolDB.Models
{
    /*
     * ParameterModel is the class that contains all the information about the parameters stored in a storeProcedure
     * the parameter's name and type are stored in this class
     */

    public class ParameterModel : INotifyPropertyChanged
    {
        private string name = "Parameter"; //set as default "Parameter" in case that doesn't have a name

        private string type;

        public string Name  //parameter's name
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

        public string Type //parameter's type
        {
            get { return type; }

            set { type = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged; //event handler that notifies any change to the view
    }
}
