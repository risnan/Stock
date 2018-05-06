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
    public partial class StockMain : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(Local);Initial Catalog=Stock;Integrated Security=True");


        public StockMain()
        {
            InitializeComponent();
            fill_listbox();

        }

        public void fill_listbox()
        {
           
            display();
        }
        public void display()
        {
            listBox1.Items.Clear();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["ProductName"].ToString());
            }
            con.Close();

        

        }

        double rate,amount,discountGiven, discount, quantity, tex;

        private void button5_Click(object sender, EventArgs e)
        {
           // listBox1.SelectedItems.Clear();
            for (int x = listBox1.Items.Count - 1;  x >= 0; x--){
                if (listBox1.Items[x].ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listBox1.SetSelected(x, true);
                }
            } 
             
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Product where ProductName ='" + listBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox8.Text=dr["Quantity"].ToString();
                textBox3.Text = dr["ProductName"].ToString();
               // textBox1.Text = dr["ProductName"].ToString();
                textBox4.Text = dr["Price"].ToString();

            }
           
            con.Close();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // float q1;
          //  q1 = float.Parse(textBox8.Text) - float.Parse(textBox5.Text);
           
           

            Print main = new Print();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();

            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();

            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                button1.Focus();

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_OnValueChanged(object sender, EventArgs e)
        {
           // label9.Text = "0";
             tex = double.Parse(textBox7.Text);
            label9.Text = Convert.ToString(Convert.ToDouble(label11.Text) - tex); 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label11.Text = "0";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                label11.Text = Convert.ToString(Convert.ToDouble(label11.Text) + Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value.ToString()));
            }
        }
        private int a = 1;
        private void button1_Click_1(object sender, EventArgs e)
        {
            rate = double.Parse(textBox4.Text);
            quantity = double.Parse(textBox5.Text);
            discount = double.Parse(textBox6.Text);
            discountGiven = rate * (discount / 100) * quantity;
            amount = rate * quantity - discountGiven;

            dataGridView1.Rows.Add(textBox2.Text, textBox3.Text, rate, quantity, discount, amount, discountGiven);

            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox8.Text = "";
            textBox7.Focus();

            a++;
            textBox2.Text = a.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main main =new Main();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();          
        }
       
    }
}
