using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Hastane__Proje
{
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();

        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            MySqlDataAdapter da1 = new MySqlDataAdapter("Select * From Tbl_Doktor", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;

            // Branş Aktarma
            MySqlCommand komut2 = new MySqlCommand("Select Bransad From Tbl_Brans", bgl.baglanti());
            MySqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("insert into Tbl_Doktor (Doktorad,Doktorsoyad,Doktorbrans,Doktortc,Doktorsifre) values(@d1,@d2,@d3,@d4,@d5)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", Txtad.Text);
            komut.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@d3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@d4", MskTc.Text);
            komut.Parameters.AddWithValue("@d5", TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show(" Doktor Eklendi ","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("Delete from Tbl_Doktor where Doktortc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show(" Kayıt Silindi","Uyarı ",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut=new MySqlCommand("Update Tbl_Doktor set Doktorad=@d1,Doktorsoyad=@d2,Doktorbrans=@d3,Doktorsifre=@d5 where Doktortc=@d4",bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", Txtad.Text);
            komut.Parameters.AddWithValue("@d2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@d3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@d4", MskTc.Text);
            komut.Parameters.AddWithValue("@d5", TxtSifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show(" Doktor Güncellendi. ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            FrmSekreterDetay gec=new FrmSekreterDetay();
            gec.Show();
            this.Hide();
        }
    }
}
