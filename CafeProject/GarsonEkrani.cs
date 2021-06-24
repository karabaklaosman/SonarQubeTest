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

using System.Threading;

namespace CafeProject
{
    public partial class GarsonEkrani : Form
    {
        GarsonGuncellemeEkrani gr = new GarsonGuncellemeEkrani();
        DbProcess db = new DbProcess();

        int gelenID;//Garson id 
        public GarsonEkrani()
        {
            InitializeComponent();
        }
        public GarsonEkrani(int id)
        {
            InitializeComponent();
            gelenID = id;
        }


        private void ThreadTask()
        {
         
                    while (true)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                         {
                             DataGetir();

                         }));
                        Thread.Sleep(5000);
               }
        }
        private void GarsonEkrani_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread trd = new Thread(new ThreadStart(ThreadTask));
            trd.Start();

            DataGetir();
            renklendir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.dbClose();
            gr.Show(); //Button'a týkladýðýmýz zaman garson güncelleme ekranýna geçmesini saðlýyoruz

            this.Hide();

        }

        public void DataGetir()
        {
            SqlCommand cm = new SqlCommand("SP_MasaBilgler", db.dbConnect());
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.Add("@id", SqlDbType.Int).Value = gelenID;
            db.dbConnect();
            cm.ExecuteNonQuery();

            SqlDataReader rd = cm.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            dataGridView1.DataSource = dt;
            db.dbClose();

            Thread.Sleep(1000);
        }

        public void renklendir()
        {

            try
            {

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    Application.DoEvents();

                    DataGridViewCellStyle rowColor = new DataGridViewCellStyle();

                    //durum sutunundaki degere göre satir rengi degistiriyoruz.
                    if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) == 0)//Masa Dolu
                    {

                        // Masa dolu olanlar OrangeRed rengini veriyoruz.
                        rowColor.BackColor = Color.Pink;
                        //yazi rengi beyaz oluyor.
                        rowColor.ForeColor = Color.White;
                    }
                    else if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) == 1)//Ödeme Yapýlmýs masa avaliable
                    {
                        rowColor.BackColor = Color.Blue;
                        rowColor.ForeColor = Color.White;
                    }
                    else if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) == 2)//Aþcýya sipariþ verildi
                    {
                        rowColor.BackColor = Color.OrangeRed;
                        rowColor.ForeColor = Color.White;
                    }

                    //satir rengini degistiriyoruz.

                    dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            String refKodu = Convert.ToString(dataGridView1.CurrentRow.Cells["refKodu"].Value);
            if (refKodu != "")
            {
                SqlCommand cmd = new SqlCommand("SP_SiparisBilgileri", db.dbConnect());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@refKodu", SqlDbType.Int).Value = refKodu;
                cmd.ExecuteNonQuery();
                SqlDataReader rdd = cmd.ExecuteReader();
                if (rdd.Read())
                {
                    textBox1.Text = rdd["adi"].ToString();
                    label6.Visible = true;
                    label6.Text = rdd["toplamTutar"].ToString();
                }
                db.dbClose();
                SqlCommand cm = new SqlCommand("SP_OdemeTur", db.dbConnect());
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.Add("@refKodu", SqlDbType.Int).Value = refKodu;
                cm.ExecuteNonQuery();
                SqlDataReader rd = cm.ExecuteReader();

                if (rd.Read())
                {
                    String odeme = rd["odemeTur"].ToString();
                    if (odeme.Equals(""))
                    {
                        label2.Visible = true;
                        label2.Text = "KREDÝ KARTI";

                    }
                    else
                    {
                        label2.Visible = true;
                        label2.Text = "NAKÝT";
                    }

                    db.dbClose();
                }


            }



        }



    }
}
