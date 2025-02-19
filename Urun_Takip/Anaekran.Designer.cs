namespace Urun_Takip
{
    partial class Anaekran
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnUrun = new System.Windows.Forms.Button();
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnIstatistik = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblKullaniciadi = new System.Windows.Forms.Label();
            this.tbKullaniciadi = new System.Windows.Forms.TextBox();
            this.tbSifre = new System.Windows.Forms.TextBox();
            this.lblSifre = new System.Windows.Forms.Label();
            this.btnGiris = new System.Windows.Forms.Button();
            this.btnKategoriGrafik = new System.Windows.Forms.Button();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnSatislar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBaslik
            // 
            this.lblBaslik.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaslik.Location = new System.Drawing.Point(104, 9);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(300, 32);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "ÜRÜN TAKİP SİSTEMİ";
            // 
            // btnUrun
            // 
            this.btnUrun.AutoSize = true;
            this.btnUrun.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUrun.Location = new System.Drawing.Point(180, 253);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Size = new System.Drawing.Size(165, 43);
            this.btnUrun.TabIndex = 1;
            this.btnUrun.TabStop = false;
            this.btnUrun.Text = "Ürün İşlemleri";
            this.btnUrun.UseVisualStyleBackColor = false;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // btnKategori
            // 
            this.btnKategori.AutoSize = true;
            this.btnKategori.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnKategori.Location = new System.Drawing.Point(9, 302);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(165, 43);
            this.btnKategori.TabIndex = 2;
            this.btnKategori.TabStop = false;
            this.btnKategori.Text = "Kategori İşlemleri";
            this.btnKategori.UseVisualStyleBackColor = false;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnIstatistik
            // 
            this.btnIstatistik.AutoSize = true;
            this.btnIstatistik.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnIstatistik.Location = new System.Drawing.Point(351, 302);
            this.btnIstatistik.Name = "btnIstatistik";
            this.btnIstatistik.Size = new System.Drawing.Size(165, 43);
            this.btnIstatistik.TabIndex = 4;
            this.btnIstatistik.TabStop = false;
            this.btnIstatistik.Text = "İstatistik";
            this.btnIstatistik.UseVisualStyleBackColor = false;
            this.btnIstatistik.Click += new System.EventHandler(this.btnIstatistik_Click);
            // 
            // lblKullaniciadi
            // 
            this.lblKullaniciadi.AutoSize = true;
            this.lblKullaniciadi.Location = new System.Drawing.Point(89, 79);
            this.lblKullaniciadi.Name = "lblKullaniciadi";
            this.lblKullaniciadi.Size = new System.Drawing.Size(111, 22);
            this.lblKullaniciadi.TabIndex = 5;
            this.lblKullaniciadi.Text = "Kullanıcı adı:";
            // 
            // tbKullaniciadi
            // 
            this.tbKullaniciadi.Location = new System.Drawing.Point(195, 73);
            this.tbKullaniciadi.Name = "tbKullaniciadi";
            this.tbKullaniciadi.Size = new System.Drawing.Size(186, 28);
            this.tbKullaniciadi.TabIndex = 6;
            // 
            // tbSifre
            // 
            this.tbSifre.Location = new System.Drawing.Point(195, 107);
            this.tbSifre.Name = "tbSifre";
            this.tbSifre.PasswordChar = '*';
            this.tbSifre.Size = new System.Drawing.Size(186, 28);
            this.tbSifre.TabIndex = 8;
            // 
            // lblSifre
            // 
            this.lblSifre.AutoSize = true;
            this.lblSifre.Location = new System.Drawing.Point(148, 113);
            this.lblSifre.Name = "lblSifre";
            this.lblSifre.Size = new System.Drawing.Size(52, 22);
            this.lblSifre.TabIndex = 7;
            this.lblSifre.Text = "Şifre:";
            // 
            // btnGiris
            // 
            this.btnGiris.Location = new System.Drawing.Point(267, 160);
            this.btnGiris.Name = "btnGiris";
            this.btnGiris.Size = new System.Drawing.Size(114, 41);
            this.btnGiris.TabIndex = 9;
            this.btnGiris.Text = "Giriş yap";
            this.btnGiris.UseVisualStyleBackColor = true;
            this.btnGiris.Click += new System.EventHandler(this.btnGiris_Click);
            // 
            // btnKategoriGrafik
            // 
            this.btnKategoriGrafik.AutoSize = true;
            this.btnKategoriGrafik.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnKategoriGrafik.Location = new System.Drawing.Point(180, 302);
            this.btnKategoriGrafik.Name = "btnKategoriGrafik";
            this.btnKategoriGrafik.Size = new System.Drawing.Size(165, 43);
            this.btnKategoriGrafik.TabIndex = 10;
            this.btnKategoriGrafik.TabStop = false;
            this.btnKategoriGrafik.Text = "Kategoriler Grafiği";
            this.btnKategoriGrafik.UseVisualStyleBackColor = false;
            this.btnKategoriGrafik.Click += new System.EventHandler(this.btnKategoriGrafik_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.AutoSize = true;
            this.btnMusteri.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMusteri.Location = new System.Drawing.Point(9, 253);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(165, 43);
            this.btnMusteri.TabIndex = 11;
            this.btnMusteri.TabStop = false;
            this.btnMusteri.Text = "Müşteri İşlemleri";
            this.btnMusteri.UseVisualStyleBackColor = false;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusterı_Click);
            // 
            // btnSatislar
            // 
            this.btnSatislar.AutoSize = true;
            this.btnSatislar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSatislar.Location = new System.Drawing.Point(351, 253);
            this.btnSatislar.Name = "btnSatislar";
            this.btnSatislar.Size = new System.Drawing.Size(165, 43);
            this.btnSatislar.TabIndex = 12;
            this.btnSatislar.TabStop = false;
            this.btnSatislar.Text = "Satışlar";
            this.btnSatislar.UseVisualStyleBackColor = false;
            this.btnSatislar.Click += new System.EventHandler(this.btnSatislar_Click);
            // 
            // Anaekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(527, 360);
            this.Controls.Add(this.btnSatislar);
            this.Controls.Add(this.btnMusteri);
            this.Controls.Add(this.btnKategoriGrafik);
            this.Controls.Add(this.btnGiris);
            this.Controls.Add(this.tbSifre);
            this.Controls.Add(this.lblSifre);
            this.Controls.Add(this.tbKullaniciadi);
            this.Controls.Add(this.lblKullaniciadi);
            this.Controls.Add(this.btnIstatistik);
            this.Controls.Add(this.btnKategori);
            this.Controls.Add(this.btnUrun);
            this.Controls.Add(this.lblBaslik);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Anaekran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anaekran";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnUrun;
        private System.Windows.Forms.Button btnKategori;
        private System.Windows.Forms.Button btnIstatistik;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblKullaniciadi;
        private System.Windows.Forms.TextBox tbKullaniciadi;
        private System.Windows.Forms.TextBox tbSifre;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Button btnGiris;
        private System.Windows.Forms.Button btnKategoriGrafik;
        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnSatislar;
    }
}