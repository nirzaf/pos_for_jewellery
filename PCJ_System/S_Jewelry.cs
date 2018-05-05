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
    public partial class S_Jewelry : Form
    {
        int xy;
        SqlConnection conn;
        PictureBox[] pictureBoxes;
        string[] picturePaths;
        bool[] pictureIsNew;
        ///SqlCommand cmd;
        public S_Jewelry()
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

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string commandText = @"INSERT INTO Stock_Entry VALUES(@Stock_Type,@stock_no,@Quantity,@Gem_Type,@Gem_Weight,@Item_Description,@Item_Type,@No_of_Gems,@No_of_other_Gems,@Other_Gems,@Weight_of_other_Gems,@image,@Cost,@Created_Date,@Updated_Date,@User_ID,@Update_UserID,@Imagepath)";

                SqlCommand command = new SqlCommand(commandText, conn);

                command.Parameters.Add("@Stock_Type", SqlDbType.VarChar);
                command.Parameters["@Stock_Type"].Value = Stock_Type.Text;

                command.Parameters.Add("@stock_no", SqlDbType.NVarChar);
                command.Parameters["@stock_no"].Value = txtstock_no.Text;

                command.Parameters.Add("@Quantity", SqlDbType.Int);
                command.Parameters["@Quantity"].Value = txt_qty.Text;

                command.Parameters.Add("@Gem_Weight", SqlDbType.Float);
                command.Parameters["@Gem_Weight"].Value = txt_gem_weight.Text;

                command.Parameters.Add("@Item_Description", SqlDbType.NVarChar);
                command.Parameters["@Item_Description"].Value = combo_itemk_description.Text;

                command.Parameters.Add("@Item_Type", SqlDbType.NVarChar);
                command.Parameters["@Item_Type"].Value = combo_item_type.Text;

                command.Parameters.Add("@No_of_Gems", SqlDbType.Int);
                command.Parameters["@No_of_Gems"].Value = txt_no_of_gems.Text;

                command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar);
                command.Parameters["@Gem_Type"].Value = txt_gem_type.Text;

                command.Parameters.Add("@No_of_other_Gems", SqlDbType.Int);
                command.Parameters["@No_of_other_Gems"].Value = txt_no_of_other_gems.Text;

                command.Parameters.Add("@Other_Gems", SqlDbType.NVarChar);
                command.Parameters["@Other_Gems"].Value = txt_other_gems.Text;

                command.Parameters.Add("@Weight_of_other_Gems", SqlDbType.Float);
                command.Parameters["@Weight_of_other_Gems"].Value = txt_weight_of_other_gems.Text;

                if (pb1.Image != null)
                {
                    MemoryStream stream = new MemoryStream();
                    pb1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    command.Parameters.Add("@image", SqlDbType.Image);
                    command.Parameters["@image"].Value = pic;
                    //command.Parameters.AddWithValue("@image", pic);
                    stream.Dispose();
                }

                else

                {
                    SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.Image);
                    imageParameter.Value = DBNull.Value;
                    command.Parameters.Add(imageParameter);
                }

                command.Parameters.Add("@Cost", SqlDbType.Decimal);
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
                MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void S_Jewelry_Load(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label11.Text = dateTime.ToString();
            hello.Text = GlobalVariablesClass.VariableOne;

            String path = (TB_File_Path.Text + txtstock_no.Text + "\\");
            //string imgdir = this.dataGridView1.CurrentRow.Cells[17].Value.ToString();

            string[] imgs = Directory.GetFiles(path, "*.Jpg");

            for (xy = 0; xy < imgs.Length && xy < pictureBoxes.Length; ++xy)
            {
                pictureBoxes[xy].Image = Image.FromFile(imgs[xy]);
                picturePaths[xy] = imgs[xy];
                //MessageBox.Show(imgs[i]);
            }

            txt_no_of_gems.GotFocus += new EventHandler(this.TextGotFocus1);
            txt_no_of_gems.LostFocus += new EventHandler(this.TextLostFocus1);

            txt_gem_weight.GotFocus += new EventHandler(this.TextGotFocus);
            txt_gem_weight.LostFocus += new EventHandler(this.TextLostFocus);

            txt_no_of_other_gems.GotFocus += new EventHandler(this.TextGotFocus1);
            txt_no_of_other_gems.LostFocus += new EventHandler(this.TextLostFocus1);

            txt_weight_of_other_gems.GotFocus += new EventHandler(this.TextGotFocus);
            txt_weight_of_other_gems.LostFocus += new EventHandler(this.TextLostFocus);

            txt_cost.GotFocus += new EventHandler(this.TextGotFocus);
            txt_cost.LostFocus += new EventHandler(this.TextLostFocus);

        }

        public void TextGotFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "0.0")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }
        public void TextGotFocus1(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "0")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void TextLostFocus1(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "0";
                tb.ForeColor = Color.Brown;
            }
        }

        public void TextLostFocus(Object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "0.0";
                tb.ForeColor = Color.Brown;
            }
        }


        Bunifu.Framework.UI.Drag MoveForm = new Bunifu.Framework.UI.Drag();

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpenFileDialog = new OpenFileDialog();
            dlgOpenFileDialog.Filter = "jpg files(*.jpg|*.jpg|png files(*.png)|*.png|All files(*.*)|*.*";
            if (dlgOpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                Image image = Bitmap.FromFile(dlgOpenFileDialog.FileName);
                pb1.Image = image;

            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();

                SqlCommand command = new SqlCommand("Update Stock_Entry set Stock_Type = @Stock_Type, Stock_No = @Stock_No , No_of_Pieces = @No_of_Pieces, Gem_Type = @Gem_Type, Weight = @Gem_Weight, Item_Description = @Item_Description, Item_Type = @Item_Type, No_of_Gems = @No_of_Gems,  No_of_other_Gems = @No_of_other_Gems , Other_Gems = @Other_Gems , Weight_of_other_Gems = @Weight_of_other_Gems , Image = @Image, Cost = @Cost, Update_Date = @Update_Date, Update_UserID = @Update_UserID, Imagepath= @Imagepath  WHERE  Stock_No = @Stock_No", conn);

                //command.Parameters.Add("@ID", SqlDbType.Int).Value = txt_ID.Text;
                command.Parameters.Add("@Stock_Type", SqlDbType.VarChar).Value = Stock_Type.Text;
                command.Parameters.Add("@stock_no", SqlDbType.NVarChar).Value = txtstock_no.Text;
                command.Parameters.Add("@No_of_Pieces", SqlDbType.Int).Value = txt_qty.Text;
command.Parameters.Add("@Gem_Type", SqlDbType.NVarChar).Value = txt_gem_type.Text;
                command.Parameters.Add("@Gem_Weight", SqlDbType.Float).Value = txt_gem_weight.Text;
                command.Parameters.Add("@Item_Description", SqlDbType.NVarChar).Value = combo_itemk_description.Text;
                command.Parameters.Add("@Item_Type", SqlDbType.NVarChar).Value = combo_item_type.Text;
                command.Parameters.Add("@No_of_Gems", SqlDbType.Int).Value = txt_no_of_gems.Text;

                command.Parameters.Add("@No_of_other_Gems", SqlDbType.Int).Value = txt_no_of_other_gems.Text;
                command.Parameters.Add("@Other_Gems", SqlDbType.NVarChar).Value = txt_other_gems.Text;
                command.Parameters.Add("@Weight_of_other_Gems", SqlDbType.Float).Value = txt_weight_of_other_gems.Text;


                using (MemoryStream ms = new MemoryStream())
                {
                    pb1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    command.Parameters.Add("@Image", SqlDbType.Image).Value = ms.ToArray();
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}