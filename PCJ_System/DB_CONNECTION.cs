 using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCJ_System
{
    class DB_CONNECTION
    {
        // SqlConnection conn;

        public SqlConnection getConnection()
        {
            SqlConnection conn = null; ;
            try
            {
                conn = new SqlConnection("data source= DESKTOP-ULUP989\\SQLEXPRESS;initial catalog=PCJ_SYSTEM_DB; Integrated Security=True;");
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Open Connection !" + ex);
            }
            return conn;
        }
    }
}
