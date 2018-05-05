using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PCJ_System
{
    public partial class Status_of_Stocks : UserControl
    {
        SqlConnection conn;
        SqlDataAdapter adapt;
        
        private const string select_query = "EXEC ProductStatus";
        


        private void DisplayData()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter(select_query, conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        public Status_of_Stocks()
        {
            try
            {
                DB_CONNECTION dbObj = new DB_CONNECTION();
                conn = dbObj.getConnection();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Can't Open Connection!! " + ex);
            }

            InitializeComponent();
            DisplayData();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void Status_of_Stocks_Load(object sender, EventArgs e)
        {
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
