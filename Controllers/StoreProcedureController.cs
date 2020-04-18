using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ToolDB.Controllers
{
    public class StoreProcedureController
    {
        /*
         * StoreProcedureController is the class that changes store procedure's values
         * -- methods --
         * -- SetProcedureName: type string method that returns the name of the store procedure --
         * -- SetScript: type string method that returns the script of the store procedure --
         * -- Parameters: type List<ParameterModels> method that return a list of parameter to the store procedure --
         */

        public string SetProcedureName(string name)
        {
            return name;
        }

        public string SetScript(string script)
        {
            return script;
        }

        public List<Models.ParameterModel> Parameters(List<Models.ParameterModel> parameters)
        {
            return parameters;
        }
    }
}
