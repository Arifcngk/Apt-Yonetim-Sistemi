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
    public partial class ApartmanBilgileri : Form
    {
        public ApartmanBilgileri()
        {
            InitializeComponent();
        }
        SqlConnection baglantı;
        SqlCommand komut;
        SqlDataAdapter da;
        void DaireBilgisi()
        {

            baglantı = new SqlConnection("Data Source=DESKTOP-PCF41GC;Initial Catalog=apartman_bilgisi;Integrated Security=True");
            baglantı.Open();
            da = new SqlDataAdapter("SELECT *FROM DaireBilgisi", baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
        }

            private void ApartmanBilgileri_Load(object sender, EventArgs e)
        {
                DaireBilgisi();
            //  dataGridViewDesingCode(dataGridView1);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komutsil=new SqlCommand("Delete From DaireBilgisi where Daire_NO=@p1", baglantı);
            komutsil.Parameters.AddWithValue("@p1",txtNO.Text);
            komutsil.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Daire Bilgisi Veri Tabanından Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            DaireBilgisi();
        }

        private void btnUPDATE_Click(object sender, EventArgs e)
        {
            string update = "UPDATE Dairebilgisi SET Daire_Sahibi=@ds,Daire_Tel=@dt,Daire_Mail=@dm,Daire_AracPlaka=@dp WHERE Daire_NO=@dn";
            komut = new SqlCommand(update, baglantı);
            komut.Parameters.AddWithValue("@dn", Convert.ToInt32(txtNO.Text));
            komut.Parameters.AddWithValue("@ds",txtSahibi.Text);
            komut.Parameters.AddWithValue("@dt",txtTel.Text);
            komut.Parameters.AddWithValue("@dm",txtMail.Text);
            komut.Parameters.AddWithValue("@dp",txtPlaka.Text);
            baglantı.Open();
            komut.ExecuteNonQuery();
            baglantı.Close();
            DaireBilgisi();
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            txtNO.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSahibi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTel.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPlaka.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void btnEKLE_Click(object sender, EventArgs e)
        {

        }
    }
}
