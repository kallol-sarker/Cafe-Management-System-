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
    public partial class Form4 : Form
    {
        private Form1 F1 { get; set; }
        private Data_Access Da { get; set; }
        private DataSet Ds { get; set; }
        internal string Sql { get; set; }

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(Form1 f1)
        {
            InitializeComponent();
            this.F1 = f1;

            this.Da = new Data_Access();
            string sql = "select * from Food;";
            this.PopulateGrideView(sql);
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void PopulateGrideView(string sql = "select * from Food;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dgvFood.AutoGenerateColumns = false;
            this.dgvFood.DataSource = this.Ds.Tables[0];
        }

        private void btnBackHome_Click(object sender, EventArgs e)
        {
            this.F1.Visible = true;
            this.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Sql = "select * from Food where FoodName = '" + this.txtSearch.Text + "';";
            this.PopulateGrideView(this.Sql);
            txtSearch.Text = "";
        }

        private void btnShowC_Click(object sender, EventArgs e)
        {
            this.PopulateGrideView();
        }

        private void dgvFood_DoubleClick(object sender, EventArgs e)
        {
            this.txtFoodCode.Text = this.dgvFood.CurrentRow.Cells["FoodCode"].Value.ToString();
            this.txtFoodName.Text = this.dgvFood.CurrentRow.Cells["FoodName"].Value.ToString();
            this.txtPrice.Text = this.dgvFood.CurrentRow.Cells["Price"].Value.ToString();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if(txtFoodCode.Text == "" || txtFoodName.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Selet Food by Double click on the list");
            }
            else if(nudQuantity.Text == "0")
            {
                MessageBox.Show("Quantity cannot be 0");
            }
            else
            {
                string Quantity = nudQuantity.Text;
                int qua = Convert.ToInt32(Quantity);

                string Price = txtPrice.Text;
                int price = Convert.ToInt32(Price);


                int total = qua * price;
                string totalPrice = Convert.ToString(total);

                MessageBox.Show(" Total " +Quantity+ " " +this.txtFoodName.Text+ " is ordered and total price is " +totalPrice);
                txtFoodCode.Text = "";
                txtFoodName.Text = "";
                txtPrice.Text = "";
                nudQuantity.Text = "0";
            }
            
        }
    }
}
