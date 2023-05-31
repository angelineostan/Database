using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Security.Policy;

namespace DatabaseAttempt
{
    internal class Class1
    {
        public static string dbconnect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\DBostan.mdb";
        public static OleDbConnection con = new OleDbConnection(dbconnect);

        public static void DB()
        {
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
