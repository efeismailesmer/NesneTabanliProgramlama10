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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();

        private void FrmBrans_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(" Select * From Tbl_Brans ",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand(" insert into Tbl_brans (Bransad) values (@b1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", TxtBransAd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show(" Branş Eklendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtBransİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();


        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("delete From Tbl_Brans where  Bransid=@b1", bgl.baglanti());
            komut.Parameters.AddWithValue("@b1", TxtBransİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show(" Branş Silindi");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut=new MySqlCommand("update Tbl_Brans set Bransad=@p1 where Bransid=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtBransAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtBransİd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Branş Güncellendi .");
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
