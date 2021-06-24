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
using System.Collections;
using System.Text.RegularExpressions;

namespace CafeProject
{
    public partial class frmKategori : Form
    {
        DbProcess db = new DbProcess();
        public frmKategori()
        {
            InitializeComponent();

        }
        ArrayList katId = new ArrayList();
        ArrayList katAdi = new ArrayList();
        String katadi = "";

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            String input = txt_ekle.Text;
            if (txt_ekle.Text == "" || txt_ekle.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen Kategori Giriniz!");
            }
            else if (!Regex.IsMatch(input, @"^[ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz ]+$"))
            {
                MessageBox.Show("Lütfen Sadece Harf Giriniz!");
            }
            else
            {
                             
                kategoriEkle(txt_ekle.Text);
                katDoldur();
                cmbDoldur();
                txt_ekle.Text = "";
            }
        }

        private void frmKategori_Load(object sender, EventArgs e)
        {
            cmbDoldur();
            katDoldur();
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            if (cmb_sil.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Seçim Yapınız!");
            }
            else
            {
                SqlCommand cm = new SqlCommand("kat_sil", db.dbConnect());
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add("@id", SqlDbType.Int).Value = katId[cmb_sil.SelectedIndex];
                db.dbConnect();
                cm.ExecuteNonQuery();
                db.dbClose();
                cmbDoldur();
                katDoldur();
                cmb_sil.Text = "";
            }
        }

        private void btn_Duzenle_Click(object sender, EventArgs e)
        {
            String input2 = txt_duz.Text;
            if (cmb_duzenle.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Seçim Yapınız");
            }
            else if (!Regex.IsMatch(input2, @"^[ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZabcçdefgğhıijklmnoöprsştuüvyz ]+$"))
            {
                MessageBox.Show("Lütfen Sadece Harf Giriniz!");
            }
            else
            {
                String adi = txt_duz.Text;
                SqlCommand cm2 = new SqlCommand("kat_duz", db.dbConnect());
                cm2.CommandType = CommandType.StoredProcedure;
                cm2.Parameters.Add("@id", SqlDbType.Int).Value = katId[cmb_duzenle.SelectedIndex];
                cm2.Parameters.Add("@adi", SqlDbType.VarChar, 255).Value = txt_duz.Text;
                db.dbConnect();
                cm2.ExecuteNonQuery();
                db.dbClose();
                cmbDoldur();
                katDoldur();
                cmb_duzenle.Text = "";
                txt_duz.Text = "";
            }
        }

        public void katDoldur()
        {
            katAdi.Clear();
            katId.Clear();
            listBox_kat.Items.Clear();
            db.dbConnect();
            SqlDataReader dr = db.getData("select * from kategoriler");
            while (dr.Read())
            {
                listBox_kat.Items.Add(dr["adi"].ToString());
                katId.Add(dr["id"].ToString());
                katAdi.Add(dr["adi"].ToString());
                txt_ekle.Clear();
            }
        }
        public void cmbDoldur()
        {
            cmb_sil.Items.Clear();
            cmb_duzenle.Items.Clear();
            SqlCommand cm1 = new SqlCommand("select * from kategoriler", db.dbConnect());
            db.dbConnect();
            SqlDataReader oku = cm1.ExecuteReader();
            katAdi.Clear();
            katId.Clear();
            while (oku.Read())
            {
                cmb_sil.Items.Add(oku["adi"].ToString());
                cmb_duzenle.Items.Add(oku["adi"].ToString());
                katAdi.Add(oku["adi"].ToString());
                katId.Add(oku["id"].ToString());
            }
            db.dbClose();
        }
        private void kategoriEkle(string kategori)
        {
            bool durum = false;
            foreach (String item in katAdi)
            {
                String item1 = item.Trim();
                if (item1.Contains(kategori.ToLower()))
                {
                    MessageBox.Show("Bu Kategori İsmi Daha Önce Girilmiş!");
                    durum = false;
                    break;
                }
                else
                {
                    durum = true;
                }
            }
            if (durum)
            {
                cmb_sil.Items.Add(txt_ekle.Text);
                cmb_duzenle.Items.Add(txt_ekle.Text);
                katadi = txt_ekle.Text;
                SqlCommand cm = new SqlCommand("kat_ekle", db.dbConnect());
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add("@adi", SqlDbType.VarChar, 255).Value = katadi;
                db.dbConnect();
                cm.ExecuteNonQuery();
                db.dbClose();
            }
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            frmAdminPaneli adminPaneli = new frmAdminPaneli();
            adminPaneli.Show();
            this.Hide();
           
        }

        private void frmKategori_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAdminPaneli fm = new frmAdminPaneli();
            fm.Show();
            this.Hide();
        }
    }
}