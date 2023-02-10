using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAttendance
{
    internal class Connectiondb
    {
        public string GetConnection()
        {
            string con = "Data Source=.;Initial Catalog=studentrecord;Integrated Security=True";
            return con;
        }
    }
}
