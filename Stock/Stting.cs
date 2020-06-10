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
    public partial class Stting : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");


        private static Stting _instance;
        public static Stting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Stting();
                return _instance;
            }
        }

        public Stting()
        {
            InitializeComponent();
        }

        private void BACKUP_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Stock = con.Database.ToString();
            try
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("Please enter backup file location");
                }
                else
                {
                    string cmd = "BACKUP DATABASE [" + Stock + "] TO DISK='" + textBox1.Text + "\\" + "Stock" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH--mm--ss") + ".bak'";
                    using(SqlCommand command=new SqlCommand(cmd, con))
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();

                        }
                        command.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("database backup done successefully");
                        button1.Enabled = false;
                    }
                }
            }
            catch
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter="SQL SERVER Stock backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
                button3.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Stock = con.Database.ToString();
            try
            {

            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
