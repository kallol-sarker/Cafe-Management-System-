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
    public partial class Form2 : Form
    {
        private Form1 F1 { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public Form2(Form1 f1)
        {
            InitializeComponent();
            this.F1 = f1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.F1.Visible = true;
            this.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if( txtUserName.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("User name and password cannot be empty!");
            }

            else if (txtUserName.Text == "")
            {
                MessageBox.Show("User name cannot be empty!");
            }

            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password cannot be empty!");
            }

            else if (txtUserName.Text == "Admin" && txtPassword.Text == "1234")
            {
                this.Visible = false;
                Form3 f3 = new Form3(this);
                f3.Visible = true;
            }

            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }
    }
}
