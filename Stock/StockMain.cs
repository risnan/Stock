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
        Timer t = new Timer();
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");

        public StockMain()
        {
            InitializeComponent();
            fill_listbox();
            textBox7.KeyDown += TextBox7_KeyDown;
        }

        private void TextBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox7.Text != null)
                {
                    tex = double.Parse(textBox7.Text);
                    label9.Text = Convert.ToString(tex - Convert.ToDouble(label11.Text));
                }
                else
                {
                    label9.Text = "0.00";
                }
            }
        }
                                
        public void fill_listbox()
        {
           
            display();
        }
        public void display()
        {
            listBox1.Items.Clear();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product where Quantity > 0", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["ItemName"].ToString());
               // listBox1.Items.Add(dr["ProductCode"].ToString());
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
            cmd.CommandText = "Select * from Product where ItemName ='" + listBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["ItemCode"].ToString();
                textBox8.Text=dr["Quantity"].ToString();
                textBox3.Text = dr["ItemName"].ToString();
                textBox6.Text = dr["Discount"].ToString();
                textBox4.Text = dr["SalePrice"].ToString();

            }
           
            con.Close();
            if (Convert.ToInt32(textBox8.Text)==0)
            {
               
               // label16.Text = "There is No Available Quantity of This item";
                MessageBox.Show("There is No Available Quantity of This item");

            }
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
           

            con.Open();
            SqlCommand cmd1 = new SqlCommand("insert into Salses(SN,ProductName,UnitPrice,TotalPrice,DiscountGiven,Quantity,Balance) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + label11.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + label9.Text + "')", con);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Record Inserted Successfully","message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            con.Close();
            display1();


            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE Product SET Quantity = Quantity-'" + Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString()) + "'  WHERE    (ItemCode ='" + textBox2.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                display1();

                textBox7.Text = "0.00";
                label11.Text = "0.00";
                label9.Text = "0.00";
                textBox8.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";


                // Form2 main = new Form2();
                // main.StartPosition = FormStartPosition.CenterScreen;
                // main.Show();





            }
        }
        public void display1()
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           
            con.Close();

          
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

        private void StockMain_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }
        private void t_Tick(object sender, EventArgs e)
        {

            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            label13.Text = time;

        }

      
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
          //  textBox9.Text = dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Login main = new Login();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }

        private void textBox7_OnValueChanged(object sender, EventArgs e)
        {
           // label9.Text = "0";
            //tex = double.Parse(textBox7.Text);
            //label9.Text = Convert.ToString(tex-Convert.ToDouble(label11.Text)); 
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           // label11.Text = "0.00";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                label11.Text = Convert.ToString(Convert.ToDouble(label11.Text) + Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value.ToString()));
            }
        }
       // private int a = 1;
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (Convert.ToInt32(textBox5.Text) < 0)
            {
                MessageBox.Show("Invalid number");
            }
            else
            {
                if (Convert.ToInt32(textBox5.Text) > Convert.ToInt32(textBox8.Text))
                {
                   // label16.Text = "Please enter lower quantity";
                    MessageBox.Show("Please enter lower quantity");
                }
                else
                {
                    rate = double.Parse(textBox4.Text);
                    quantity = double.Parse(textBox5.Text);
                    discount = double.Parse(textBox6.Text);
                    discountGiven = rate * (discount / 100) * quantity;
                    amount = rate * quantity - discountGiven;

                    dataGridView1.Rows.Add(textBox2.Text, textBox3.Text, rate, quantity, discount, amount, discountGiven);
                }
            }
           // textBox3.Text = " ";
          //  textBox4.Text = "0.00";
          //  textBox5.Text = " ";
          //  textBox6.Text = "0.00 ";
          //  textBox8.Text = "0";
            textBox7.Focus();

           // a++;
           // textBox2.Text = a.ToString();
        }

       
       
    }
}
