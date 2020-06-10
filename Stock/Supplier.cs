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
    public partial class Supplier : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");


        private static Supplier _instance;
        public static Supplier Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Supplier();
                return _instance;
            }
        }

        public Supplier()
        {
            InitializeComponent();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox10.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Need to fill all the fields ...");
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM Supplier WHERE (SupplierID='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Succesfuly.....!");
            display();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox10.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Need to fill all the fields ...");
            }
            else if (Convert.ToInt32(textBox9.Text) > 0 && Convert.ToInt32(textBox8.Text) > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Supplier(SupplierID,SupplierName,Tel,Email,ProductID,ProductName,Type,Price,Quantity,Date) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox10.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + dateTimePicker1.Value + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted Successfully");
                con.Close();
                display();


                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox10.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("INVALID", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void display()
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select * from Supplier", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox10.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Need to fill all the fields ...");
            }
            else if (Convert.ToInt32(textBox9.Text) > 0 && Convert.ToInt32(textBox8.Text) > 0)
            {
                con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE       Supplier
SET                SupplierID ='" + textBox1.Text + "', SupplierName ='" + textBox2.Text + "',Tel ='" + textBox3.Text + "',Email ='" + textBox4.Text + "',ProductID ='" + textBox10.Text + "',ProductName ='" + textBox6.Text + "',Type ='" + textBox7.Text + "',Price ='" + textBox8.Text + "', Quantity ='" + textBox9.Text + "',Date='" + dateTimePicker1.Value + "' WHERE    (SupplierID ='" + textBox1.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Succesfuly.....!");
            display();
        }

             else
            {
                MessageBox.Show("INVALID", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox10.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox1.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox10.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Supplier WHERE SupplierName LIKE '%" + textBox5.Text + "%'", con);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
