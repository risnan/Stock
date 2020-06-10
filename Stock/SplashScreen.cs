using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Stock
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {

            InitializeComponent();
        }
        public int TimeLeft { get; set; }

        private void progressBar1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
        }

        private void SplashScreen_Load_1(object sender, EventArgs e)
        {
            TimeLeft = 40;
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            if (TimeLeft > 0)
            {
                TimeLeft = TimeLeft - 1;
            }
            else
            {
                timer1.Stop();
                Login main = new Login();
                main.StartPosition = FormStartPosition.CenterScreen;
                main.Show();
                this.Hide();
            }
        }
    }
}
