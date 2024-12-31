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

namespace Urun_Takip{
    public partial class frmUrun : Form{
        public frmUrun(){
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PJ65QE6\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        private void btnListele_Click(object sender, EventArgs e){
            //SqlCommand listele = new SqlCommand("Select * from TblUrunler", baglanti);
            SqlCommand listele = new SqlCommand("Select urunId,urunad,stok,alisfiyat,satisfiyat,kategori,kategoriid from TblUrunler " +
                    "Inner Join TblKategoriler ON TblUrunler.KategoriId = TblKategoriler.Id ", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(listele);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["KategoriId"].Visible = false;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmUrun_Load(object sender, EventArgs e){
            SqlCommand listele = new SqlCommand("select* from TblKategoriler", baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(listele);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cbKategori.DataSource = dt;
            cbKategori.DisplayMember = "Kategori";
            cbKategori.ValueMember = "Id";
        }

        private void btnKaydet_Click(object sender, EventArgs e){
            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("insert into TblUrunler (UrunAd , Stok , Alisfiyat, Satisfiyat , KategoriId) Values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            kaydet.Parameters.AddWithValue("@p1", txtUrunad.Text); // UrunAd: string (yazılı veri)
            kaydet.Parameters.AddWithValue("@p2", (int)nudStok.Value); // Stok: int (sayısal değer)
            kaydet.Parameters.AddWithValue("@p3", decimal.Parse(txtAlisfiyat.Text)); // Alisfiyat: decimal
            kaydet.Parameters.AddWithValue("@p4", decimal.Parse(txtSatisfiyat.Text)); // Satisfiyat: decimal
            kaydet.Parameters.AddWithValue("@p5", (int)cbKategori.SelectedValue); // KategoriId: i
            kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni ürün eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e){
            baglanti.Open();
            SqlCommand sil = new SqlCommand("delete from TblUrunler where UrunId=@p1", baglanti);
            sil.Parameters.AddWithValue("@p1", txtId.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün silindi");
        }

        string eskiUrunAd = string.Empty;
        string eskiAlisFiyat = string.Empty;
        string eskiSatisFiyat = string.Empty;
        int eskiStok = 0;
        int eskiKategoriId = 0;
        bool ischanged = false;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e){
            try
            {
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtUrunad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                nudStok.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtAlisfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSatisfiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                // kategori adını combobox'tan seçme
                string kategoriAdi = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbKategori.SelectedIndex = cbKategori.FindStringExact(kategoriAdi);

                eskiUrunAd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                eskiAlisFiyat = txtAlisfiyat.Text;
                eskiSatisFiyat = txtSatisfiyat.Text;
                eskiStok = int.Parse(nudStok.Value.ToString());
                eskiKategoriId = cbKategori.SelectedIndex;
               // MessageBox.Show(eskiUrunAd +","+eskiStok+","+eskiAlisFiyat+","+eskiSatisFiyat+","+kategoriAdi);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e){
            if (eskiUrunAd!=txtUrunad.Text) ischanged = true;
            if (eskiStok != nudStok.Value) ischanged = true;
            if (eskiAlisFiyat != txtAlisfiyat.Text) ischanged = true;
            if (eskiSatisFiyat != txtSatisfiyat.Text) ischanged = true;
            if (eskiKategoriId != cbKategori.SelectedIndex) ischanged = true;
            if (ischanged){
         //MessageBox.Show(eskiUrunAd + " __ " + eskiSatisFiyat + " __ " + eskiAlisFiyat + " __ " + eskiStok + " __ " + eskiKategoriId + " --- " +
         //txtUrunad.Text + " " + txtSatisfiyat.Text + " " + txtAlisfiyat.Text + " " + nudStok.Value.ToString() + " " + cbKategori.SelectedIndex);

                baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update TblUrunler set Urunad=@p1,Stok=@p2,Alisfiyat=@p3,Satisfiyat=@p4,KategoriId=@p5 where Urunid=@p6", baglanti);
                guncelle.Parameters.AddWithValue("@p1", txtUrunad.Text);
                guncelle.Parameters.AddWithValue("@p2", nudStok.Value);
                guncelle.Parameters.AddWithValue("@p3", Convert.ToDecimal(txtAlisfiyat.Text));
                guncelle.Parameters.AddWithValue("@p4", Convert.ToDecimal(txtSatisfiyat.Text));
                guncelle.Parameters.AddWithValue("@p5", cbKategori.SelectedValue);
                guncelle.Parameters.AddWithValue("@p6", txtId.Text);
                guncelle.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün güncellendi");
                ischanged = false;
            }
            else { MessageBox.Show("Değişiklik yapılmadığı için ürün güncellenmedi"); }
        }
    }
}