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

namespace Urun_Takip
{
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PJ65QE6\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand listele = new SqlCommand("select* from TblKategoriler", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(listele);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("insert into TblKategoriler (Ad) Values (@p1)", baglanti);
            kaydet.Parameters.AddWithValue("@p1",txtbKategori.Text);
            kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni kategori eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from TblKategoriler where Id=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1",txtId.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("update TblKategoriler set Ad=@p1 where Id=@p2", baglanti);
            guncelle.Parameters.AddWithValue("@p1", txtbKategori.Text);
            guncelle.Parameters.AddWithValue("@p2", txtId.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori güncellendi");
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select* from TblKategoriler where Ad=@p1", baglanti);
            ara.Parameters.AddWithValue("@p1", txtbKategori.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
// Data Source=DESKTOP-PJ65QE6\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True;Trust Server Certificate=True