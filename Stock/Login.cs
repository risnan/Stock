using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Stock
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");
        public Login()
        {
           // Thread t = new Thread(new ThreadStart(StartForm));
           // t.Start();
           // Thread.Sleep(5000);  
            InitializeComponent();
          // t.Abort();
        }

      //  public void StartForm()
      //  {
           // Application.Run(new SplashScreen());
      //  }


        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select * From Login Where UserName='" + Textbox1.Text + "' and Password='" + Textbox2.Text + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            errorProvider1.Clear();

            if (dt.Rows.Count == 1)
            {
                Main main = new Main();
                main.StartPosition = FormStartPosition.CenterScreen;
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or password...!", "Aleart", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // button1_Click(sender, e);
                errorProvider1.SetError(Textbox1, "incorrect usr name");
                errorProvider1.SetError(Textbox2, "incorrect password");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Enter)
            {
                Textbox2.Focus();
            }
        }

        private void Textbox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            button1.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword main = new ChangePassword();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }
    }
}

