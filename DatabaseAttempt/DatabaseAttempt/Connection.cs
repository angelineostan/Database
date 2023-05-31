using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseAttempt
{
    public partial class Connection : Form
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
        public Connection()
        {
            InitializeComponent();
        }

        private void Connection_Load(object sender, EventArgs e)
        {

        }
    }
}
