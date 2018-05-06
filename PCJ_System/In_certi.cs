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
        private string[] last_amount = { "", "", "" };
        private int nextNumber;
        private List<Image> pics = new List<Image>();
        private List<int> itemIDs = new List<int>();
        private List<String> itemNos = new List<String>();
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

            cmbCurrency1.SelectedIndex = 0;
            cmbCurrency2.SelectedIndex = 1;
            cmbCurrency3.SelectedIndex = 2;

            using (var cmd = new SqlCommand("SELECT * FROM dbo.[Card_Vendor]", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbCardTyp.Items.Add(reader["Vendor"].ToString());
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

            if (txtAmt2.Text != "" && checkBox_disable.Checked)
                amt2 = Convert.ToDouble(txtAmt2.Text);

            if (txtAmt3.Text != "" && checkBox_disable.Checked)
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

            CalculateTotal();
        }

        private void ST_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbItmTyp.SelectedIndex == 0)
            {
                txtNoPieces.Visible = true;
                lblNoPieces.Visible = true;
                txtCost.Visible = true;
                lblCost.Visible = true;
                txtGemWeight.Visible = true;
                lblGemWeight.Visible = true;
                txtSpecification.Visible = true;
                lblSpecification.Visible = true;
                btnaddstock.Enabled = true;
                btnremovestock.Enabled = true;
            }
            else if (cmbItmTyp.SelectedIndex == 1)
            {
                txtNoPieces.Visible = false;
                lblNoPieces.Visible = false;
                txtCost.Visible = false;
                lblCost.Visible = false;
                txtGemWeight.Visible = false;
                lblGemWeight.Visible = false;
                txtSpecification.Visible = false;
                lblSpecification.Visible = false;
                btnremovestock.Enabled = true;
                btnaddstock.Enabled = true;
            }
            else
            {
                btnremovestock.Enabled = false;
                btnaddstock.Enabled = false;
                return;
            }

            textBox1.Text = "";
            textBox1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnremovestock_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (cmbItmTyp.SelectedIndex == 0)
            {
                TextBox[] textboxes = { txtNoPieces, txtGemWeight, txtCost };
                bool isValid = true;

                foreach (TextBox t in textboxes)
                {
                    if (t.Text.Length <= 0)
                    {
                        errorProvider1.SetError(t, "Cannot be Empty!!");
                        isValid = false;
                    }
                }

                if (!isValid)
                {
                    return;
                }

            }

            for (int i = 0; i < dt.Rows.Count; ++i) {
                    if (dt.Rows[i][2].ToString() == textBox1.Text)
                    {
                        dgvItem.Rows[i].Selected = true;
                        return;
                    }
            }

            Match m = Regex.Match(textBox1.Text, "([a-zA-Z]+)([0-9]+)");
            if (m.Groups.Count != 2)
            {
                // do nothing
                return;
            }

            using (var command = new SqlCommand("SELECT * FROM AvailableItems WHERE StockNo=@StockNo AND StockID=@StockID", conn))
            {
                command.Parameters.AddWithValue("StockID", m.Groups[0].Value.ToString());
                command.Parameters.AddWithValue("StockNo", m.Groups[1].Value.ToString());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var row = dt.NewRow();
                        row[0] = dt.Rows.Count + 1;
                        row[1] = reader["StockType"].ToString();
                        row[2] = String.Format("{0}{1:D4}", reader["StockNo"].ToString(), Int32.Parse(reader["StockID"].ToString()));

                        if (cmbItmTyp.SelectedIndex == 0)
                        {
                            // gem
                            row[3] = txtNoPieces.Text;
                            row[4] = String.Format("{0} {1}cts ", reader["GemType"], txtGemWeight.Text);
                            row[5] = txtCost.Text;
                            row[6] = txtGemWeight.Text;
                            row[7] = txtSpecification.Text;

                            // MessageBox.Show(reader["No_of_pieces"].ToString());
                            bool noerrors = true;

                            if (Int32.Parse(row[3].ToString()) > Int32.Parse(reader["Quantity"].ToString()))
                            {
                                errorProvider1.SetError(txtNoPieces, "Entered no of pieces is too high!");
                                noerrors = false;
                            }

                            if (Double.Parse(row[5].ToString()) > Double.Parse(reader["Cost"].ToString()))
                            {
                                errorProvider1.SetError(txtCost, "Enter cost is too high");
                                noerrors = false;
                            }

                            if (Double.Parse(row[6].ToString()) > Double.Parse(reader["Weight"].ToString()))
                            {
                                MessageBox.Show(txtGemWeight, "Wight enter is too high");
                                noerrors = false;
                            }

                            if (!noerrors)
                            {
                                return;
                            }
                        }
                        else if (cmbItmTyp.SelectedIndex == 1)
                        {
                            // jewellery
                            string desc = String.Format("{0} {1} with {2} {3} {4}cts", reader["Description"], reader["ItemType"], reader["NoOfGems"], reader["GemType"], reader["Weight"]);
                            if (Int32.Parse(reader["NoOfOtherGems"].ToString()) != 0)
                            {
                                desc = String.Format("{0} & {1} {2} {3}cts", desc, reader["NoOfOtherGems"], reader["OtherGemType"], reader["WeightOfOtherGems"]);
                            }

                            row[4] = desc;
                            row[5] = reader["Cost"];
                            row[3] = reader["Quantity"];
                        }

                        byte[] pic = reader["Image"] as byte[];
                        MemoryStream ms = new MemoryStream(pic);
                        pics.Add(Image.FromStream(ms));
                        itemIDs.Add(Int32.Parse(reader["StockID"].ToString()));
                        itemNos.Add(reader["StockNo"].ToString());

                        ClearPurchase();
                        dt.Rows.Add(row);
                        dgvItem.RefreshEdit();
                    }
                }
            }
        }

        private void ClearPurchase()
        {
            cmbItmTyp.SelectedIndex = -1;
            textBox1.Text = "";
            txtNoPieces.Visible = false;
            lblNoPieces.Visible = false;
            txtCost.Visible = false;
            lblCost.Visible = false;
            txtGemWeight.Visible = false;
            lblGemWeight.Visible = false;
            txtSpecification.Visible = false;
            lblSpecification.Visible = false;

            textBox1.Enabled = false;
            txtSpecification.Text = "";
            txtGemWeight.Text = "";
            txtCost.Text = "";
            txtNoPieces.Text = "";
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
            {
                getNextNumber("FC");
                txtInvNo.Text = string.Format("CMB-{0:000}-FC", nextNumber);
            }
            else
            {
                getNextNumber("LC");
                txtInvNo.Text = string.Format("CMB-{0:000}-LC", nextNumber);
            }

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
            errorProvider1.Clear();

            bool noerrors = true;

            if (txtInvNo.Text.Length <= 0)
            {
                errorProvider1.SetError(txtInvNo, "Please select the invoice type!!");
                noerrors = false;
            }

            if (cmbTitle.Text.Length <= 0)
            {
                errorProvider1.SetError(cmbTitle, "Select the Customer Title");
                noerrors = false;
            }

            if (txtCusNm.Text.Length <= 0)
            {
                errorProvider1.SetError(txtCusNm, "Enter Customer Name");
                noerrors = false;
            }

            if (txtAddress.Text.Length <= 0)
            {
                errorProvider1.SetError(txtAddress, "Enter the Customer Address");
                noerrors = false;
            }

            if (txtTotalAmount.Text.Length <= 0)
            {
                errorProvider1.SetError(txtTotalAmount, "The Total Amount cannot be empty!!");
                noerrors = false;
            }

            if (!noerrors)
            {
                return;
            }

            try
            {
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string invType = null;
                    if (cmbInvTyp.SelectedIndex == 0)
                    {
                        invType = "FC";
                    }
                    else if (cmbInvTyp.SelectedIndex == 1)
                    {
                        invType = "LC";
                    }

                    int id = nextNumber;

                    SqlCommand command = new SqlCommand("INSERT INTO Invoice (Invoice_No,Invoice_Date,Invoice_Type) VALUES (@id,@date,@type)", conn, transaction);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("date", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("type", invType);
                    command.ExecuteNonQuery();

                    command = new SqlCommand("INSERT INTO Customer VALUES(@id,@type,@name,@title,@address)", conn, transaction);
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("type", invType);
                    command.Parameters.AddWithValue("name", txtCusNm.Text);
                    command.Parameters.AddWithValue("title", cmbTitle.SelectedItem.ToString());
                    command.Parameters.AddWithValue("address", txtAddress.Text);
                    command.ExecuteNonQuery();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        float qty = (float)(dt.Rows[i][3].ToString() != "" ? Convert.ToDouble(dt.Rows[i][3].ToString()) : 0);
                        float weight = (float)(dt.Rows[i][6].ToString() != "" ? Convert.ToDouble(dt.Rows[i][6].ToString()) : 0);
                        float cost = (float)(dt.Rows[i][5].ToString() != "" ? Convert.ToDouble(dt.Rows[i][5].ToString()) : 0);

                        command = new SqlCommand("INSERT INTO Purchase VALUES(@inv,@type,@lino,@ItemID,@ItemNo,@cost,@qty,@weight,@spec)", conn, transaction);
                        command.Parameters.AddWithValue("inv", id);
                        command.Parameters.AddWithValue("type", invType);
                        command.Parameters.AddWithValue("lino", dt.Rows[i][0]);
                        command.Parameters.AddWithValue("ItemID", itemIDs[i]);
                        command.Parameters.AddWithValue("ItemNo", itemNos[i]);
                        command.Parameters.AddWithValue("cost", cost);
                        command.Parameters.AddWithValue("qty", qty);
                        command.Parameters.AddWithValue("weight", weight);
                        command.Parameters.AddWithValue("spec", dt.Rows[i][7]);
                        command.ExecuteNonQuery();

                        // update stock
                        command = new SqlCommand("UPDATE Status_Of_Stocks SET Qty=Qty-@qty, Weight=Weight-@weight, cost=cost-@cost WHERE StockId=@StockID AND StockNo=@StockNo", conn, transaction);
                        command.Parameters.AddWithValue("StockID", itemIDs[i]);
                        command.Parameters.AddWithValue("StockNo", itemNos[i]);
                        command.Parameters.AddWithValue("cost", cost);
                        command.Parameters.AddWithValue("qty", qty);
                        command.Parameters.AddWithValue("weight", weight);
                    }

                    if (cmbPaymentTyp.SelectedIndex > 0 && cmbCardTyp.SelectedIndex != -1 && cmbCardTyp.Text.Length != 0)
                    {
                        command = new SqlCommand("INSERT INTO Card_Payment VALUES(@inv,@type,@amount,@vendor,@type)", conn, transaction);
                        command.Parameters.AddWithValue("inv", id);
                        command.Parameters.AddWithValue("type", invType);
                        command.Parameters.AddWithValue("amount", txtcardamt.Text);
                        command.Parameters.AddWithValue("vendor", cmbCardTyp.SelectedItem.ToString());
                        command.Parameters.AddWithValue("type", cmbPaymentTyp.SelectedItem.ToString());
                        command.ExecuteNonQuery();
                    }

                    if (txtAmt1.Text != "") 
                    {
                        var cashPayments = new[] {
                            new { CurrencyType = cmbCurrency1.SelectedItem.ToString(), Amount = txtAmt1.Text, Rate = txtRate1.Text, Use = true, Number = 1},
                            new { CurrencyType = cmbCurrency2.SelectedItem.ToString(), Amount = txtAmt2.Text, Rate = txtRate2.Text, Use = checkBox_disable.Checked && txtAmt2.Text != "", Number = 2},
                            new { CurrencyType = cmbCurrency3.SelectedItem.ToString(), Amount = txtAmt3.Text, Rate = txtRate3.Text, Use = checkBox_disable.Checked && txtAmt3.Text != "" && txtAmt2.Text != "", Number = 3}
                        };

                        foreach (var cashPayment in cashPayments)
                        {
                            if (cashPayment.Use)
                            {
                                command = new SqlCommand("INSERT INTO Cash_Payment VALUES(@inv,@itype,@ctype,@cno,@rate,@amt)", conn, transaction);
                                command.Parameters.AddWithValue("inv", id);
                                command.Parameters.AddWithValue("itype", invType);
                                command.Parameters.AddWithValue("ctype", cashPayment.CurrencyType);
                                command.Parameters.AddWithValue("cno", cashPayment.Number);
                                command.Parameters.AddWithValue("rate", cashPayment.Rate);
                                command.Parameters.AddWithValue("amt", cashPayment.Amount);
                                command.ExecuteNonQuery();
                            }
                        }

                    }

                    transaction.Commit();
                    // disable item stuff
                    groupBox2.Enabled = false;

                    // disable save button
                    MessageBox.Show("You've inserted successfully!", "Successful Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getNextNumber(string type)
        {
            using (var command = new SqlCommand("SELECT TOP 1 Invoice_No FROM dbo.Invoice WHERE Invoice_Type=@type ORDER BY Invoice_No DESC", conn))
            {
                command.Parameters.AddWithValue("@type", type);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nextNumber = Int32.Parse(reader[0].ToString()) + 1;
                        return;
                    }
                }
            }

            nextNumber = 1;
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
            Match m = Regex.Match(textBox1.Text, "([a-zA-Z]+)([0-9]+)");
            if (m.Groups.Count != 2)
            {
                // do nothing
                return;
            }

            using (var command = new SqlCommand("SELECT TOP 1 * FROM dbo.AvailableItems WHERE StockNo=@StockNo AND StockID=@StockID AND StcokType=@StockType", conn))
            {
                command.Parameters.AddWithValue("StockID", m.Groups[0].Value.ToString());
                command.Parameters.AddWithValue("StockNo", m.Groups[1].Value.ToString());
                command.Parameters.AddWithValue("StockType", cmbItmTyp.SelectedItem.ToString());

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int qty = Int32.Parse(reader["Quantity"].ToString());
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
                itemIDs.RemoveAt(dgvItem.CurrentRow.Index);
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
