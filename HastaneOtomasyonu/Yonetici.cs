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
    public partial class Yonetici : Form
    {
        Veritabani veritabani;
        public Yonetici()
        {
            veritabani = new Veritabani();
            InitializeComponent();
        }

        private void Yonetici_Load(object sender, EventArgs e)
        {
            var duyurular = veritabani.Duyurular.ToList();
            dataGridView1.DataSource = duyurular;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yoneticiler yoneticiler = new Yoneticiler();
            yoneticiler.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YoneticiDoktorEkle doktorekle = new YoneticiDoktorEkle();
            doktorekle.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Yoneticiİletisim yiletisim = new Yoneticiİletisim();
            yiletisim.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            YoneticiPersoneller personeller = new YoneticiPersoneller();
            personeller.Show();
        }
    }
}
