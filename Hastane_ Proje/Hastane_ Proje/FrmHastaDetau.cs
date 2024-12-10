using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane__Proje
{
    public partial class FrmHastaDetau : Form
    {
        public FrmHastaDetau()
        {
            InitializeComponent();
        }
        public string tc;
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();

        private void FrmHastaDetau_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;
            // Ad Soyad Getirme
            MySqlCommand komut = new MySqlCommand("Select Hastaad,Hastasoyad From Tbl_Hastalar Where Hastatc=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", LblTc.Text);
            MySqlDataReader dr= komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0] +" "+ dr[1];
            }
            bgl.baglanti().Close();

            // Randevu Geçmişi
            DataTable dt= new DataTable();
            MySqlDataAdapter da=new MySqlDataAdapter("Select * From  Tbl_Randevular where Hastatc="+tc,bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            // Branşları Getirme
            MySqlCommand komut2=new MySqlCommand("Select Bransad From Tbl_Brans",bgl.baglanti());
            MySqlDataReader dr2=komut2.ExecuteReader();
            while (dr2.Read())
            {
                CmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void CmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("Select * From Tbl_Randevular Where RandevuBrans='" + CmbBrans.Text + "'"+"and RandevuDoktor='"+CmbDoktor.Text+"' and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbDoktor.Items.Clear();

            MySqlCommand komut3 = new MySqlCommand("Select Doktorad,Doktorsoyad From Tbl_Doktor Where Doktorbrans=@p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", CmbBrans.Text);
            MySqlDataReader dr3=komut3.ExecuteReader();
            while (dr3.Read())
            {
                CmbDoktor.Items.Add(dr3[0]+" " + dr3[1]);
            }
            bgl.baglanti().Close();
        }

        private void LnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmBilgiDüzenle fr=new FrmBilgiDüzenle();
            fr.Tcno = LblTc.Text;
            fr.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            Txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            
        }

        private void BtnRandevuAl_Click(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand(" update Tbl_Randevular set RandevuDurum=1,HastaTc=@p1,HastaSikayet=@p2 where Randevuid=@p3", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblTc.Text);
            komut.Parameters.AddWithValue("@p2", RchSikayet.Text);
            komut.Parameters.AddWithValue("@p3", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Alındı","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FrmHastaGiris gec= new FrmHastaGiris();
            gec.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCikisYap_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnGeriDön_Click_1(object sender, EventArgs e)
        {
            FrmHastaGiris gec = new FrmHastaGiris();
            gec.Show();
            this.Hide();
        }
    }
}
