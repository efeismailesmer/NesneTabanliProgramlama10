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
    public partial class FrmSekreterGiriş : Form
    {
        public FrmSekreterGiriş()
        {
            InitializeComponent();
        }
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();
        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("Select * From Tbl_Sekreter where Sekretertc=@p1 and Sekretersifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            MySqlDataReader dr= komut.ExecuteReader();
            if(dr.Read())
            {
                FrmSekreterDetay fr=new FrmSekreterDetay();
                fr.TcNo=MskTc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(" Hatalı Tc Veya Şifre");
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
    }
}
