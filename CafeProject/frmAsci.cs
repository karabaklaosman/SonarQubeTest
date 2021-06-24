using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using System.Data.SqlClient;


namespace CafeProject
{
    public partial class frmAsci : Form
    {
        DbProcess db = new DbProcess();
        private void dataGetir()
        {
            SqlCommand cm = new SqlCommand("urunGetir", db.dbConnect());
            cm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public frmAsci()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        int asciId = -1;
        public frmAsci(int asciId)
        {
            InitializeComponent();
            this.asciId = asciId;
        }

        private void frmAsci_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(calisAsci));
            thread.Start();
        }
        private void calisAsci()
        {

            for (int i = 0; true; i++)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    dataGetir();
                }));
                Thread.Sleep(10000);
            } 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAsciAyarlar frm = new frmAsciAyarlar();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int idd = dataGridView1.SelectedCells[0].RowIndex;
                //MessageBox.Show("" + idd);


                SqlDataReader reader = db.getData("update sepet set durum = 3 where id ='" + idd + "'");

                db.dbClose();
                dataGetir();
                MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleşti !!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Bir Kolon Seçiniz !!! " + ex);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int idd = dataGridView1.SelectedCells[0].RowIndex;
               // MessageBox.Show("" + idd);


                SqlDataReader reader = db.getData("update sepet set durum = 2 where id ='" + idd + "'");

                db.dbClose();
                dataGetir();
               // MessageBox.Show("Ürünümüz Hazırlanıyor...!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Bir Kolon Seçiniz !!! " + ex);
            }


        }



    }
}

