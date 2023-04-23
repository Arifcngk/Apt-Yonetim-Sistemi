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
    public partial class LOGİN : Form
    {
        public LOGİN()
        {
            InitializeComponent();
        }
        SqlConnection connect=new SqlConnection(@"Data Source=DESKTOP-PCF41GC;Initial Catalog=ApartmanLogin;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtYoneticiSifre.PasswordChar = '\0';
            }
            else
            {
                txtYoneticiSifre.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                string sql = "SELECT * From login where AD=@adi AND SİFRE=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi",txtYoneticiAdı.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", txtYoneticiSifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql,connect);
                komut.Parameters.Add(prm1);
                komut.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da=new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    YoneticiPaneli yp = new YoneticiPaneli();
                    yp.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kullanıcı Adı yada Şifre Hatalı");

                txtYoneticiAdı.Clear();
                txtYoneticiSifre.Clear();
               
            }
        }
    }
}
