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
using System.Text.RegularExpressions;

namespace PCJ_System
{
    public partial class Status_of_Stocks : UserControl
    {
        SqlConnection conn;
       // SqlDataAdapter adapt;

        // private const string select_query = "Exec ProductStatus";
        private const string select_query = "SELECT TOP 10 * FROM Status_of_Stocks ORDER BY StockID DESC";

        private void AddDataToGridView(SqlDataReader reader)
        {
            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                //var row = dt.NewRow();
                var index = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[index];

                string sNo = reader["StockNo"].ToString();
                string sId = reader["StockID"].ToString();

                // store so that the items can be fetched later
                //StockNoList.Add(sNo);
                //StockIdList.Add(sId);
                string itemNo = String.Format("{0}{1}", sNo, sId);

                row.Cells[0].Value = itemNo;
                row.Cells[1].Value = reader["StockType"].ToString();
                row.Cells[2].Value = reader["Qty"].ToString();
                row.Cells[3].Value = reader["Weight"].ToString();
                row.Cells[4].Value = reader["Cost"].ToString();




                //  using (var command = new SqlCommand("SELECT TOP 1* FROM Status_of_Stocks WHERE StockNo=@StockNo AND StockID=@StockID AND StockType=@StockType", conn))
                // {


                //using (var reader1 = command.ExecuteReader())
                //{
                //    if (reader1.Read())
                //    {
                int qty = Int32.Parse(reader["Qty"].ToString());

                if (qty <= 0)
                {
                    row.Cells[5].Value = "Out of Stocks";
                }
                else
                {
                    row.Cells[5].Value = "Available";
                }
                //}
                //}
                // }
            }

            dataGridView1.RefreshEdit();
        }

        private void DisplayData()
        {
            dataGridView1.Rows.Clear();
            // stockNoList.Clear();
            // stockItemList.Clear();
            // conn.Close();
            // conn.Open();

            try
            {
                var command = new SqlCommand(select_query, conn);
                using (var reader = command.ExecuteReader())
                {
                    AddDataToGridView(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            DisplayData();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            var matches = Regex.Match(bunifuMetroTextbox1.Text, "([A-Za-z]+)([0-9]+)");

            if (matches.Groups.Count < 3)
            {
                DisplayData();
                return;
            }

            string stockNo = matches.Groups[1].Value;
            string stockId = matches.Groups[2].Value;

            const string query = "SELECT TOP 5 * FROM Status_of_Stocks WHERE StockNo LIKE @StockNo AND StockID LIKE @StockID ORDER BY StockID DESC";
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StockNo", stockNo + '%');
                cmd.Parameters.AddWithValue("@StockID", stockId + '%');

                using (var reader = cmd.ExecuteReader())
                {
                    AddDataToGridView(reader);
                }
            }



        }
    }
}
