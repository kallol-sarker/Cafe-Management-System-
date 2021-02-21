using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 f2 = new Form2(this);
            f2.Visible = true;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form4 f2 = new Form4(this);
            f2.Visible = true;
        }
    }
}
