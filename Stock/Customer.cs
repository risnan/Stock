using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stock
{
    public partial class Customer : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");


        private static Customer _instance;
        public static Customer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Customer();
                return _instance;
            }
        }
        public Customer()
        {
            InitializeComponent();
        }


        public void display()
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select * from Customers", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

   

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
       
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                con.Open();
            SqlCommand cmd = new SqlCommand("insert into Customers(CustomerID,FirstName,Tel,Email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Inserted Successfully");
            con.Close();
            display();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE       Customers
SET                CustomerID='" + textBox1.Text + "', FirstName ='" + textBox2.Text + "',Tel ='" + textBox3.Text + "',Email ='" + textBox4.Text + "'  WHERE(CustomerID ='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Succesfuly.....!");
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Customers WHERE (CustomerID='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Succesfuly.....!");
            display();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Customers WHERE FirstName LIKE '%" + textBox5.Text + "%'", con);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void gfgfgfvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerOrder main = new CustomerOrder();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            // this.Hide();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            display();
        }
    }
}
