﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Urun_Takip
{
    public partial class Anaekran : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PJ65QE6\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        bool admin_girisi;
        public Anaekran(){
            InitializeComponent();
            if (admin_girisi == false) {
                btnKategori.Hide();
                btnIstatistik.Hide();
                btnUrun.Hide();
                btnKategoriGrafik.Hide();
                btnMusteri.Hide();
                btnSatislar.Hide();
            }
        }

        private void btnUrun_Click(object sender, EventArgs e){
            frmUrun frmurun = new frmUrun();
            frmurun.ShowDialog();
        }

        private void btnMusterı_Click(object sender, EventArgs e)
        {
            frmMusteri frmmusteri = new frmMusteri();
            frmmusteri.ShowDialog();
        }

        private void btnKategori_Click(object sender, EventArgs e){
            frmKategori frmkategori = new frmKategori();
            frmkategori.ShowDialog();
        }

        private void btnIstatistik_Click(object sender, EventArgs e){
            frmIstatistik frmistatistik = new frmIstatistik();
            frmistatistik.ShowDialog();
        }
        private void btnGiris_Click(object sender, EventArgs e){
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select * from TblAdminler where kullanici=@p1 and sifre=@p2",baglanti);
            cmd.Parameters.AddWithValue("@p1",tbKullaniciadi.Text);
            cmd.Parameters.AddWithValue("@p2", tbSifre.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                btnUrun.Show();
                btnKategori.Show();
                btnIstatistik.Show();
                btnKategoriGrafik.Show();
                btnMusteri.Show();
                btnSatislar.Show();
                admin_girisi = true;
            }
            else {
                btnKategori.Hide();
                btnIstatistik.Hide();
                btnUrun.Hide();
                btnKategoriGrafik.Hide();
                btnMusteri.Hide();
                btnSatislar.Hide();
                MessageBox.Show("Hatalı giriş yaptınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            baglanti.Close();
        }

        private void btnKategoriGrafik_Click(object sender, EventArgs e)
        {
            frmGrafik frmgrafık = new frmGrafik();
            frmgrafık.ShowDialog();
        }

        private void btnSatislar_Click(object sender, EventArgs e)
        {
            frmSatislar frmsatislar = new frmSatislar();
            frmsatislar.ShowDialog();
        }
    }
}
