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
    public partial class HastaPanel : Form
    {
        Hasta _hasta;
        public HastaPanel(Hasta hasta)
        {
            InitializeComponent();
            _hasta = hasta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaRandevularım hastaradevular = new HastaRandevularım(_hasta);
            hastaradevular.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaBilgiler hastaBilgiler = new HastaBilgiler(_hasta);
            hastaBilgiler.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HastaRandevu hastarandevu = new HastaRandevu(_hasta);
            hastarandevu.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hastaİletisim iletisim = new Hastaİletisim();
            iletisim.Show();
        }

        private void HastaPanel_Load(object sender, EventArgs e)
        {
            try
            {
                Image resim = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ProfilResimleri" + _hasta.ProfilResmi);
                pictureBox1.Image = resim;
            }
            catch (Exception)
            {
                pictureBox1.Image = Properties.Resources.logo;
            }
            label7.Text = _hasta.HastaAdi;
            label6.Text = _hasta.HastaSoyadi;
            label5.Text = _hasta.TC;
        }
    }
}
