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

namespace CafeProject
{
    public partial class frmAyarlar : Form
    {
        DbProcess db = new DbProcess("CafeProject");
        SqlDataReader dr = null;
        String filePath;
        public void kullaniciGetir()
        {
            db.dbConnect();
            SqlDataReader reader = db.getData("select * from kullanicilar");
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["kulAdi"].ToString());

            }
            db.dbClose();
        }
        public void sifreDegistir()
        {
            SqlCommand com = new SqlCommand("sifreDegistirme", db.dbConnect());
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@sifre", SqlDbType.Int).Value = DbProcess.md5Encrypt(textBox1.Text.ToString());
            com.Parameters.Add("@kulAdi", SqlDbType.VarChar, 50).Value = comboBox1.Text.ToString();

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Lütfen Şifresini Değiştirmek İstediğiniz Kullanıcı Adını Seçiniz !!!");
            }
            else
            {
                db.dbConnect();
                dr = com.ExecuteReader();

                MessageBox.Show("Şifre Değiştirme İşlemi Başarılı !!!");

            }
        }
        private void logoGetir()
        {
            db.dbConnect();
            SqlDataReader reader = db.getData("select logo from sirket");
            while (reader.Read())
            {

                pictureBox1.ImageLocation = reader["logo"].ToString();


            }
            db.dbClose();
        }
        private void logoDegistir()
        {
          
                db.dbConnect();
                SqlDataReader reader = db.getData("update sirket set logo='" + textBox3.Text.ToString() + "'");
                db.dbClose();
            

        }
        private void sirketBilgileriGetir()
        {
            db.dbConnect();
            SqlCommand com = new SqlCommand("select * from sirket", db.dbConnect());

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                label5.Text = dr["sirketAdi"].ToString();
                label7.Text = dr["telefon"].ToString();
                label8.Text = dr["fax"].ToString();
                label10.Text = dr["aciklama"].ToString();
            }
            db.dbClose();
        }
        private void checkboxUpdate()
        {
            if (checkBox1.Checked == true)
            {
                db.dbConnect();
                SqlDataReader reader = db.getData("update sirket set sirketAdi='" + textBox4.Text.ToString() + "' where sirketAdi='" + label5.Text.ToString() + "'");
                db.dbClose();
            }

            else if (checkBox2.Checked == true)
            {
                db.dbConnect();
                SqlDataReader reader = db.getData("update sirket set telefon='" + textBox4.Text.ToString() + "' where sirketAdi='" + label5.Text.ToString() + "'");
                db.dbClose();
            }

            else if (checkBox3.Checked == true)
            {
                db.dbConnect();
                SqlDataReader reader = db.getData("update sirket set fax='" + textBox4.Text.ToString() + "' where sirketAdi='" + label5.Text.ToString() + "'");
                db.dbClose();
            }

            else if (checkBox4.Checked == true)
            {
                db.dbConnect();
                SqlDataReader reader = db.getData("update sirket set aciklama='" + textBox4.Text.ToString() + "' where sirketAdi='" + label5.Text.ToString() + "'");
                db.dbClose();
            }

            else
            {
                MessageBox.Show("Lütfen Değiştirmek İstediğiniz Alanı İşaretleyin");
            }
        }
        private void gozat()
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Dosya Konumu Seç";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PictureBox PictureBox1 = new PictureBox();
                
                    pictureBox1.Image = new Bitmap(dlg.FileName);
          
                    filePath = dlg.FileName;

                    db.dbConnect();
                    SqlDataReader reader = db.getData("update sirket set logo='" + filePath + "'");
                    db.dbClose();
                  
                }
            }
        }
        public frmAyarlar()
        {
            InitializeComponent();
        }

        private void frmAyarlar_Load(object sender, EventArgs e)
        {

            textBox4.Enabled = false;
            kullaniciGetir();
            logoGetir();
            sirketBilgileriGetir();

            // combobox1'in properties'den DropDownStyle özelliğini 'DropDownList' yaptım
            // böylece combobox içine veri yazılamayacak.
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            textBox4.Enabled = true;

            if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                textBox4.Enabled = false;
            }


        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            textBox4.Enabled = true;

            if (checkBox2.Checked == false)
            {
                checkBox1.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                textBox4.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = false;
            checkBox1.Enabled = false;
            checkBox4.Enabled = false;
            textBox4.Enabled = true;
            if (checkBox3.Checked == false)
            {
                checkBox2.Enabled = true;
                checkBox1.Enabled = true;
                checkBox4.Enabled = true;
                textBox4.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = false;
            checkBox3.Enabled = false;
            checkBox1.Enabled = false;
            textBox4.Enabled = true;
            if (checkBox4.Checked == false)
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox1.Enabled = true;
                textBox4.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkboxUpdate();
            sirketBilgileriGetir();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                sifreDegistir();
            }
            else
            {
                MessageBox.Show("Girmiş Olduğunuz Şifreler Aynı Değildir !!!");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen Bir Url Giriniz !!!");
            }

            else
            {
                logoDegistir();
                logoGetir();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gozat();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(filePath);
        }
    }
}


