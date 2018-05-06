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
using System.IO;


namespace PCJ_System
{
    public partial class Stocks_Jewelry : UserControl
    {
        SqlConnection conn;
      //  SqlCommand cmd;
        SqlDataAdapter adapt;
        private const string select_query = "SELECT TOP 10 * FROM Stock_Entry WHERE Stock_Type = 'Jewellery' ORDER BY Stock_ID DESC";
        // DataTable dataset;


        private static Stocks_Jewelry _instance;
        private void DisplayData()
        {
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter(select_query, conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 80;
            }

        }

        public static Stocks_Jewelry Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Stocks_Jewelry();
                return _instance;
            }
        }

        public Stocks_Jewelry()
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
            S_Jewelry open = new S_Jewelry();
            open.btnupdate.Visible = false;
            open.btn_delete.Visible = false;
            open.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (!dataGridView1.Rows[e.RowIndex].IsNewRow)
            {

            }

            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

        }

        private void Stocks_Jewelry_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             S_Jewelry myForm = new S_Jewelry();

            myForm.btn_Refresh.Visible = false;
            myForm.btnsave.Visible = false;


            // myForm.txt_ID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            myForm.Stock_Type.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
              myForm.txtstock_no.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

              myForm.txt_qty.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
              myForm.txt_gem_type.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
              myForm.txt_gem_weight.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
              myForm.combo_itemk_description.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
              myForm.combo_item_type.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();

              myForm.txt_no_of_gems.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
              myForm.txt_no_of_other_gems.Text = this.dataGridView1.CurrentRow.Cells[9].Value.ToString();
              myForm.txt_other_gems.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
              myForm.txt_weight_of_other_gems.Text = this.dataGridView1.CurrentRow.Cells[11].Value.ToString();

              byte[] pic = this.dataGridView1.CurrentRow.Cells[12].Value as byte[];
              if (pic != null)
              {
                  MemoryStream stream = new MemoryStream(pic);
                  myForm.pb1.Image = Image.FromStream(stream);
              }
              else
                  myForm.pb1.Image = null;

              //  myForm.pb1.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
              myForm.txt_cost.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
              myForm.ShowDialog();





              /*S_Gems myFormg = new S_Gems();
              myFormg.Stock_Type.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
              myFormg.txtstock_no.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
              myFormg.txtno_of_peices.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
              myFormg.txt_gems.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
              myFormg.txt_weight.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

              byte[] picg = this.dataGridView1.CurrentRow.Cells[12].Value as byte[];
              if (picg != null)
              {
                  MemoryStream stream = new MemoryStream(picg);
                  myFormg.pb1.Image = Image.FromStream(stream);
              }
              else
                  myFormg.pb1.Image = null;

              myFormg.txt_cost.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();
              //  myForm.hello.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
              myFormg.Hide();*/


        }

        private void textbox1_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TOP 1 * FROM Stock_Entry Where Stock_No like ('" + textbox1.Text + "%') ORDER BY ID DESC ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                    break;
                }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 80;
            }

        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }
    }
}
