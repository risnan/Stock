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
    public partial class Product : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=(Local);Initial Catalog=Stock;Integrated Security=True");
        

        private static Product _instance;
        public static Product Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Product();
                return _instance;
            }
        }
        public Product()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
           
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Product(ProductCode,ProductName,Price,Quantity,TransDate,ProductStatus) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value + "','" + comboBox1.Text + "')", con);
             cmd.ExecuteNonQuery();
             MessageBox.Show("Record Inserted Successfully");
            con.Close();
            display();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }
        public void display()
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           // dataGridView1.SelectedRows[0].Cells[3].Value= dateTimePicker1.Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
                con.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM Product WHERE (ProductCode='" + textBox1.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Succesfuly.....!");
            display();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE       Product
SET                ProductCode ='" + textBox1.Text + "', ProductName ='" + textBox2.Text + "',Price ='" + textBox3.Text + "',Quantity ='" + textBox4.Text + "',TransDate ='" + dateTimePicker1.Value + "', ProductStatus ='" + comboBox1.Text + "'WHERE    (ProductCode ='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Succesfuly.....!");
            display();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                dateTimePicker1.Focus();
            }
            
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
               comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                button4.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           // textBox5.Text = "";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Product WHERE ProductName LIKE '%" + textBox5.Text + "%'", con);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           // textBox5.Text = "";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Product WHERE ProductName LIKE '" + textBox5.Text + "%'", con);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
