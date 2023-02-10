using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stdrecors
{
    internal class dbaccess
    {
        public string GetConnection()
        {
            string con = "Data Source=.;Initial Catalog=studentrecord;Integrated Security=True";
            return con;
        }
    }
}
