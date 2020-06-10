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
    public partial class Report1 : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-08C4FIV\SQLEXPRESS;Initial Catalog=stock;Integrated Security=True");


        private static Report1 _instance;
        public static Report1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Report1();
                return _instance;
            }
        }
        public Report1()
        {
            InitializeComponent();
        }

        private void Report1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Form2 main = new Form2();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Form3 main = new Form3();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
        }
    }
}
