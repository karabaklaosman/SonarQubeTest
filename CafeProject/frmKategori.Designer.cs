namespace CafeProject
{
    partial class frmKategori
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
            this.lbl_kat_sil = new System.Windows.Forms.Label();
            this.txt_ekle = new System.Windows.Forms.TextBox();
            this.grp_duzenle = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_duz = new System.Windows.Forms.TextBox();
            this.btn_Duzenle = new System.Windows.Forms.Button();
            this.cmb_duzenle = new System.Windows.Forms.ComboBox();
            this.btn_sil = new System.Windows.Forms.Button();
            this.listBox_kat = new System.Windows.Forms.ListBox();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.lbl_kat_ekle = new System.Windows.Forms.Label();
            this.cmb_sil = new System.Windows.Forms.ComboBox();
            this.btn_geri = new System.Windows.Forms.Button();
            this.grp_duzenle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_kat_sil
            // 
            this.lbl_kat_sil.AutoSize = true;
            this.lbl_kat_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kat_sil.Location = new System.Drawing.Point(14, 68);
            this.lbl_kat_sil.Name = "lbl_kat_sil";
            this.lbl_kat_sil.Size = new System.Drawing.Size(92, 16);
            this.lbl_kat_sil.TabIndex = 16;
            this.lbl_kat_sil.Text = "Kategori Sil:";
            // 
            // txt_ekle
            // 
            this.txt_ekle.Location = new System.Drawing.Point(122, 34);
            this.txt_ekle.Name = "txt_ekle";
            this.txt_ekle.Size = new System.Drawing.Size(175, 20);
            this.txt_ekle.TabIndex = 10;
            // 
            // grp_duzenle
            // 
            this.grp_duzenle.Controls.Add(this.label2);
            this.grp_duzenle.Controls.Add(this.label1);
            this.grp_duzenle.Controls.Add(this.txt_duz);
            this.grp_duzenle.Controls.Add(this.btn_Duzenle);
            this.grp_duzenle.Controls.Add(this.cmb_duzenle);
            this.grp_duzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grp_duzenle.Location = new System.Drawing.Point(17, 147);
            this.grp_duzenle.Name = "grp_duzenle";
            this.grp_duzenle.Size = new System.Drawing.Size(372, 108);
            this.grp_duzenle.TabIndex = 15;
            this.grp_duzenle.TabStop = false;
            this.grp_duzenle.Text = "Düzenle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(2, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Yeni Kategori:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Kategori Seç:";
            // 
            // txt_duz
            // 
            this.txt_duz.Location = new System.Drawing.Point(110, 54);
            this.txt_duz.Name = "txt_duz";
            this.txt_duz.Size = new System.Drawing.Size(181, 21);
            this.txt_duz.TabIndex = 9;
            // 
            // btn_Duzenle
            // 
            this.btn_Duzenle.Location = new System.Drawing.Point(297, 20);
            this.btn_Duzenle.Name = "btn_Duzenle";
            this.btn_Duzenle.Size = new System.Drawing.Size(69, 61);
            this.btn_Duzenle.TabIndex = 10;
            this.btn_Duzenle.Text = "Düzenle";
            this.btn_Duzenle.UseVisualStyleBackColor = true;
            this.btn_Duzenle.Click += new System.EventHandler(this.btn_Duzenle_Click);
            // 
            // cmb_duzenle
            // 
            this.cmb_duzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_duzenle.FormattingEnabled = true;
            this.cmb_duzenle.Location = new System.Drawing.Point(110, 26);
            this.cmb_duzenle.Name = "cmb_duzenle";
            this.cmb_duzenle.Size = new System.Drawing.Size(181, 23);
            this.cmb_duzenle.TabIndex = 8;
            this.cmb_duzenle.Text = "Seçiniz";
            // 
            // btn_sil
            // 
            this.btn_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_sil.Location = new System.Drawing.Point(314, 64);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(75, 23);
            this.btn_sil.TabIndex = 14;
            this.btn_sil.Text = "Sil";
            this.btn_sil.UseVisualStyleBackColor = true;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // listBox_kat
            // 
            this.listBox_kat.Enabled = false;
            this.listBox_kat.FormattingEnabled = true;
            this.listBox_kat.Location = new System.Drawing.Point(412, 8);
            this.listBox_kat.Name = "listBox_kat";
            this.listBox_kat.Size = new System.Drawing.Size(198, 303);
            this.listBox_kat.TabIndex = 12;
            // 
            // btn_ekle
            // 
            this.btn_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ekle.Location = new System.Drawing.Point(314, 32);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(75, 23);
            this.btn_ekle.TabIndex = 11;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // lbl_kat_ekle
            // 
            this.lbl_kat_ekle.AutoSize = true;
            this.lbl_kat_ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbl_kat_ekle.Location = new System.Drawing.Point(14, 34);
            this.lbl_kat_ekle.Name = "lbl_kat_ekle";
            this.lbl_kat_ekle.Size = new System.Drawing.Size(105, 16);
            this.lbl_kat_ekle.TabIndex = 9;
            this.lbl_kat_ekle.Text = "Kategori Ekle:";
            // 
            // cmb_sil
            // 
            this.cmb_sil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_sil.FormattingEnabled = true;
            this.cmb_sil.Location = new System.Drawing.Point(122, 65);
            this.cmb_sil.Name = "cmb_sil";
            this.cmb_sil.Size = new System.Drawing.Size(175, 23);
            this.cmb_sil.TabIndex = 13;
            this.cmb_sil.Text = "Seçiniz";
            // 
            // btn_geri
            // 
            this.btn_geri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_geri.Location = new System.Drawing.Point(160, 274);
            this.btn_geri.Name = "btn_geri";
            this.btn_geri.Size = new System.Drawing.Size(75, 23);
            this.btn_geri.TabIndex = 17;
            this.btn_geri.Text = "GERİ";
            this.btn_geri.UseVisualStyleBackColor = true;
            this.btn_geri.Click += new System.EventHandler(this.btn_geri_Click);
            // 
            // frmKategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 319);
            this.Controls.Add(this.btn_geri);
            this.Controls.Add(this.lbl_kat_sil);
            this.Controls.Add(this.txt_ekle);
            this.Controls.Add(this.grp_duzenle);
            this.Controls.Add(this.btn_sil);
            this.Controls.Add(this.listBox_kat);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.lbl_kat_ekle);
            this.Controls.Add(this.cmb_sil);
            this.Name = "frmKategori";
            this.Text = "frmKategori";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKategori_FormClosed);
            this.Load += new System.EventHandler(this.frmKategori_Load);
            this.Click += new System.EventHandler(this.frmKategori_Load);
            this.grp_duzenle.ResumeLayout(false);
            this.grp_duzenle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_kat_sil;
        private System.Windows.Forms.TextBox txt_ekle;
        private System.Windows.Forms.GroupBox grp_duzenle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_duz;
        private System.Windows.Forms.Button btn_Duzenle;
        private System.Windows.Forms.ComboBox cmb_duzenle;
        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.ListBox listBox_kat;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Label lbl_kat_ekle;
        private System.Windows.Forms.ComboBox cmb_sil;
        private System.Windows.Forms.Button btn_geri;
    }
}