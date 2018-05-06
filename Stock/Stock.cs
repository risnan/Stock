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
        SqlConnection con = new SqlConnection("Data Source=(Local);Initial Catalog=Stock;Integrated Security=True");


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
        }

        private void button2_Click(object sender, EventArgs e)
        {
         }

        public void display()
        {

            SqlDataAdapter sda = new SqlDataAdapter("Select * from Product", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            display();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
