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


namespace bootchamp5
{
    public partial class YoneticiPaneli : Form
    {
        public YoneticiPaneli()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            pnlScreen.Controls.Clear();
            ApartmanBilgileri ap=new ApartmanBilgileri();
            ap.TopLevel = false;
            pnlScreen.Controls.Add(ap);
            ap.Show();
            ap.Dock = DockStyle.Fill;
            ap.BringToFront();
          

        
        }


        private void YoneticiPaneli_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlScreen.Controls.Clear();
            AidatBilgileri ai = new AidatBilgileri();
            ai.TopLevel = false;
            pnlScreen.Controls.Add(ai);
            ai.Show();
            ai.Dock = DockStyle.Fill;
            ai.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            pnlScreen.Controls.Clear();
            yöneticiBilgileri ai = new yöneticiBilgileri();
            ai.TopLevel = false;
            pnlScreen.Controls.Add(ai);
            ai.Show();
            ai.Dock = DockStyle.Fill;
            ai.BringToFront();
        }
    }
}
