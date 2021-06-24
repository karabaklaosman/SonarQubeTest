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

namespace CafeProject
{
    public partial class frmAsciAyarlar : Form
    {
        DbProcess db = new DbProcess();

        public frmAsciAyarlar()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
         int asciId = -1;

            SqlDataAdapter da = new SqlDataAdapter("select sifre from kullanicilar where sifre ='" + DbProcess.md5Encrypt(textBox2.Text.Trim()) + "' and id = '" + asciId + "'", db.dbConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count.ToString() == "1")
            {
                if (textBox3.Text == textBox4.Text)
                {
                    db.dbConnect();
                    SqlCommand cm = new SqlCommand("Update kullanicilar set sifre = '" +DbProcess.md5Encrypt(textBox4.Text.Trim()) + "' where id = '" + asciId + "'", db.dbConnect());
                    cm.ExecuteNonQuery();

                    db.dbClose();
                    MessageBox.Show("Şifre Güncellendi !");

                }
                else {

                    MessageBox.Show("Yeni Şifre İle Yeni Şifre Tekrar Aynı Olmalı !");
                }

            }
            else {
                MessageBox.Show("Lütfen Eski Şifrenizi Kontrol Ediniz !");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAsci ns = new frmAsci();
            ns.Show();
            this.Hide();

        }

    }
}