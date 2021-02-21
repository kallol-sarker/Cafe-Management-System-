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
    public partial class Form3 : Form
    {

        private Form2 F2 { get; set; }
        private Data_Access Da { get; set; }
        private DataSet Ds { get; set; }
        internal string Sql { get; set; }

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(Form2 f2)
        {
            InitializeComponent();
            this.F2 = f2;

            this.Da = new Data_Access();
            string sql = "select * from Food;";
            this.PopulateGrideView(sql);
        }


        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnGoBackHome_Click(object sender, EventArgs e)
        {
            this.F2.Visible = true;
            this.Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            this.PopulateGrideView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Sql = "select * from Food where FoodName = '" + this.txtSearch.Text + "' ;";
            this.PopulateGrideView(this.Sql);
            txtSearch.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtFoodCodeAdmin.Text == "" || txtFoodNameAdmin.Text == "" || txtPriceAdmin.Text == "")
            {
                MessageBox.Show("Null Value not accpetable!");
            }
            else
            {
                try
                {
                    string que = "insert into Food values ('" + this.txtFoodCodeAdmin.Text + "','" + this.txtFoodNameAdmin.Text + "','" + this.txtPriceAdmin.Text + "');";
                    int count = this.Da.ExecuteUpdateQuery(que);

                    if (count == 1)
                        MessageBox.Show("Data inserted successfully");
                    else
                        MessageBox.Show("Error while inserting data");

                    this.PopulateGrideView();

                    txtFoodCodeAdmin.Text = "";
                    txtFoodNameAdmin.Text = "";
                    txtPriceAdmin.Text = "";
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?","Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    var FC = this.dgvFoodAdmin.CurrentRow.Cells[0].Value.ToString();

                    this.Sql = "delete from Food where [FoodCode] = '" + FC + "'; ";
                    int count = this.Da.ExecuteUpdateQuery(this.Sql);

                    if (count == 1)
                        MessageBox.Show("One row deleted!");
                    else
                        MessageBox.Show("Error while deleting data");

                    this.PopulateGrideView();

                    txtFoodCodeAdmin.Text = "";
                    txtFoodCodeAdmin.Text = "";
                    txtPriceAdmin.Text = "";

                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error: " + exc.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
            
        }

        public void PopulateGrideView(string sql = "select * from Food;")
        {
            this.Ds = this.Da.ExecuteQuery(sql);

            this.dgvFoodAdmin.AutoGenerateColumns = false;
            this.dgvFoodAdmin.DataSource = this.Ds.Tables[0];
        }

        private void dgvFoodAdmin_DoubleClick(object sender, EventArgs e)
        {
            this.txtFoodCodeAdmin.Text = this.dgvFoodAdmin.CurrentRow.Cells["FoodCode"].Value.ToString();
            this.txtFoodNameAdmin.Text = this.dgvFoodAdmin.CurrentRow.Cells["FoodName"].Value.ToString();
            this.txtPriceAdmin.Text = this.dgvFoodAdmin.CurrentRow.Cells["Price"].Value.ToString();
            txtFoodCodeAdmin.ReadOnly = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Sql = "select * from Food where [FoodCode] = '"+this.txtFoodCodeAdmin.Text+"' ";
            DataTable dt = this.Da.ExecuteQueryTable(this.Sql);

            this.Sql = "update Food set Foodname = '" + this.txtFoodNameAdmin.Text + "', Price = '" + this.txtPriceAdmin.Text + "' where FoodCode = '" + this.txtFoodCodeAdmin.Text + "' ;";

            int count = this.Da.ExecuteUpdateQuery(Sql);

            if (count == 1)
                MessageBox.Show("Data updated successfully");
            else
                MessageBox.Show("Error while updating data");

            this.PopulateGrideView();

            txtFoodCodeAdmin.Text = "";
            txtFoodNameAdmin.Text = "";
            txtPriceAdmin.Text = "";
            txtFoodCodeAdmin.ReadOnly = false;
        }

    }
}
