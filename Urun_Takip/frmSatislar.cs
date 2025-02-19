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

namespace Urun_Takip
{
    public partial class frmSatislar : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PJ65QE6\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        DataSet1TableAdapters.TblSatislarTableAdapter ds =
                 new DataSet1TableAdapters.TblSatislarTableAdapter();

        public frmSatislar()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand list = new SqlCommand("Execute SatisListesi",baglanti);
            SqlDataAdapter adapter = new SqlDataAdapter(list);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmSatislar_Load(object sender, EventArgs e)
        {
            SqlCommand cbUrunler = new SqlCommand("select* from TblUrunler", baglanti);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cbUrunler);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);
            cbUrun.DataSource = dt2;
            cbUrun.DisplayMember = "UrunAd";
            cbUrun.ValueMember = "UrunId";

            dataGridView1.DataSource = ds.SatisListesi();

            dataGridView1.Columns["ID"].DisplayIndex = 0;
            dataGridView1.Columns["Ürün"].DisplayIndex = 1;
            dataGridView1.Columns["Müşteri"].DisplayIndex = 2;
            dataGridView1.Columns["Adet"].DisplayIndex = 3;
            dataGridView1.Columns["Fiyat"].DisplayIndex = 4;
            dataGridView1.Columns["Toplam"].DisplayIndex = 5;
            dataGridView1.Columns["Tarih"].DisplayIndex = 6;

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            byte adet = byte.Parse(txtAdet.Text.ToString());
            decimal fiyat = decimal.Parse(txtFiyat.Text.ToString());
            decimal toplamfiyat = adet * fiyat;
            try{
                ds.SatisEkle(int.Parse(cbUrun.SelectedValue.ToString()), int.Parse(txtMusteri.Text),
                adet, fiyat, toplamfiyat, DateTime.Parse(maskedTextBox1.Text));
                MessageBox.Show("Satış eklendi");}

            catch (Exception ex){
                MessageBox.Show(ex.Message);}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSatisID.Text = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            txtMusteri.Text = dataGridView1.Rows[e.RowIndex].Cells["Müşteri"].Value.ToString();
            txtAdet.Text = dataGridView1.Rows[e.RowIndex].Cells["Adet"].Value.ToString();
            txtFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["Fiyat"].Value.ToString();
            txtToplamFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells["Toplam"].Value.ToString();

            string urun = dataGridView1.Rows[e.RowIndex].Cells["Ürün"].Value.ToString();
            cbUrun.SelectedIndex = cbUrun.FindStringExact(urun);

            string tarih = dataGridView1.Rows[e.RowIndex].Cells["Tarih"].Value.ToString();
            DateTime dtTarih;
            DateTime.TryParse(tarih, out dtTarih);
            maskedTextBox1.Text = dtTarih.ToString("dd.MM.yyyy");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int idDegeri = int.Parse(txtSatisID.Text.ToString());
            ds.SatisSil(idDegeri);
            MessageBox.Show("Satış silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            //bool ischanged = false;
            int satis_id = int.Parse(txtSatisID.Text.ToString());
            
            SqlCommand musteriIdBul = new SqlCommand("SELECT MusteriID AS musteri_id FROM tblmusteriler WHERE ad + ' ' + soyad = @fullName;", baglanti);
            musteriIdBul.Parameters.AddWithValue("@fullName", txtMusteri.Text);
            int musteri_id = Convert.ToInt32(musteriIdBul.ExecuteScalar());

            decimal toplam = byte.Parse(txtAdet.Text) * decimal.Parse(txtFiyat.Text);

            SqlCommand guncelle = new SqlCommand("update TblSatislar set Urun=@p1,Musteri=@p2,Adet=@p3,Fiyat=@p4,Toplam=@p5,Tarih=@p6 where ID=@p7", baglanti);
            guncelle.Parameters.AddWithValue("@p7",satis_id);
            guncelle.Parameters.AddWithValue("@p1",cbUrun.SelectedIndex);
            guncelle.Parameters.AddWithValue("@p2",musteri_id);
            guncelle.Parameters.AddWithValue("@p3",byte.Parse(txtAdet.Text.ToString()));
            guncelle.Parameters.AddWithValue("@p4",decimal.Parse(txtFiyat.Text.ToString()));
            guncelle.Parameters.AddWithValue("@p5",toplam);
            guncelle.Parameters.AddWithValue("@p6", DateTime.Parse(maskedTextBox1.Text));
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün güncellendi");

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anaekran.ActiveForm?.Show();
            this.Close();
        }
    }
}
