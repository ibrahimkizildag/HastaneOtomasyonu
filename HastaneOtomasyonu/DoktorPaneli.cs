using HastaneOtomasyonu.Tablolar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class DoktorPaneli : Form
    {
        Doktor _doktor;
        Veritabani veritabani = new Veritabani();
        public DoktorPaneli(Doktor doktor)
        {
            InitializeComponent();
            _doktor = doktor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var doktor = veritabani.Doktorlar.Where(x => x.TC == label5.Text).FirstOrDefault();
            if (doktor != null)
            {
                DoktorBilgiler bilgilerim = new DoktorBilgiler(doktor);
                bilgilerim.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorRandevu doktorRandevu = new DoktorRandevu(_doktor);
            doktorRandevu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SekreterDuyurular duyurular = new SekreterDuyurular();
            duyurular.Show();
        }

        private void DoktorPaneli_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = veritabani.Duyurular.ToList();
                Image resim = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ProfilResimleri" + _doktor.ProfilResmi);
                pictureBox1.Image = resim;
            }
            catch (Exception)
            {
                pictureBox1.Image = Properties.Resources.logo;
            }
            label7.Text = _doktor.DoktorAdi;
            label6.Text = _doktor.DoktorSoyadi;
            label5.Text = _doktor.TC;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
