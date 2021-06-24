namespace CafeProject
{
    partial class frmAdminPaneli
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
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnUrun = new System.Windows.Forms.Button();
            this.btnUrunDetay = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnProfil = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKategori
            // 
            this.btnKategori.Location = new System.Drawing.Point(6, 19);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(183, 23);
            this.btnKategori.TabIndex = 0;
            this.btnKategori.Text = "Kategori Ekle/Düzenle";
            this.btnKategori.UseVisualStyleBackColor = true;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnUrun
            // 
            this.btnUrun.Location = new System.Drawing.Point(5, 49);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Size = new System.Drawing.Size(183, 23);
            this.btnUrun.TabIndex = 1;
            this.btnUrun.Text = "Ürün Ekle/Düzenle";
            this.btnUrun.UseVisualStyleBackColor = true;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // btnUrunDetay
            // 
            this.btnUrunDetay.Location = new System.Drawing.Point(6, 79);
            this.btnUrunDetay.Name = "btnUrunDetay";
            this.btnUrunDetay.Size = new System.Drawing.Size(182, 23);
            this.btnUrunDetay.TabIndex = 2;
            this.btnUrunDetay.Text = "Ürün Detayı Ekle";
            this.btnUrunDetay.UseVisualStyleBackColor = true;
            this.btnUrunDetay.Click += new System.EventHandler(this.btnUrunDetay_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(312, 292);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 53);
            this.button4.TabIndex = 3;
            this.button4.Text = "Ayarlar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnProfil
            // 
            this.btnProfil.Location = new System.Drawing.Point(6, 19);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(182, 23);
            this.btnProfil.TabIndex = 4;
            this.btnProfil.Text = "Profil Ekle";
            this.btnProfil.UseVisualStyleBackColor = true;
            this.btnProfil.Click += new System.EventHandler(this.btnProfil_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 49);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(182, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Profil Ata";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 79);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(182, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "Kullanıcı/Şifre Atama";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUrunDetay);
            this.groupBox1.Controls.Add(this.btnKategori);
            this.groupBox1.Controls.Add(this.btnUrun);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 123);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ürün/Kategori";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnProfil);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Location = new System.Drawing.Point(12, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 111);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profil /Kullanıcı";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(252, 292);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(54, 53);
            this.button8.TabIndex = 9;
            this.button8.Text = "Çıkış";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // frmAdminPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 357);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Name = "frmAdminPaneli";
            this.Text = "frmAdminPaneli";
            this.Load += new System.EventHandler(this.frmAdminPaneli_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKategori;
        private System.Windows.Forms.Button btnUrun;
        private System.Windows.Forms.Button btnUrunDetay;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnProfil;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button8;
    }
}