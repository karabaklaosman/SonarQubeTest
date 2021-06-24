using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeProject
{
    public partial class frmAdminPaneli : Form
    {
        public frmAdminPaneli()
        {
            InitializeComponent();
        }
        int idAdmin = -1;
        public frmAdminPaneli(int id)
        {
            InitializeComponent();
            idAdmin = id;
        }
        private void frmAdminPaneli_Load(object sender, EventArgs e)
        {

        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            frmKategori kat = new frmKategori();
            kat.Show();
            this.Close();
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            frmUrunler urun = new frmUrunler();
            urun.Show();
            this.Close();
        }

        private void btnUrunDetay_Click(object sender, EventArgs e)
        {
           /*
            frmUrunler2 f = new frmUrunler2();
            f.Show();
            this.Close();
            * */
        }

        private void btnProfil_Click(object sender, EventArgs e)
        {
            frmProfil profil = new frmProfil();
            profil.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAyarlar ayar = new frmAyarlar();
            ayar.Show();
            this.Close();
        }
    }
}
