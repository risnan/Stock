using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace Stock
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(Local);Initial Catalog=Stock;Integrated Security=True");
        ReportDocument cry = new ReportDocument();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cry.Load(@"C:\Users\BLACKART\Documents\Visual Studio 2015\Projects\Stock\Stock\CrystalReport1.rpt");

            SqlDataAdapter sda = new SqlDataAdapter("Select * from Salses", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cry.SetDataSource(dt);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}
