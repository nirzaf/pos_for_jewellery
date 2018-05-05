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

namespace PCJ_System
{
    public partial class Admin_Menu : Form
    {

        SqlConnection conn;
        Bunifu.Framework.UI.Drag MoveForm = new Bunifu.Framework.UI.Drag();
        public Admin_Menu()
        {
            InitializeComponent();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Login open = new Login();
            open.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
                      newUser1.BringToFront();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
          outStanding_of_Stocks1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
        status_of_Stocks1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
          dashBoard1.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           invoice_Certificate2.BringToFront();
            //invoice_Certificate1.BringToFront();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            stocks_Jewelry1.BringToFront();
            
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
           stocks_Jewelry1.BringToFront();
            
            
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
          stocks_Gems1.BringToFront();
           

        }

        private void bunifuFlatButton5_Click_1(object sender, EventArgs e)
        {
          outStanding_of_Stocks1.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            hello.Text = GlobalVariablesClass.VariableOne;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Menu_Load(object sender, EventArgs e)
        {
            /*conn.Open();
            SqlCommand selectCommand = new SqlCommand(" Select * from New_User where User_Name = @USER_ID and Password = @PASS", conn);
            //add parametars if not added (i've added "sam" and "123" just for example, you should change this to strings that user types when login"
            // Login m= new Login();

            string UserType = "";
            SqlDataReader reader = selectCommand.ExecuteReader();
            selectCommand.Parameters.Add("@USER_ID", SqlDbType.VarChar).Value = "";
            selectCommand.Parameters.Add("@PASS", SqlDbType.VarChar).Value = "";

            using (SqlDataReader sdr = selectCommand.ExecuteReader())
            {
                UserType = sdr.GetString(1); //<= try not to type hard string this will return the string value of the column index you enter 

                if (UserType == "Administrator")
                {
                    bunifuFlatButton3.Visible = true;
                }
                else if (UserType == "StockController")

                {
                    bunifuFlatButton3.Visible = false;
                }
            }*/





            /*   if (!(HttpContext.Current.User == null))
   {
      if (HttpContext.Current.User.Identity.AuthenticationType == "Forms" )
      {
      System.Web.Security.FormsIdentity id;
      id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
      String[] myRoles = new String[2];
      myRoles[0] = "Manager";
      myRoles[1] = "Admin";
      HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id,myRoles);
      }*/
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            scStocks_Jewelry1.BringToFront();
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            scStocks_Gems1.BringToFront();
        }
    }
    }

