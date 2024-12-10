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
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string Tcno;
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();
        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {
            MskTc.Text = Tcno;
            MySqlCommand komut = new MySqlCommand(" Select * From Tbl_Hastalar where Hastatc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",MskTc.Text);
            MySqlDataReader dr= komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();
                CmbCinsiyet.Text = dr[6].ToString();


            }
            bgl.baglanti().Close();

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            MySqlCommand komut2 = new MySqlCommand("update Tbl_Hastalar set Hastaad=@p1,Hastasoyad=@p2,Hastatelefon=@p3,Hastacinsiyet=@p5 where Hastatc=@p6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",TxtAd.Text);
            komut2.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", MskTelefon.Text);
            komut2.Parameters.AddWithValue("@p4", TxtSifre.Text);
            komut2.Parameters.AddWithValue("@p5", CmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", MskTc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Warning);



        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            
            
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnGeriDön_Click_1(object sender, EventArgs e)
        {
           
        }

        private void BtnCikisYap_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGeriDön_Click_2(object sender, EventArgs e)
        {
            FrmHastaDetau gec=new FrmHastaDetau();
            gec.Show();
            this.Hide();
        }
    }
}
