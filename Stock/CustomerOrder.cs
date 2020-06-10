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

namespace Stock
{
    public partial class CustomerOrder : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");

        public CustomerOrder()
        {
            InitializeComponent();
        }


        public void display()
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select * from Customers  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void display1()
        {

            SqlDataAdapter sda1 = new SqlDataAdapter("Select * from CustomerOrder ", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            dataGridView3.DataSource = dt1;
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView3.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView3.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView3.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView3.SelectedRows[0].Cells[5].Value.ToString();


        }

        private void CustomerOrder_Load_1(object sender, EventArgs e)
        {
            display1();
            display();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox5.Text) > 0)
            {
                con.Open();
            SqlCommand cmd = new SqlCommand("insert into CustomerOrder(CustomerId,CustomerName,Date,OrderId,ItemName,Quantity) values('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Inserted Successfully");
            con.Close();
            display1();
        }

 else
            {
                MessageBox.Show("INVALID", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void dataGridView1_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox5.Text) > 0)
            {
                con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE       CustomerOrder
SET                CustomerId ='" + textBox1.Text + "', CustomerName ='" + textBox2.Text + "',Date ='" + dateTimePicker1.Value + "',OrderId ='" + textBox3.Text + "',ItemName ='" + textBox4.Text + "',Quantity ='" + textBox5.Text + "' WHERE    (OrderId ='" + textBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Succesfuly.....!");
            display1();
        }
             else
            {
                MessageBox.Show("INVALID", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM CustomerOrder WHERE (OrderId='" + textBox3.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Succesfuly.....!");
            display1();
        }
    }
}


