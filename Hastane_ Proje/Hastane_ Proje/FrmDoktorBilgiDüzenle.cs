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
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        Mysqlbaglantisi bgl = new Mysqlbaglantisi();
        public string tcno;

        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = tcno;

           MySqlCommand komut=new MySqlCommand(" Select * From Tbl_Doktor where Doktortc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",MskTc.Text);
            MySqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                CmbBrans.Text = dr[3].ToString();
                TxtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();


        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut=new MySqlCommand("update Tbl_Doktor  set Doktorad=@p1,Doktorsoyad=@p2,Doktorbrans=@p3,Doktorsifre=@p4 where  Doktortc=@p5",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p5", MskTc.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi");


        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            FrmDoktorDetay gec= new FrmDoktorDetay();
            gec.Show();
            this.Hide();
        }
    }
}
