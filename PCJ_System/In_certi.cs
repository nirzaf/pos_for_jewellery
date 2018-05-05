using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace PCJ_System
{
    public partial class In_certi : Form
    {
        private static int _lastFC = 0;
        private static int _lastLC = 0;
        private string[] last_amount = { "", "", "" };
        private List<Image> pics = new List<Image>();
        DataTable dt = new DataTable();

        SqlConnection conn;

        public In_certi()
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
            CalculateTotal();

            using (var cmd = new SqlCommand("SELECT * FROM dbo.[F_Currency]", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbCurrency1.Items.Add(reader["FC_TYPE"].ToString());
                        cmbCurrency2.Items.Add(reader["FC_TYPE"].ToString());
                        cmbCurrency3.Items.Add(reader["FC_TYPE"].ToString());
                    }
                }
            }

            using (var cmd = new SqlCommand("SELECT * FROM dbo.[Card_Type]", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbCardTyp.Items.Add(reader["CardType"].ToString());
                    }
                }
            }

            cmbPaymentTyp.SelectedIndex = 0;

            for (int i = 0; i < dgvItem.Columns.Count; ++i)
            {
                dt.Columns.Add(dgvItem.Columns[i].HeaderText);
            }

            dgvItem.AutoGenerateColumns = true;
            dgvItem.Columns.Clear();
            dgvItem.DataSource = dt;
        }
        private void CalculateTotal()
        {
            double x = 0;
            double rate1 = 1;
            double rate2 = 1;
            double rate3 = 1;
            double amt1 = 0;
            double amt2 = 0;
            double amt3 = 0;
            if (txtRate1.Text != "")
                rate1 = Convert.ToDouble(txtRate1.Text);

            if (txtRate2.Text != "")
                rate2 = Convert.ToDouble(txtRate2.Text);

            if (txtRate3.Text != "")
                rate3 = Convert.ToDouble(txtRate3.Text);

            if (txtAmt1.Text != "")
                amt1 = Convert.ToDouble(txtAmt1.Text);

            if (txtAmt2.Text != "")
                amt2 = Convert.ToDouble(txtAmt2.Text);

            if (txtAmt3.Text != "")
                amt3 = Convert.ToDouble(txtAmt3.Text);

            txtTot1.Text = Convert.ToString(amt1 * rate1);
            txtTot2.Text = Convert.ToString(amt2 * rate2);
            txtTot3.Text = Convert.ToString(amt3 * rate3);

            x = amt1 * rate1 + amt2 * rate2 + amt3 * rate3;
            txtTotalAmount.Text = x.ToString();

        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void In_certi_Load(object sender, EventArgs e)
        {
            getLastNumbers();
        }

        private void checkBox_disable_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_disable.Checked == true)
            {
                cmbCurrency2.Enabled = true;
                txtAmt2.Enabled = true;
                cmbCurrency3.Enabled = true;
                txtAmt3.Enabled = true;

            }
            if (checkBox_disable.Checked == false)
            {
                cmbCurrency2.Enabled = false;
                txtAmt2.Enabled = false;
                cmbCurrency3.Enabled = false;
                txtAmt3.Enabled = false;
            }
        }

        private void ST_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItmTyp.Text == null)
            {

                textBox1.Enabled = false;

            }
            if (cmbItmTyp.Text != null)
            {

                textBox1.Enabled = true;
            }

            if (cmbItmTyp.Text == "GEM")
            {
                textBox1.Text = "";
                txtNoPieces.Visible = true;
                lblNoPieces.Visible = true;
                txtCost.Visible = true;
                lblCost.Visible = true;
                txtGemWeight.Visible = true;
                lblGemWeight.Visible = true;
                txtSpecification.Visible = true;
                lblSpecification.Visible = true;
                tickspec.Visible = true;

            }

            else
            {
                textBox1.Text = "";
                txtNoPieces.Visible = false;
                lblNoPieces.Visible = false;
                txtCost.Visible = false;
                lblCost.Visible = false;
                txtGemWeight.Visible = false;
                lblGemWeight.Visible = false;
                txtSpecification.Visible = false;
                lblSpecification.Visible = false;
                tickspec.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnremovestock_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row[2].ToString() == textBox1.Text)
                {
                    return;
                }
            }


            using (var command = new SqlCommand("SELECT * FROM Stock_Entry WHERE Stock_No=@id AND Stock_Type=@stock_type", conn))
            {
                command.Parameters.AddWithValue("id", textBox1.Text);
                command.Parameters.AddWithValue("stock_type", cmbItmTyp.SelectedItem.ToString());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] pic = reader["Image"] as byte[];
                        MemoryStream ms = new MemoryStream(pic);
                        pics.Add(Image.FromStream(ms));

                        var row = dt.NewRow();
                        row[0] = dt.Rows.Count + 1;
                        row[1] = reader["Stock_Type"].ToString();
                        row[2] = reader["Stock_No"];

                        if (cmbItmTyp.SelectedIndex == 0)
                        {
                            // gem
                            row[3] = txtNoPieces.Text;
                            row[4] = String.Format("{0} {1}cts ", reader["Gem_Type"], txtGemWeight.Text);
                            row[5] = txtCost.Text;
                            row[6] = txtSpecification.Text;
                        }
                        else if (cmbItmTyp.SelectedIndex == 1)
                        {
                            // jewellery
                            string desc = String.Format("{0} {1} with {2} {3} {4}cts", reader["Item_Description"], reader["Item_Type"], reader["No_of_Gems"], reader["Gem_Type"], reader["Weight"]);
                            if (Int32.Parse(reader["No_of_other_Gems"].ToString()) != 0)
                            {
                                desc = String.Format("{0} & {1} {2} {3}cts", desc, reader["No_of_other_Gems"], reader["Other_Gems"], reader["weight_of_other_gems"]);
                            }

                            row[4] = desc;
                            row[5] = reader["Cost"];
                            row[3] = reader["No_of_pieces"];
                        }

                        dt.Rows.Add(row);
                        dgvItem.RefreshEdit();
                    }
                }
            }
        }

        private void cmbPaymentTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentTyp.SelectedIndex > 0)
            {
                lblCardTyp.Visible = lblcardamt.Visible = cmbCardTyp.Visible = txtcardamt.Visible = true;
            }
            else if (cmbPaymentTyp.SelectedIndex == 0)
            {
                lblCardTyp.Visible = lblcardamt.Visible = cmbCardTyp.Visible = txtcardamt.Visible = false;
                txtcardamt.Text = "";
            }
        }

        private void cmbInvTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbInvTyp.SelectedIndex == 0)
                txtInvNo.Text = string.Format("CMB-{0:000}-FC", _lastFC);
            else
                txtInvNo.Text = string.Format("CMB-{0:000}-LC", _lastLC);

            if (cmbInvTyp.Text == "LOCAL")
            {
                txtAddress.Text = "SRI LANKA";
            }
            else
            {
                txtAddress.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "INSERT INTO CustomerDetails (InvType,InvNo,CusNm,CusTitle,CusAddress,isAct) VALUES(@InvType,@InvNo,@CusNm,@CusTitle,@CusAddress,@isAct)";

                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.Add("@InvType", SqlDbType.NVarChar);
                command.Parameters["@InvType"].Value = cmbInvTyp.Text;

                command.Parameters.Add("@InvNo", SqlDbType.VarChar);
                command.Parameters["@InvNo"].Value = txtInvNo.Text;

                command.Parameters.Add("@CusNm", SqlDbType.NVarChar);
                command.Parameters["@CusNm"].Value = txtCusNm.Text;

                command.Parameters.Add("@CusTitle", SqlDbType.NVarChar);
                command.Parameters["@CusTitle"].Value = cmbTitle.Text;

                command.Parameters.Add("@CusAddress", SqlDbType.NVarChar);
                command.Parameters["@CusAddress"].Value = txtAddress.Text;

                command.Parameters.Add("@isAct", SqlDbType.Bit);
                command.Parameters["@isAct"].Value = txtAddress.Text;


                command.ExecuteNonQuery();

                if (cmbInvTyp.SelectedIndex == 0)
                    _lastFC++;
                else
                    _lastLC++;
                saveLastNumbers();

                MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void getLastNumbers()
        {
            try
            {
                String selectQuery = "SELECT * FROM LstInvId";
                using (SqlDataAdapter execute = new SqlDataAdapter(selectQuery, conn))
                {
                    using (SqlDataReader reader = execute.SelectCommand.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            _lastFC = reader.GetInt32(1);
                            _lastLC = reader.GetInt32(2);
                        }
                        else
                        {
                            _lastFC = 1;
                            _lastLC = 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void saveLastNumbers()
        {
            try
            {
                String updateQuery = string.Format("UPDATE LstInvId SET lastfc={0}, lastlc={1}", _lastFC, _lastLC);
                SqlDataAdapter execute = new SqlDataAdapter(updateQuery, conn);
                execute.SelectCommand.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFCupdate_Click(object sender, EventArgs e)
        {

            Foriegn_Currency_Update open = new Foriegn_Currency_Update();
            open.Show();
        }

        private void cmbCurrency1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox txt;
            if (sender == cmbCurrency1)
            {
                txt = txtRate1;
            }
            else if (cmbCurrency2 == sender)
            {
                txt = txtRate2;
            }
            else
            {
                txt = txtRate3;
            }

            using (var cmd = new SqlCommand("SELECT [FC_Rate] FROM dbo.[F_Currency] WHERE [FC_TYPE]=@fc_type", conn))
            {
                cmd.Parameters.AddWithValue("fc_type", ((ComboBox)sender).SelectedItem.ToString());
                txt.Text = cmd.ExecuteScalar().ToString();
            }

            CalculateTotal();
        }

        private void btnaddstock_Click(object sender, EventArgs e)
        {
            //    const string query = "SELECT TOP 1 Stock_No,Image"

            using (var command = new SqlCommand("SELECT TOP 1 No_of_pieces,Stock_No,Image FROM Stock_Entry WHERE Stock_No=@id AND stock_type=@type", conn))
            {
                command.Parameters.AddWithValue("@id", textBox1.Text);
                command.Parameters.AddWithValue("@type", cmbItmTyp.SelectedItem.ToString());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int qty = Int32.Parse(reader["No_of_pieces"].ToString());
                        if (qty <= 0)
                        {

                            MessageBox.Show("Out of Stock!");
                        }
                        else
                        {
                            //pictureBox1.
                            byte[] pic = reader["Image"] as byte[];
                            if (pic != null)
                            {
                                MemoryStream stream = new MemoryStream(pic);
                                pictureBox1.Image = Image.FromStream(stream);
                            }
                        }
                    }
                }
            }
        }

        private void cmbCardTyp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAmt1_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            TextBox rate = null;
            TextBox total = null;
            int index = 0;

            if (sender == txtAmt1)
            {
                rate = txtRate1;
                total = txtTot1;
            }
            else if (sender == txtAmt2)
            {
                rate = txtRate2;
                total = txtTot2;
                index = 1;
            }
            else if (sender == txtAmt3)
            {
                rate = txtRate3;
                total = txtTot3;
                index = 2;
            }

            if (!Regex.IsMatch(txtBox.Text, "^[0-9]+\\.?[0-9]?[0-9]?$"))
            {
                // txtTot1.Text = "";
                if (txtBox.Text != "")
                {
                    txtBox.Text = last_amount[index];
                }
            }

            if (txtBox.Text != "" && rate.Text != "")
            {
                total.Text = "" + (Double.Parse(txtBox.Text) * Double.Parse(rate.Text));
            }

            last_amount[index] = txtBox.Text;

            CalculateTotal();
        }

        private void txtAmt1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dgvItem_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvItem.SelectedRows.Count > 0)
            {
                pics.RemoveAt(dgvItem.CurrentRow.Index);
                dgvItem.Rows.RemoveAt(dgvItem.CurrentRow.Index);
            }
        }

        private void dgvItem_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {

            }

            //if (e.StateChanged == DataGridViewElementStates.)
        }

        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItem.CurrentRow.Index != -1)
            {
                pictureBox1.Image = pics[dgvItem.CurrentRow.Index];
            }
        }
    }
}
