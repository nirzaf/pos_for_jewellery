using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace PCJ_System
{
    public partial class SCStocks_Gems : UserControl
    {
        SqlConnection conn;
        SqlDataAdapter adapt;
        private const string select_query = "SELECT TOP 10 * FROM Stock_Entry WHERE Stock_Type = 'Gems' ORDER BY ID DESC";
        // DataTable dataset;

        private static SCStocks_Gems _instance;

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

        public static SCStocks_Gems Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SCStocks_Gems();
                return _instance;
            }
        }
        public SCStocks_Gems()
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
          
            S_Gems open = new S_Gems();
            open.btnupdate.Visible = false;
            open.bunifuFlatButton3.Visible = false;
            open.Show();


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            S_Gems myFormg = new S_Gems();

            myFormg.btnrefresh.Visible = false;
            myFormg.btnsave.Visible = false;

            myFormg.Stock_Type.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            myFormg.txtstock_no.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            myFormg.txtno_of_peices.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            myFormg.txt_gems.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            myFormg.txt_weight.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();

            byte[] pic = this.dataGridView1.CurrentRow.Cells[12].Value as byte[];
            if (pic != null)
            {
                MemoryStream stream = new MemoryStream(pic);
                myFormg.pb1.Image = Image.FromStream(stream);
            }
            else
                myFormg.pb1.Image = null;

        
            myFormg.txt_cost.Text = this.dataGridView1.CurrentRow.Cells[13].Value.ToString();



           /* String path = (TB_File_Path.Text + txtstock_no.Text + "\\" + pictureBox1.Image);*/
          /*  string imgdir = this.dataGridView1.CurrentRow.Cells[17].Value.ToString();


            Image image = Image.FromFile(imgdir + ".JPG");
            this.pictureBox1.Image = image;*/




            /* string imgdir = this.dataGridView1.CurrentRow.Cells[17].Value.ToString();

             string[] files = Directory.GetFiles(imgdir);

             foreach (string f in files)
             {
                 //MemoryStream mstream = new MemoryStream(f);
                 MessageBox.Show(f);
                 //myFormg.pb1.Image = Image.FromFile(f);

                 // mstream.Dispose();
             }
             */

            /* byte[] pic = this.dataGridView1.CurrentRow.Cells[18].Value as byte[];
             if (pic != null)
             {
                 MemoryStream stream = new MemoryStream(pic);
                 myFormg.pb1.Image = Image.FromStream(stream);
             }
             else
                 myFormg.pb1.Image = null;*/

            //  myForm.hello.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();
            myFormg.ShowDialog();
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {

            //            sda = new SqlDataAdapter(select_query + " ORDER BY ID DESC", conn);
            DisplayData();
        }

        private void SCStocks_Gems_Load(object sender, EventArgs e)
        {
            DisplayData();
        }
     

        private void bunifuMetroTextbox1_KeyUp(object sender, KeyEventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TOP 2 * FROM Stock_Entry Where Stock_No like ('" + bunifuMetroTextbox1.Text + "%')";
            
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
