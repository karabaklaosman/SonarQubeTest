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
    public partial class frmProfil : Form
    {
        DbProcess db = new DbProcess("CafeProject");

        public frmProfil()
        {
            InitializeComponent();

        }

        public void profilInsert(string adi, string soyadi, string telefon, string mail, string adres, string tcno, string notlar)
        {


            if (adi.Equals("") || soyadi.Equals("") || telefon.Equals("") || mail.Equals("") || adres.Equals("") || tcno.Equals("") || notlar.Equals(""))
            {


                MessageBox.Show("Lütfen tüm bilgileri doldurunuz.");
            }
            else if (!Regex.IsMatch(adi, @"^[ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZQWXabcçdefgğhıijklmnoöprsştuüvyzqwx]+$")||!Regex.IsMatch(soyadi, @"^[ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZQWXabcçdefgğhıijklmnoöprsştuüvyzqwx]+$"))
            {
               MessageBox.Show("Lütfen adı soyadı için sadece harf giriniz!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
            }
            else if (!Regex.IsMatch(telefon, @"^[0123456789+]+$"))
            {
                MessageBox.Show("Telefon numarası için yalnızca sayı giriniz!");
                textBox3.Text = "";
                textBox3.Focus();
            }
                
            else if (!IsValidEmail(textBox4.Text))
            {
            
                    MessageBox.Show("Hatalı formatta mail adresi girdiniz!");
                    textBox4.Text = "";
                    textBox4.Focus();
            }
            else if (textBox6.TextLength < 11 || textBox6.TextLength > 11)
            {
                MessageBox.Show("Tc kimlik numarası hatalı!");
                textBox6.Text = "";
                textBox6.Focus();
                
            }
            else
            {
                SqlCommand com = new SqlCommand("profilInsert", db.dbConnect());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@adi", SqlDbType.VarChar, 255).Value = adi;
                com.Parameters.Add("@soyadi", SqlDbType.VarChar, 255).Value = soyadi;
                com.Parameters.Add("@telefon", SqlDbType.VarChar, 255).Value = telefon;
                com.Parameters.Add("@mail", SqlDbType.VarChar, 255).Value = mail;
                com.Parameters.Add("@adres", SqlDbType.VarChar, 500).Value = adres;
                com.Parameters.Add("tcno", SqlDbType.VarChar, 11).Value = tcno;
                com.Parameters.Add("notlar", SqlDbType.VarChar, 500).Value = notlar;
                db.dbConnect();
                com.ExecuteNonQuery();
                db.dbClose();
                li.Clear();
                idTut();
                
                MessageBox.Show("Profil Kaydı Yapıldı");
            }
            db.dbConnect();
            int i =Convert.ToInt32(li[li.Count-1]);
            SqlCommand com1 = new SqlCommand("insert into kullanicilar(profilID) values (@id)", db.dbConnect());
            com1.Parameters.AddWithValue("@id",i);
            com1.ExecuteNonQuery();
            db.dbClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            profilInsert(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);
        }


        ArrayList li = new ArrayList();
        public void idTut()
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            SqlCommand com = new SqlCommand("select * from profil", db.dbConnect());
            db.dbConnect();
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                li.Add(Convert.ToInt32(dr["id"]));
                comboBox1.Items.Add(dr["adi"].ToString());
            }
            db.dbClose();
        }
        int id;
        private void button3_Click(object sender, EventArgs e)
        {
            
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Profil seçmeden güncelleme yapılamaz!");
                }
                else
                {
                    id = Convert.ToInt32(li[comboBox1.SelectedIndex]);
                    frmProfilGuncelleme profilGuncelleme = new frmProfilGuncelleme(id);
                    profilGuncelleme.Show();
                    this.Hide();
                }
            
        }

        private void frmProfil_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            idTut();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Profil Seçmeden silme işlemi yapılamaz!");
            }
            else
            {
                DialogResult durum = MessageBox.Show(comboBox1.Text + " kişisine ait kaydı silmek istediğinizden emin misiniz?", "Silme onayı", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == durum)
                {
                    profilDelete(id);
                }

            }
        }
        public void profilDelete(int id)
        {
            int idd;
            SqlCommand com1 = new SqlCommand("select * from profil where adi='" + comboBox1.SelectedItem + "'", db.dbConnect());
            db.dbConnect();
            SqlDataReader dr = com1.ExecuteReader();
            while (dr.Read())
            {
                idd = Convert.ToInt32(dr["id"]);

                SqlCommand com = new SqlCommand("profilDelete", db.dbConnect());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@id", SqlDbType.Int).Value = idd;
                db.dbConnect();
                com.ExecuteNonQuery();
                db.dbClose();
                MessageBox.Show("Profil başarıyla silindi.");

            }
            idTut();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             frmAdminPaneli fr = new  frmAdminPaneli();
             fr.Show();
             this.Hide();
        }

        private bool IsValidEmail(string mailDenetim)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(mailDenetim, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

    }
}
