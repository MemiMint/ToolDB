using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolDB.Models;

namespace ToolDB.Controllers
{
    public class DatabaseController
    {
        /*
         * DatabaseController is the class that changes database's data
         * -- methods --
         * -- SetDatabaseName: type string method that returns the name of the database --
         * -- GenerateScript: generates the .sql file throught a callback function --
         */

        public string SetDatabaseName(string name)
        {
            return name;
        }

        public void GenerateScript(Action callback)
        {
            callback();
        }
    }
}
