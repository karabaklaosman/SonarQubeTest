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
using System.Data.OleDb;

namespace CafeProject
{
    public partial class frmMasaAtama : Form
    {
        DbProcess db = new DbProcess("CafeProject");
        SqlDataReader dr = null;
        public int id;



        public void kullaniciGetir()
        {
            db.dbConnect();
            SqlDataReader reader = db.getData("select adi,soyadi,seviye,p.id from kullanicilar as k inner join profil as p on k.profilID=p.id and p.kategoriID=2");
            while (reader.Read())
            {
                comboBox2.Items.Add(reader["adi"].ToString());
                id = (Convert.ToInt32( reader["id"]));
            }
            db.dbClose();
        }
        private void masaNoGetir()
        {
            SqlCommand cmd = new SqlCommand("Select * from masalar", db.dbConnect());
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader["adi"].ToString());
            }
            db.dbClose();
        }
        private void masaAtamaUpdate()
        {
            SqlCommand com = new SqlCommand("masaAtama", db.dbConnect());
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@id", SqlDbType.Int).Value = id;
            com.Parameters.Add("@masaNo", SqlDbType.VarChar, 500).Value = comboBox3.Text.ToString();

            db.dbConnect();
            dr = com.ExecuteReader();
       
                MessageBox.Show("Masa Atama İşlemi Başarılı !!!");
        
            db.dbClose();
        }
        private void masaAtamaInsert()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO masalar (profilID,adi) VALUES (@id,@ad,@acikla)", db.dbConnect());
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@ad", comboBox3.Text.ToString());
            db.dbConnect();
            cmd.ExecuteNonQuery();
            db.dbClose();
            MessageBox.Show("Masa Atanmıştır !!!");
        }


        public frmMasaAtama()
        {
            InitializeComponent();
        }

        private void frmMasaAtama_Load(object sender, EventArgs e)
        {
            kullaniciGetir();
            masaNoGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {


         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" && comboBox3.Text == "")
            {
                MessageBox.Show("Lütfen Çalışan ve Masa Adı Seçiniz !!! ");
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Lütfen Çalışan Seçiniz !!!");
            }

            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Lütfen Masa Adı Seçiniz !!!");
            }

            else
            {

                db.dbConnect();
              
                SqlDataReader reader = db.getData("select profilID from masalar where id='" + id + "'");
                if (reader.Read())
                {
                    masaAtamaUpdate();
                }

                else
                {
                    masaAtamaInsert();
                }
                db.dbClose();
            }
        }
    }
}

