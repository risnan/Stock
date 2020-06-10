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
    public partial class Stock : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");
        

        private static Stock _instance;
        public static Stock Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Stock();
                return _instance;
            }
        }
        public Stock()
        {
            InitializeComponent();
            fill_listbox();
        }

        public void fill_listbox()
        {

            display1();
        }

        public void display1()
        {
            listBox1.Items.Clear();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Supplier ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["ProductName"].ToString());
                // listBox1.Items.Add(dr["ProductCode"].ToString());
            }
            con.Close();



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
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Product WHERE ItemName LIKE '%" + textBox5.Text + "%'", con);
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Product WHERE ItemName LIKE '" + textBox5.Text + "%'", con);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            // textBox9.Clear();
            textBox1.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="" || textBox3.Text=="" || textBox4.Text=="" || textBox6.Text=="" || textBox7.Text=="" || textBox8.Text=="")
            {
                MessageBox.Show("Need to fill all the fields ...");
            }
            else if (Convert.ToInt32(textBox7.Text) > 0 && Convert.ToInt32(textBox4.Text) > 0 && Convert.ToInt32(textBox6.Text) > 0)
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Product(ItemCode,ItemName,Type,OrginalPrice,SalePrice,Quantity,Discount,Date) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Value + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Inserted Successfully");
                con.Close();
                display();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                //textBox9.Clear();
                textBox1.Focus();
            }

            else
            {
                MessageBox.Show("INVALID","MESSAGE",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
           

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Need to fill all the fields ...");
            }
            else if (Convert.ToInt32(textBox7.Text) > 0 && Convert.ToInt32(textBox4.Text) > 0 && Convert.ToInt32(textBox6.Text) > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE       Product
SET                ItemCode ='" + textBox1.Text + "', ItemName ='" + textBox2.Text + "',Type ='" + textBox3.Text + "',OrginalPrice ='" + textBox4.Text + "',SalePrice ='" + textBox6.Text + "',Quantity ='" + textBox7.Text + "', Discount ='" + textBox8.Text + "',Date='" + dateTimePicker1.Value + "' WHERE    (ItemCode ='" + textBox1.Text + "')", con);
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Need to fill all the fields ...");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"DELETE FROM Product WHERE (ItemCode='" + textBox1.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Succesfuly.....!");
                display();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Supplier where ProductName ='" + listBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["ProductID"].ToString();
                textBox2.Text = dr["ProductName"].ToString();
                textBox3.Text = dr["Type"].ToString();
                textBox4.Text = dr["Price"].ToString();
                textBox7.Text = dr["Quantity"].ToString();

            }

            con.Close();
        }
    }
}
