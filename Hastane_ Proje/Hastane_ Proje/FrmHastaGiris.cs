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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }
       Mysqlbaglantisi bgl=new Mysqlbaglantisi();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LnkÜyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUyeKayıt gec=new FrmUyeKayıt();
            gec.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            MySqlCommand komut=new MySqlCommand("Select * From Tbl_Hastalar Where Hastatc=@p1 and Hastasifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            MySqlDataReader dr=komut.ExecuteReader();
            if(dr.Read())
            {
                FrmHastaDetau gec=new FrmHastaDetau();
                gec.tc=MskTc.Text;
                gec.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Tc Veya Şifre");

            }
            bgl.baglanti().Close();
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
             
           
        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState==CheckState.Unchecked) 
            { 
                TxtSifre.UseSystemPasswordChar = false;
            }
            else if(checkBox1.CheckState==CheckState.Checked)
            {
                TxtSifre.UseSystemPasswordChar=true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCikisYap_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGeriDön_Click_1(object sender, EventArgs e)
        {
            Form1 gec = new Form1();
            gec.Show();
            this.Hide();
        }
    }
}
