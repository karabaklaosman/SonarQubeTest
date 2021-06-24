using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeProject
{
    public partial class GarsonGuncellemeEkrani : Form
    {

        DbProcess db = new DbProcess();
        // Deneme amaclı id ataması
        int gelenId = 2;
        String gelenTc;

        public GarsonGuncellemeEkrani()
        {
            InitializeComponent();
        }

        private void GarsonGuncellemeEkrani_Load(object sender, EventArgs e)
        {
            fncDataGetir();

        }

        private void txtTcNo_TextChanged(object sender, EventArgs e)
        {
            fncTcKontrol();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            fncTcKontrol();

            gelenTc = txtTcNo.Text;
            SqlCommand cmd = new SqlCommand("SPTcNoGuncelle", db.dbConnect());
            db.dbConnect();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tcno", SqlDbType.VarChar, 11).Value = txtTcNo.Text;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = gelenId;//!Kullanıcının Gelen ID si eklenecek
            cmd.ExecuteNonQuery();
            db.dbClose();

            gelenTc = txtTcNo.Text;
            string mail = txtMail.Text;
            if (fncTcFormat(gelenTc) == false)
            {
                label8.Text = "yanlış tc formatı Lütfen kontrol ediniz";
            }

            if (!fncMailFormat(mail))
            {
                label9.Text = "Mail Adresinizi kontrol ediniz";

            }

            if (!fncSifreKontrol())
            {
                label11.Text = "Girilen Şifreler eşleşmiyor";
            }


            SqlCommand cm = new SqlCommand("SP_GarsonGuncelleme", db.dbConnect());

            cm.CommandType = CommandType.StoredProcedure;

            cm.Parameters.Add("@adi", SqlDbType.VarChar, 50).Value = txt_kulAdı.Text;
            cm.Parameters.Add("@sifre", SqlDbType.VarChar, 32).Value = txtSifre.Text;
            cm.Parameters.Add("@tel", SqlDbType.VarChar, 100).Value = txtTel.Text;
            cm.Parameters.Add("@mail", SqlDbType.VarChar, 255).Value = txtMail.Text;
            cm.Parameters.Add("@adres", SqlDbType.VarChar, 500).Value = txtAdres.Text;
            cm.Parameters.Add("@id", SqlDbType.Int).Value = gelenId;//!Kullanıcının Gelen ID si eklenecek

            db.dbConnect();
            cm.ExecuteNonQuery();
            db.dbClose();


        }

        public static bool fncTcFormat(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);

                // bolu yuz islemi int tanimlanmis degiskende son 2 haneyi silmek icin kullanılır.

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                /*
                Q1 TC nosunun 10. hanesi
                Q2 TC nosunun 11. hanesi
                BTCNO son 2 hanesi olmayan tckimlikNo
                */

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }


        public void fncTcKontrol()
        {

            db.dbConnect();
            SqlDataReader dr = db.getData("SELECT tcno, adi FROM profil ,kullanicilar where kullanicilar.profilID=profil.id ");

            dr.Read();

            if (dr["tcno"].ToString() == "")
            {

                gelenTc = txtTcNo.Text;
            }

            else if (dr["tcno"].ToString() != "")
            {
                txtTcNo.ReadOnly = true;
                label7.Text = "yönetici zaten sizi eklemiş. Değiştirme Yapamazsınız.";

            }
            db.dbClose();
        }


        public static bool fncMailFormat(string mail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(mail);
            if (match.Success)
                return true;
            else
                return false;
        }


        public bool fncSifreKontrol()
        {
            if (txtSifre.Text.Trim() == txtSifreTekrar.Text.Trim())
                return true;
            else
                return false;
        }


        public void fncDataGetir()
        {
            db.dbConnect();
            SqlCommand com = new SqlCommand("SELECT kulAdi,sifre, tcno,mail,adres,telefon, adi FROM kullanicilar , profil  where kullanicilar.profilID=profil.id", db.dbConnect());
            SqlDataReader dr1 = com.ExecuteReader();

            dr1.Read();

            txtTcNo.Text = dr1["tcno"].ToString();
            txt_kulAdı.Text = dr1["kulAdi"].ToString();
            txtSifre.Text = dr1["sifre"].ToString();
            txtAdres.Text = dr1["adres"].ToString();
            txtMail.Text = dr1["mail"].ToString();
            txtTel.Text = dr1["telefon"].ToString();

            db.dbClose();

        }


    }


}
