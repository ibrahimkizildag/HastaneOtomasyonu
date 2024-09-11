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
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YoneticiGirisi yonetici = new YoneticiGirisi();
            yonetici.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HastaKayit hastakayit = new HastaKayit();
            hastakayit.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoktorGirisi doktorgiris = new DoktorGirisi();
            doktorgiris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HastaGirisi hastagiris = new HastaGirisi();
            hastagiris.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SekreterGirisi sekretergiris = new SekreterGirisi();
            sekretergiris.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
