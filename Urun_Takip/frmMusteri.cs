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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Urun_Takip{
    public partial class frmMusteri : Form{
        public frmMusteri(){InitializeComponent();}
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PJ65QE6\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        private void btnAra_Click(object sender, EventArgs e) {
            string musteriID = txtMusteriID.Text;
            string ad = txtMusteriAd.Text;
            string soyad = txtMusteriSoyad.Text;
            string sehir = txtSehir.Text;
            string bakiye = txtBakiye.Text;
            string query = "SELECT * FROM TblMusteriler WHERE 1=1";

            if (!string.IsNullOrEmpty(musteriID)) query += " AND MusteriID = @MusteriID";
            if (!string.IsNullOrEmpty(ad)) query += " AND Ad LIKE @Ad";
            if (!string.IsNullOrEmpty(soyad)) query += " AND Soyad LIKE @Soyad";
            if (!string.IsNullOrEmpty(sehir)) query += " AND Sehir LIKE @Sehir";
            if (!string.IsNullOrEmpty(bakiye)) query += " AND Bakiye = @Bakiye";

            try{
                baglanti.Open();
                SqlCommand ara = new SqlCommand(query, baglanti);

                if (!string.IsNullOrEmpty(musteriID)) ara.Parameters.AddWithValue("@MusteriID", musteriID);
                if (!string.IsNullOrEmpty(ad)) ara.Parameters.AddWithValue("@Ad", "%" + ad + "%");
                if (!string.IsNullOrEmpty(soyad)) ara.Parameters.AddWithValue("@Soyad", "%" + soyad + "%");
                if (!string.IsNullOrEmpty(sehir)) ara.Parameters.AddWithValue("@Sehir", "%" + sehir + "%");
                if (!string.IsNullOrEmpty(bakiye)) ara.Parameters.AddWithValue("@Bakiye", bakiye);

                SqlDataAdapter adapter = new SqlDataAdapter(ara);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex) {MessageBox.Show("Hata: " + ex.Message);}

            baglanti.Close();
        }
        DataSet1TableAdapters.TblMusterilerTableAdapter tb = new DataSet1TableAdapters.TblMusterilerTableAdapter();
        private void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = tb.MusteriListesi();
               //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                tb.MusteriEkle(txtMusteriAd.Text, txtMusteriSoyad.Text, txtSehir.Text, decimal.Parse(txtBakiye.Text));
                MessageBox.Show("Müşteri eklendi");
            }

            catch (Exception ex)
            {
                MessageBox.Show ("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                tb.MusteriSil(int.Parse(txtMusteriID.Text));
                MessageBox.Show("Müşteri silindi");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMusteriID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMusteriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMusteriSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                tb.MusteriGuncelle(txtMusteriAd.Text, txtMusteriSoyad.Text, txtSehir.Text,
                                   decimal.Parse(txtBakiye.Text), int.Parse(txtMusteriID.Text));
                MessageBox.Show("Müşteri güncellendi");
                btnListele_Click(sender, e);
            }

            catch (Exception ex)
            {
                    MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anaekran.ActiveForm?.Show();
            this.Close();
        }
    }
}