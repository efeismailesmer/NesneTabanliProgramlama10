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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        Mysqlbaglantisi bgl=new Mysqlbaglantisi();
        public string tc;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            LblTc.Text = tc;
             
        // Doktor Ad Soyad 
          MySqlCommand komut=new MySqlCommand("Select Doktorad,Doktorsoyad From Tbl_Doktor where Doktortc=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",LblTc.Text);
            MySqlDataReader dr=komut.ExecuteReader();
            while(dr.Read())
            {
                LblAdSoyad.Text = dr[0]+" " + dr[1];

            }
            bgl.baglanti().Close();
            
            // Randevular
            DataTable dt = new DataTable();
            MySqlDataAdapter da=new MySqlDataAdapter("Select * From Tbl_Randevular where RandevuDoktor='"+LblAdSoyad.Text+"'",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void BtnBilgiDüzenle_Click(object sender, EventArgs e)
        {
           FrmDoktorBilgiDüzenle gec=new FrmDoktorBilgiDüzenle();
            gec.tcno=LblTc.Text;
            gec.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular gec=new FrmDuyurular();
            gec.Show();
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            RchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void BtnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void BtnGeriDön_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris gec=new FrmDoktorGiris();
            gec.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
