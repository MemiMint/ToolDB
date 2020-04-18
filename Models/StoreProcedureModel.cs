using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolDB.Models
{
    /*
     * StoreProcedureModel is the class that contains all the data stored in a storeProcedure
     * store procedure's name, script and parameters are stored in this class
     */

    public class StoreProcedureModel
    {
        private string name = "Procedure Name"; //set as default "Procedure Name" in case that doesn't have a name

        private string script;

        public string Name //store procedure's name
        {
            get { return name; }

            set { name = value; }
        }

        public string Script //store procedure's script
        {
            get { return script; }

            set { script = value; }
        }

        public List<ParameterModel> parameters = new List<ParameterModel>(); //list that stores all the parameters in a stored procedure
    }
}
