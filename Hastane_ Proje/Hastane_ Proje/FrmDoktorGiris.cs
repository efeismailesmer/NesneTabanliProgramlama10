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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {
         
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand(" Select * From Tbl_Doktor where Doktortc=@p1 and Doktorsifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            MySqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmDoktorDetay gec = new FrmDoktorDetay();
                gec.tc=MskTc.Text;
                gec.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya Şifre");
            }
            bgl.baglanti().Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Unchecked)
            {
                TxtSifre.UseSystemPasswordChar = false;
            }
            else if (checkBox1.CheckState == CheckState.Checked)
            {
                TxtSifre.UseSystemPasswordChar = true;
            }
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            Form1 gec= new Form1();
            gec.Show();
            this.Hide();
        }
    }
}
