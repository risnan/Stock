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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (!panel3.Controls.Contains(Product.Instance))
           {
               panel3.Controls.Add(Product.Instance);
               Product.Instance.Dock = DockStyle.Fill;
               Product.Instance.BringToFront();
           }
           else
               Product.Instance.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockMain main = new StockMain();
            main.StartPosition = FormStartPosition.CenterScreen;
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(BACKUP.Instance))
            {
                panel3.Controls.Add(BACKUP.Instance);
                BACKUP.Instance.Dock = DockStyle.Fill;
                BACKUP.Instance.BringToFront();
            }
            else
                BACKUP.Instance.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
