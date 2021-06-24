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
namespace CafeProject
{
    public partial class frmUrunler : Form
    {
        DbProcess db = new DbProcess();

        public frmUrunler()
        {
            InitializeComponent();

            katIdDoldur();
        }

        public void katIdDoldur()
        {
            db.dbConnect();
            SqlDataAdapter da = new SqlDataAdapter("select id from kategoriler", db.dbConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);

            db.dbClose();
            foreach (DataRow item in dt.Rows)
            {
                kategoriIdList.Add(Convert.ToInt32(item["id"]));
            }
        }

        ArrayList urunList = new ArrayList();
        ArrayList kategoriIdList = new ArrayList();
  
        public void urunDoldur()
        {

            urunlerListB.Items.Clear();

            SqlCommand cm1 = new SqlCommand("yiyecekG", db.dbConnect());
            cm1.CommandType = CommandType.StoredProcedure;
            cm1.Parameters.Add("@catID", SqlDbType.Int).Value = kategoriIdList[ktcomb1.SelectedIndex];

            db.dbConnect();

            SqlDataReader rd1 = cm1.ExecuteReader();

            while (rd1.Read())
            {


                urunList.Add(Convert.ToInt32(rd1["id"]));
                urunlerListB.Items.Add(rd1["adi"]);

            }




            db.dbClose();
        }






        private void frmYiyecek_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select *from kategoriler", db.dbConnect());
            db.dbConnect();
            SqlDataReader readd = cmd.ExecuteReader();
            while (readd.Read())
            {
                ktcomb1.Items.Add(readd["adi"].ToString());


            }
            db.dbClose();

            sil.Enabled = false;
            duzenle.Enabled = false;
            urun3.Enabled = false;
        }

        private void ktcomb1_SelectedIndexChanged(object sender, EventArgs e)
        {

            urunDoldur();
            if (urunList.Count > 0)
            {

                sil.Enabled = true;
                duzenle.Enabled = true;
            }
            else
            {
                sil.Enabled = false;
                duzenle.Enabled = false;
            }


        }


        private void ekle_Click_1(object sender, EventArgs e)
        {
            if (ktcomb1.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kategori seçiniz!");
            }
            else
            {
                if (urun.Text == "")
                {
                    MessageBox.Show("Lütfen eklemek istediğiniz ürün adını giriniz");
                }
                else
                {

                    String urunAdi = urun.Text;

                    String ekleSorgu = "insert into urunler(kategoriID,adi) values(@catId,'" + urunAdi + "')";
                    SqlCommand cm = new SqlCommand(ekleSorgu, db.dbConnect());
                    cm.Parameters.AddWithValue("@catId", kategoriIdList[ktcomb1.SelectedIndex]);
                    cm.ExecuteNonQuery();
                    urunDoldur();
                    urun.Text = "";

                }
            }
        }
        private void duzenle_Click(object sender, EventArgs e)
        {
            if (urunlerListB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen ürün düzenlemek için ürün seçiniz");

                if (urunlerListB.Items.Count == 0)
                {
                    MessageBox.Show("Lütfen ürün düzenlemek için ürün ekleyiniz");
                }
            }
            else
            {
                String urunAdi1 = urun2.Text;

                SqlCommand com = new SqlCommand("yiyecekGD", db.dbConnect());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@urunID", SqlDbType.Int).Value = urunList[urunlerListB.SelectedIndex];
                com.Parameters.Add("@urunAdi1", SqlDbType.VarChar, 255).Value = urun2.Text;
                db.dbConnect();
                com.ExecuteNonQuery();
                db.dbClose();


                urunDoldur();
                urun2.Text = "";
                urun3.Text = "";

            }

        }
        private void urunlerListB_SelectedIndexChanged(object sender, EventArgs e)
        {
            urun2.Text = urunlerListB.SelectedItem.ToString();
            urun3.Text = urunlerListB.SelectedItem.ToString();

            sil.Enabled = true;
            duzenle.Enabled = true;

        }
      
        private void sil_Click(object sender, EventArgs e)
        {
            if (urunlerListB.SelectedItems.Count == 0)
            {
                MessageBox.Show("Lütfen ürün silmek için ürün seçiniz");

                if (urunlerListB.Items.Count == 0)
                {
                    MessageBox.Show("Lütfen ürün silmek için ürün ekleyiniz");
                }
            }
            else
            {
                urun3.Text = urunlerListB.SelectedItem.ToString();
                SqlCommand com = new SqlCommand("yiyecekGS", db.dbConnect());
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@urunID", SqlDbType.Int).Value = urunList[urunlerListB.SelectedIndex];

                db.dbConnect();
                com.ExecuteNonQuery();
                db.dbClose();
                urunDoldur();
                urun3.Text = "";
                urun2.Text = "";
            }


        }
    }
}