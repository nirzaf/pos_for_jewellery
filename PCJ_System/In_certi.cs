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

namespace PCJ_System
{
    public partial class In_certi : Form
    {
        private static int _lastFC = 0;
        private static int _lastLC = 0;

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

            rates = new List<int>();

            using (var conn = new DB_CONNECTION().getConnection())
            {
                using (var cmd = new SqlCommand("SELECT * FROM dbo.[F_Currency]", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbCurrency1.Items.Add(reader["FC_TYPE"].ToString());
                            cmbCurrency2.Items.Add(reader["FC_TYPE"].ToString());
                            cmbCurrency3.Items.Add(reader["FC_TYPE"].ToString());
                            rates.Add(Int32.Parse(reader["FC_RATE"].ToString()));
                        }
                    }
                }
            }
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
                txtRate2.Enabled = true;
                cmbCurrency3.Enabled = true;
                txtAmt3.Enabled = true;
                txtRate3.Enabled = true;

            }
            if (checkBox_disable.Checked == false)
            {
                cmbCurrency2.Enabled = false;
                txtAmt2.Enabled = false;
                txtRate2.Enabled = false;
                cmbCurrency3.Enabled = false;
                txtAmt3.Enabled = false;
                txtRate3.Enabled = false;

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

        }

        private void cmbPaymentTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentTyp.Text == null || cmbPaymentTyp.Text == "Cash")
            {
                //lblCardNo.Visible = true;
                cmbCardTyp.Visible = false;
                lblCardTyp.Visible = false;
                txtcardamt.Visible = false;
                lblcardamt.Visible = false;

                cmbCurrency1.Enabled = true;
                txtAmt1.Enabled = true;
                txtRate1.Enabled = true;

            }
            else if (cmbPaymentTyp.Text == "Card")

            {
                cmbCardTyp.Visible = true;
                lblCardTyp.Visible = true;
                txtcardamt.Visible = true;
                lblcardamt.Visible = true;

                cmbCurrency1.Enabled = false;
                txtAmt1.Enabled = false;
                txtRate1.Enabled = false;


            }
            else
            {
                cmbCardTyp.Visible = true;
                lblCardTyp.Visible = true;
                txtcardamt.Visible = true;
                lblcardamt.Visible = true;

                cmbCurrency1.Enabled = true;
                txtAmt1.Enabled = true;
                txtRate1.Enabled = true;


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
                conn.Close();
                conn.Open();
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
                conn.Close();

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
                conn.Close();
                conn.Open();
                String selectQuery = "SELECT * FROM LstInvId";
                SqlDataAdapter execute = new SqlDataAdapter(selectQuery, conn);
                SqlDataReader reader = execute.SelectCommand.ExecuteReader();
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
                conn.Close();
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
                conn.Close();
                conn.Open();
                String updateQuery = string.Format("UPDATE LstInvId SET lastfc={0}, lastlc={1}", _lastFC, _lastLC);
                SqlDataAdapter execute = new SqlDataAdapter(updateQuery, conn);
                execute.SelectCommand.ExecuteNonQuery();
                conn.Close();
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
            DB_CONNECTION x = new DB_CONNECTION();
            using (SqlConnection conn = x.getConnection())
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
            }

            //string GetData = "Select [FC_Rate] from F_Currency where FC_TYPE ='" + cmbCurrency1.Text + "' ";
            //cmd = new SqlCommand(GetData, conn);
            //var returnValue = cmd.ExecuteScalar();
            //txtRate1.Text = returnValue.ToString();
            //conn.Close();
        }

        private void btnaddstock_Click(object sender, EventArgs e)
        {

        }
    }
}
