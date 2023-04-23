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
    public partial class AidatBilgileri : Form
    {
        public AidatBilgileri()
        {
            InitializeComponent();
        }

        SqlConnection baglantı;
        SqlCommand komut;
        SqlDataAdapter da;

        void AidatBilgisi()
        {

            baglantı = new SqlConnection("Data Source=DESKTOP-PCF41GC;Initial Catalog=AidatBilgisi;Integrated Security=True");
            baglantı.Open();
            da = new SqlDataAdapter("SELECT *FROM aidatBilgileri", baglantı);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglantı.Close();
        }

        private void AidatBilgileri_Load(object sender, EventArgs e)
        {
            AidatBilgisi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblNO.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox11.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string update = "UPDATE aidatBilgileri SET OCAK=@O,ŞUBAT=@Ş,MART=@M,NİSAN=@N,MAYIS=@MA,HAZİRAN=@H,TEMMUZ=@T,AĞUSTOS=@A,EYLÜL=@EY,EKİM=@EK,KASIM=@KA,ARALIK=@AR WHERE DarineNO=@dn";
            komut = new SqlCommand(update, baglantı);
            komut.Parameters.AddWithValue("@dn", Convert.ToInt32(lblNO.Text));
            komut.Parameters.AddWithValue("@O", textBox1.Text);
            komut.Parameters.AddWithValue("@Ş", textBox2.Text);
            komut.Parameters.AddWithValue("@M", textBox3.Text);
            komut.Parameters.AddWithValue("@N", textBox4.Text);
            komut.Parameters.AddWithValue("@MA", textBox5.Text);
            komut.Parameters.AddWithValue("@H", textBox6.Text);
            komut.Parameters.AddWithValue("@T", textBox7.Text);
            komut.Parameters.AddWithValue("@A", textBox8.Text);
            komut.Parameters.AddWithValue("@EY", textBox9.Text);
            komut.Parameters.AddWithValue("@EK", textBox10.Text);
            komut.Parameters.AddWithValue("@KA", textBox11.Text);
            komut.Parameters.AddWithValue("@AR", textBox12.Text);



            baglantı.Open();
            komut.ExecuteNonQuery();
            baglantı.Close();
            AidatBilgisi();
        }
    }
}
