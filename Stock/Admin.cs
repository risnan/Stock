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
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");

        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Login Where UserName='" + textBox1.Text + "' and Password='" + textBox2.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            errorProvider1.Clear();
            if (dt.Rows.Count == 1)
            {
                if (textBox3.Text==textBox4.Text)
                {
                    SqlDataAdapter cmd = new SqlDataAdapter("update Login set Password='"+textBox3.Text+ "' where UserName='" + textBox1.Text + "' and Password='" + textBox2.Text + "'",con);
                    DataTable df = new DataTable();
                    cmd.Fill(df);
                    MessageBox.Show("Password Changed..!!","message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

                else
                {
                    errorProvider1.SetError(textBox3, "Unmatch Password");
                    errorProvider1.SetError(textBox4,"Unmatch password");
                }
            }
            else
            {
                errorProvider1.SetError(textBox1, "incorrect usr name");
                errorProvider1.SetError(textBox2, "incorrect password");
            }
        }
    }
}
