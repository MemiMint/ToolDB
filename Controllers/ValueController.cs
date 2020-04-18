using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolDB.Controllers
{
    /*
     * ValueController is the class that changes value's data
     * -- methods --
     * -- SetValueName: type string method that returns value's name --
     * -- SetPrimaryKey: type bool method that sets if the value should be primary key --
     * -- SetTypeValue: type string method that returns value's type (INT, VARCHAR, BIT ...etc) --
     * -- SetNullableValue: type bool method that sets the value's nullability --
     */

    class ValueController
    {
        public string SetValueName(string name)
        {
            return name;
        }

        public bool SetPrimaryKey(bool isPrimaryKey)
        {
            return isPrimaryKey;
        }

        public string SetTypeValue(string type)
        {
            return type;
        }

        public bool SetNullableValue(bool isNull)
        {
            return isNull;
        }
    }
}
