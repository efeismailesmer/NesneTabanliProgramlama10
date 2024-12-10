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
using MySql.Data.MySqlClient;

namespace Hastane__Proje
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string TcNo;
     
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
         LblTc.Text = TcNo;
           
            // Ad Soyad Getirme
            MySqlCommand komut1 = new MySqlCommand("Select Sekreteradsoyad From Tbl_Sekreter where Sekretertc=@p1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", LblTc.Text);
            MySqlDataReader dr1= komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblAdSoyad.Text= dr1[0].ToString();
            }
            bgl.baglanti().Close();


            // Branşları Aktarma
            DataTable dt1 = new DataTable();
            MySqlDataAdapter da= new MySqlDataAdapter(" Select  * from Tbl_Brans",bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            // Doktor aktarma

            DataTable dt2 = new DataTable();
            MySqlDataAdapter da2= new MySqlDataAdapter("Select (Doktorad + ' '+ Doktorsoyad)as ' Doktorlar',Doktorbrans From Tbl_Doktor",bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branş Aktarma
            MySqlCommand komut2 = new MySqlCommand("Select Bransad From Tbl_Brans",bgl.baglanti());
            MySqlDataReader dr2= komut2.ExecuteReader();
            while(dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
           
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            MySqlCommand komutkaydet = new MySqlCommand(" insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor)values (@r1,@r2,@r3,@r4)", bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1", MskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@r2", MskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@r3", CmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@r4", CmbDoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();
            MySqlCommand komut= new MySqlCommand("Select Doktorad,Doktorsoyad From Tbl_Doktor where Doktorbrans=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbBrans.Text);
            MySqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                CmbDoktor.Items.Add(dr[0]+ " "+ dr[1]);
            }
            bgl.baglanti().Close();
        }

        private void BtnOluştur_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand(" insert into Tbl_Duyurular (duyuru) values (@d1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@d1", RchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti() .Close();
            MessageBox.Show(" Duyuru Oluşturuldu ");

        }

        private void BtnDoktorPaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli gec= new FrmDoktorPaneli();
            gec.Show();
        }

        private void BtnBrans_Click(object sender, EventArgs e)
        {
            FrmBrans gec= new FrmBrans();
            gec.Show();
        }

        private void BtnRandevuListesi_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi gec= new FrmRandevuListesi();
            gec.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular gec= new FrmDuyurular();
            gec.Show();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            FrmSekreterGiriş gec= new FrmSekreterGiriş();
            gec.Show();
            this.Hide();
        }
    }
}
