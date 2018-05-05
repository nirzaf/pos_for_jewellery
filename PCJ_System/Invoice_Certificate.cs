using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCJ_System
{
    public partial class Invoice_Certificate : UserControl
    {
        public Invoice_Certificate()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            In_certi open = new In_certi();
            open.Show();
        }
    }
}
