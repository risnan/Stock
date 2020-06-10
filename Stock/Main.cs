using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Main : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");


        Timer t = new Timer();
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (!panel3.Controls.Contains(Stock.Instance))
           {
               panel3.Controls.Add(Stock.Instance);
               Stock.Instance.Dock = DockStyle.Fill;
               Stock.Instance.BringToFront();
           }
           else
               Stock.Instance.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            About main = new About();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
           // this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Customer.Instance))
            {
                panel3.Controls.Add(Customer.Instance);
                Customer.Instance.Dock = DockStyle.Fill;
                Customer.Instance.BringToFront();
            }
            else
                Customer.Instance.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Stting.Instance))
            {
                panel3.Controls.Add(Stting.Instance);
                Stting.Instance.Dock = DockStyle.Fill;
                Stting.Instance.BringToFront();
            }
            else
                Stting.Instance.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Report1.Instance))
            {
                panel3.Controls.Add(Report1.Instance);
                Report1.Instance.Dock = DockStyle.Fill;
                Report1.Instance.BringToFront();
            }
            else
                Report1.Instance.BringToFront();
        }

       
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            StockMain main = new StockMain();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click_1(object sender, EventArgs e)
        {
            Login main = new Login();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            StockMain main = new StockMain();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Supplier.Instance))
            {
                panel3.Controls.Add(Supplier.Instance);
                Supplier.Instance.Dock = DockStyle.Fill;
                Supplier.Instance.BringToFront();
            }
            else
                Supplier.Instance.BringToFront();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product where Quantity='0'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin main = new Admin();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                try
                {
                    string url = "http://smsc.vianett.no/v3/send.ashx?"+
                                  "src="+textBox2.Text+"&"+
                                  "dst="+textBox2.Text+"&"+
                                  "msg="+System.Web.HttpUtility.UrlEncode(textBox3.Text,System.Text.Encoding.GetEncoding("ISO-8859-1"))+""+
                                  "username="+System.Web.HttpUtility.UrlEncode(textBox1.Text);
                    string result = client.DownloadString(url);
                    if (result.Contains("OK"))
                        MessageBox.Show("Your message has been successfully send.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Message send failure.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                Stream s = client.OpenRead("");
                StreamReader reader = new StreamReader(s);
                string result = reader.ReadToEnd();
                MessageBox.Show(result, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information); 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
