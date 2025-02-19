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
    public partial class frmIstatistik : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PJ65QE6\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        public frmIstatistik()
        {
            InitializeComponent();
        }

        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand toplamkategori = new SqlCommand("select count(*) from TblKategoriler",baglanti);
            SqlDataReader dr = toplamkategori.ExecuteReader();
            while (dr.Read()){
                lblToplamKategori.Text = dr[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand toplamurun = new SqlCommand("select count(*) from TblUrunler", baglanti);
            SqlDataReader dr2 = toplamurun.ExecuteReader();
            while (dr2.Read())
            {
                lblToplamUrun.Text = dr2[0].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            //Select * From TblUrunler where Stok=(Select Max(Stok) From TblUrunler)
            SqlCommand maxstok = new SqlCommand("Select Urunad,Stok From TblUrunler Where Stok=(Select Max(Stok) From TblUrunler)", baglanti);
            SqlDataReader dr3 = maxstok.ExecuteReader();
            while (dr3.Read())
            {
                lblmaxstokluurun.Text = "Ürün:" + dr3[0].ToString() + "\n" + "Stok:" + dr3[1].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand minstok = new SqlCommand("Select Urunad,Stok From TblUrunler Where Stok=(Select Min(Stok) From TblUrunler)", baglanti);
            SqlDataReader dr4 = minstok.ExecuteReader();
            while (dr4.Read())
            {
                lblminstokluurun.Text = "Ürün:" + dr4[0].ToString() + "\n" + "Stok:" + dr4[1].ToString();
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand totalstok = new SqlCommand("SELECT SUM(stok) FROM tblurunler", baglanti);
            SqlDataReader dr5 = totalstok.ExecuteReader();
            while (dr5.Read())
            {
                lbltoplamstoksayisi.Text = dr5[0].ToString(); ;
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand enpahaliurun = new SqlCommand("SELECT Urunad,Satisfiyat FROM tblurunler where Satisfiyat=(Select Max(Satisfiyat) from tblurunler)", baglanti);
            SqlDataReader dr6 = enpahaliurun.ExecuteReader();
            while (dr6.Read())
            {
                lblenpahaliurun.Text = "Ürün:" + dr6[0].ToString() + "\n" + "Satış fiyatı:" + dr6[1].ToString(); ;
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand enucuzurun = new SqlCommand("SELECT Urunad,Satisfiyat FROM tblurunler where Satisfiyat=(Select Min(Satisfiyat) from tblurunler)", baglanti);
            SqlDataReader dr7 = enucuzurun.ExecuteReader();
            while (dr7.Read())
            {
                lblenucuzurun.Text = "Ürün:" + dr7[0].ToString() + "\n" + "Satış fiyatı:" + dr7[1].ToString(); ;
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand ortalamasatisfiyat = new SqlCommand("SELECT Avg(Satisfiyat) FROM tblurunler", baglanti);
            SqlDataReader dr8 = ortalamasatisfiyat.ExecuteReader();
            while (dr8.Read())
            {
                lblortalamasatisfiyat.Text = dr8[0].ToString(); ;
            }
            baglanti.Close();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anaekran.ActiveForm?.Show();
            this.Close();
        }
    }
}
