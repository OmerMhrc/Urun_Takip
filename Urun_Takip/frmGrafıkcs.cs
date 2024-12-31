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
    public partial class frmGrafik : Form{
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PJ65QE6\\SQLEXPRESS;Initial Catalog=DbUrun;Integrated Security=True");
        public frmGrafik(){
            InitializeComponent();
        }

        private void frmGrafik_Load(object sender, EventArgs e){
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select kategori,Count(*) from TblKategoriler INNER JOIN TblUrunler\r\non TblUrunler.kategoriid=TblKategoriler.Id Group by Kategori",baglanti);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                chart.Series["Kategori"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();
        }
    }
}
