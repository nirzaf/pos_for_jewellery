using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PCJ_System
{
    public partial class S_Gems : Form
    {
        int xy;
        SqlConnection conn;
        PictureBox[] pictureBoxes;
        string[] picturePaths;
        bool[] pictureIsNew;

        private int stockId = 1;
        private string stockNo = "";

        public static class GlobalValue
        {

            public static int UserCreated = 0;
        }

        public S_Gems()
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

            pictureBoxes = new PictureBox[9];
            pictureBoxes[0] = pictureBox1;
            pictureBoxes[1] = pictureBox2;
            pictureBoxes[2] = pictureBox3;
            pictureBoxes[3] = pictureBox4;
            pictureBoxes[4] = pictureBox5;
            pictureBoxes[5] = pictureBox6;
            pictureBoxes[6] = pictureBox7;
            pictureBoxes[7] = pictureBox8;
            pictureBoxes[8] = pictureBox9;

            picturePaths = new string[pictureBoxes.Length];
            pictureIsNew = new bool[pictureBoxes.Length];

            for (int i = 0; i < pictureIsNew.Length; ++i)
            {
                pictureIsNew[i] = false;
            }

            cmbStockType.SelectedIndex = 0;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtstock_no.Text.Length <= 0)
            {
                errorProvider1.SetError(txtstock_no, "This field cannot be empty, Select a Stock No (UG/MG)");
            }
            else if (txtno_of_peices.Text.Length <= 0)
            {
                errorProvider1.SetError(txtno_of_peices, "This field cannot be empty, Qauntity of Gems");
            }
            else if (txt_gems.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_gems, "Cannot be empty, Select Gem Type");
            }
            else if (txt_weight.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_weight, "This field cannot be empty, Enter the Weight of Gems");
            }
            else if (txt_cost.Text.Length <= 0)
            {
                errorProvider1.SetError(txt_cost, "Cannot be empty, Enter the Cost of Gems");
            }

            else
            {
                conn.Close();
                conn.Open();

                var tx = conn.BeginTransaction();

                try
                {

                    SqlCommand command = new SqlCommand("INSERT INTO Status_Of_Stocks VALUES (@StockID,@StockNo,@StockType,@Qty,@Weight,@Cost)", conn, tx);
                    command.Parameters.AddWithValue("@StockNo", stockNo);
                    command.Parameters.AddWithValue("@StockID", stockId);
                    command.Parameters.AddWithValue("@StockType", "Jewellery");
                    command.Parameters.AddWithValue("@Qty", txtno_of_peices.Text);
                    command.Parameters.AddWithValue("@Weight", txt_weight.Text);
                    command.Parameters.AddWithValue("@Cost", txt_cost.Text);
                    command.ExecuteNonQuery();

                    String query;
                    S_Jewelry sel = new S_Jewelry();

                    command.Parameters.AddWithValue("@StockNo", stockNo);
                    command.Parameters.AddWithValue("@StockId", stockId);
            
                    query = "INSERT INTO Stock_Entry VALUES(@StockID,@stock_no,@Stock_Type,@No_of_pieces,@Gem_Type,@Weight,@Item_Description,@Item_Type,@No_of_Gems,@No_of_other_Gems,@Other_Gems,@Weight_of_other_Gems,@Image,@Cost,@Created_Date,@Updated_Date,@User_ID,@Update_UserID,@Imagepath)";
                    command = new SqlCommand(query, conn, tx);

                    command.Parameters.AddWithValue("@StockID", stockId);
                    command.Parameters.AddWithValue("@stock_no", stockNo);

                    command.Parameters.Add("@Stock_Type", SqlDbType.VarChar);
                    command.Parameters["@Stock_Type"].Value = Stock_Type.Text;

                    command.Parameters.Add("@No_of_pieces", SqlDbType.Int);
                    command.Parameters["@No_of_pieces"].Value = txtno_of_peices.Text;

                    command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar);
                    command.Parameters["@Gem_Type"].Value = txt_gems.Text;

                    command.Parameters.Add("@Weight", SqlDbType.Float);
                    command.Parameters["@Weight"].Value = txt_weight.Text;

                    command.Parameters.Add("@Item_Description", SqlDbType.NVarChar);
                    command.Parameters["@Item_Description"].Value = sel.combo_itemk_description.Text;

                    command.Parameters.Add("@Item_Type", SqlDbType.NVarChar);
                    command.Parameters["@Item_Type"].Value = sel.combo_item_type.Text;

                    command.Parameters.Add("@No_of_Gems", SqlDbType.Int);
                    command.Parameters["@No_of_Gems"].Value = sel.txt_no_of_gems.Text;

                    command.Parameters.Add("@No_of_other_Gems", SqlDbType.Int);
                    command.Parameters["@No_of_other_Gems"].Value = sel.txt_no_of_other_gems.Text;

                    command.Parameters.Add("@Other_Gems", SqlDbType.NVarChar);
                    command.Parameters["@Other_Gems"].Value = sel.txt_other_gems.Text;

                    command.Parameters.Add("@Weight_of_other_Gems", SqlDbType.Float);
                    command.Parameters["@Weight_of_other_Gems"].Value = sel.txt_weight_of_other_gems.Text;

                    if (pb1.Image != null)
                    {
                        MemoryStream stream = new MemoryStream();
                        pb1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] pic = stream.ToArray();
                        command.Parameters.Add("@image", SqlDbType.Binary);
                        command.Parameters["@image"].Value = pic;
                    } else
                    {
                        command.Parameters.Add("@image", SqlDbType.Binary);
                        command.Parameters["@image"].Value = new byte[0];
                    }

                    command.Parameters.Add("@Cost", SqlDbType.Decimal);
                    //txt_cost.Text = String.Format("{0:n0}", double.Parse(txt_cost.Text));
                    command.Parameters["@Cost"].Value = txt_cost.Text;

                    command.Parameters.Add("@Created_Date", SqlDbType.DateTime);
                    command.Parameters["@Created_Date"].Value = label11.Text;

                    command.Parameters.Add("@Updated_Date", SqlDbType.DateTime);
                    command.Parameters["@Updated_Date"].Value = label11.Text;

                    command.Parameters.Add("@User_ID", SqlDbType.NVarChar);
                    command.Parameters["@User_ID"].Value = hello.Text;

                    command.Parameters.Add("@Update_UserID", SqlDbType.NVarChar);
                    command.Parameters["@Update_UserID"].Value = "";

                    command.Parameters.Add("@Imagepath", SqlDbType.NVarChar);
                    command.Parameters["@Imagepath"].Value = TB_File_Path.Text + txtstock_no.Text + "\\";

                    String path = TB_File_Path.Text + txtstock_no.Text + "\\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        // MessageBox.Show("Folder Created ");
                    }

                    for (int i = 0; i < pictureBoxes.Length; ++i)
                    {
                        if (pictureIsNew[i])
                        {
                            string targetPath = String.Format("{0}img-{1:D4}{2}", path, i, Path.GetExtension(picturePaths[i]));
                            File.Copy(picturePaths[i], targetPath, true);
                        }
                    }

                    command.ExecuteNonQuery();
                    tx.Commit();
                    conn.Close();

                    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }

                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpenFileDialog = new OpenFileDialog();
            dlgOpenFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg|*.jpg|All files(*.*)|*.*";
            if (dlgOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Bitmap.FromFile(dlgOpenFileDialog.FileName);
                pb1.Image = image;

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {


            try
            {
                conn.Close();
                conn.Open();
                String query;

                if (pb1.Image == null)
                {
                    query = "Update Stock_Entry  set Stock_Type = @Stock_Type, Stock_No = @Stock_No , No_of_pieces = @No_of_pieces, Gem_Type = @Gem_Type, Weight = @Weight, Cost = @Cost, Update_Date = @Update_Date, Update_UserID=@Update_UserID, Imagepath= @Imagepath WHERE  Stock_No = @Stock_No";
                }
                else
                {
                    query = "Update Stock_Entry  set Stock_Type = @Stock_Type, Stock_No = @Stock_No , No_of_pieces = @No_of_pieces, Gem_Type = @Gem_Type, Weight = @Weight, Image = @Image, Cost = @Cost, Update_Date = @Update_Date, Update_UserID=@Update_UserID, Imagepath= @Imagepath WHERE  Stock_No = @Stock_No";
                }

                SqlCommand command = new SqlCommand(query, conn);


                //conn.Close();
                //conn.Open();

                /*    SqlCommand command = new SqlCommand("Update Stock_Entry  set Stock_Type = @Stock_Type, Stock_No = @Stock_No , No_of_pieces = @No_of_pieces, Gem_Type = @Gem_Type, Weight = @Weight, Image = @Image, Cost = @Cost, Update_Date = @Update_Date, Update_UserID=@Update_UserID WHERE  Stock_No = @Stock_No", conn);*/

                command.Parameters.Add("@Stock_Type", SqlDbType.VarChar).Value = Stock_Type.Text;
                command.Parameters.Add("@stock_no", SqlDbType.NVarChar).Value = txtstock_no.Text;
                command.Parameters.Add("@No_of_pieces", SqlDbType.Int).Value = txtno_of_peices.Text;
                command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar).Value = txt_gems.Text;

                command.Parameters.Add("@Weight", SqlDbType.Float).Value = txt_weight.Text;

                /*  using (MemoryStream ms = new MemoryStream())
                  {
                      pb1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                      command.Parameters.Add("@Image", SqlDbType.Image).Value = ms.ToArray();
                  }*/
                if (pb1.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    pb1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    command.Parameters.Add("@Image", SqlDbType.Binary);
                    command.Parameters["@Image"].Value = pic;
                }

                command.Parameters.Add("@Cost", SqlDbType.Decimal).Value = txt_cost.Text;

                command.Parameters.Add("@Update_Date", SqlDbType.DateTime).Value = label11.Text;

                command.Parameters.Add("@Update_UserID", SqlDbType.NVarChar).Value = hello.Text;

                command.Parameters.Add("@Imagepath", SqlDbType.NVarChar);
                command.Parameters["@Imagepath"].Value = TB_File_Path.Text + txtstock_no.Text + "\\";

                String path = TB_File_Path.Text + txtstock_no.Text + "\\";

                for (int i = 0; i < pictureBoxes.Length; ++i)
                {
                    if (pictureIsNew[i])
                    {
                        string targetPath = String.Format("{0}img-{1:D4}{2}", path, i, Path.GetExtension(picturePaths[i]));
                        File.Copy(picturePaths[i], targetPath, true);
                    }
                }

                command.ExecuteNonQuery();
                MessageBox.Show("You've updated successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            conn.Close();
            this.Close();

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();

                String DeleteQuery = "Delete from Stock_Entry where Stock_No ='" + txtstock_no.Text + "';";

                String path = TB_File_Path.Text + txtstock_no.Text + "\\";

                /*  if (!Directory.Exists(path))
                  {
                      Directory.Delete(path);
                      // MessageBox.Show("Folder Created ");
                  }

                  for (int i = 0; i < pictureBoxes.Length; ++i)
                  {
                      if (pictureIsNew[i])
                      {
                          string targetPath = String.Format("{0}img-{1:D4}{2}", path, i, Path.GetExtension(picturePaths[i]));
                          File.Copy(picturePaths[i], targetPath, true);
                      }
                  }*/

                SqlDataAdapter execute = new SqlDataAdapter(DeleteQuery, conn);
                execute.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("You've deleted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                this.Close();




            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void getLastNumbers()
        {
            try
            {
                conn.Close();
                conn.Open();

                String selectQuery = "SELECT TOP 1 StockID FROM Status_Of_Stocks WHERE StockNo='" + stockNo + "' ORDER BY StockID DESC";

                SqlDataAdapter execute = new SqlDataAdapter(selectQuery, conn);
                SqlDataReader reader = execute.SelectCommand.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    stockId = reader.GetInt32(0) + 1;
                }
                else
                {
                    stockId = 1;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbStockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStockType.SelectedIndex == 0)
                stockNo = "UG";
            else
                stockNo = "MG";

            getLastNumbers();

            txtstock_no.Text = string.Format("{0}{1:D3}", stockNo, stockId);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void S_Gems_Load_1(object sender, EventArgs e)
        {

            //getLastNumbers();
            DateTime dateTime = DateTime.Now;
            this.label11.Text = dateTime.ToString();
            hello.Text = GlobalVariablesClass.VariableOne;


            /*FileStream fs = new System.IO.FileStream(path, FileMode.Open, FileAccess.Read);
            pictureBox1.Image = Image.FromStream(fs);
            fs.Close();*/


            String path = (TB_File_Path.Text + txtstock_no.Text + "\\");
            //string imgdir = this.dataGridView1.CurrentRow.Cells[17].Value.ToString();
            try {
                string[] imgs = Directory.GetFiles(path, "*.Jpg");

                for (xy = 0; xy < imgs.Length && xy < pictureBoxes.Length; ++xy)
                {
                    pictureBoxes[xy].Image = Image.FromFile(imgs[xy]);
                    picturePaths[xy] = imgs[xy];
                    //MessageBox.Show(imgs[i]);
                }
            } catch (Exception ex)
            {
                // no images
            }


            txtno_of_peices.GotFocus += new EventHandler(this.TextGotFocus);
            txtno_of_peices.LostFocus += new EventHandler(this.TextGotFocus);

            txt_weight.GotFocus += new EventHandler(this.TextGotFocus);
            txt_weight.LostFocus += new EventHandler(this.TextLostFocus);

            txt_cost.GotFocus += new EventHandler(this.TextGotFocus);
            txt_cost.LostFocus += new EventHandler(this.TextLostFocus);

        }

        public void TextGotFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "0")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void TextLostFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "0";
                tb.ForeColor = Color.Brown;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {


            try
            {
                xy %= pictureBoxes.Length;
                OpenFileDialog opFile = new OpenFileDialog();
                opFile.Filter = "JPEG Files (*.jpg)|*.jpg";

                if (opFile.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxes[xy].Image = Image.FromFile(opFile.FileName);
                    picturePaths[xy] = opFile.FileName;
                    pictureIsNew[xy] = true;
                    xy += 1;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            /*  OpenFileDialog opFile = new OpenFileDialog();
              opFile.Filter = "png files(*.png)|*.png|jpg files(*.jpg|*.jpg|All files(*.*)|*.*";
              if (opFile.ShowDialog() == DialogResult.OK)
              {
                  Image image = Bitmap.FromFile(opFile.FileName);
                  pictureBox1.Image = image;

              }


               */

            // <---




        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            /*  if (txtno_of_peices.Text == "")
              {
                  txtno_of_peices.GotFocus += new EventHandler(this.TextGotFocus);
                  txtno_of_peices.LostFocus += new EventHandler(this.TextGotFocus);
              }
              else if (txt_weight.Text != null)
              {

                  txt_weight.GotFocus += new EventHandler(this.TextGotFocus);
                  txt_weight.LostFocus += new EventHandler(this.TextLostFocus);
              }
              else if (txt_cost.Text != null)
              {
                  txt_cost.GotFocus += new EventHandler(this.TextGotFocus);
                  txt_cost.LostFocus += new EventHandler(this.TextLostFocus);
              }*/
            txtno_of_peices.Text = "";
            txt_weight.Text = "";
            txt_cost.Text = "";
            txtstock_no.Text = "";
            cmbStockType.Text = "";
            txtstock_no.Text = "";
            pb1.Image = null;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;


        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    }
}
