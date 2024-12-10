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
    public partial class FrmUyeKayıt : Form
    {
        public FrmUyeKayıt()
        {
            InitializeComponent();
        }
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();

        private void FrmUyeKayıt_Load(object sender, EventArgs e)
        {

        }

        private void BtnKayıtYap_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("insert into Tbl_Hastalar(Hastaad,Hastasoyad,Hastatc,Hastatelefon,Hastasifre,Hastacinsiyet)values(@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", MskTc.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p6", CmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleştirilmiştir Şifreniz:"+TxtSifre.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            FrmHastaGiris gec=new FrmHastaGiris();
            gec.Show();
            this.Hide();
        }
    }
}
