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
    public partial class SekreterGirisi : Form
    {
        Veritabani veritabani;
        public SekreterGirisi()
        {
            InitializeComponent();
            veritabani = new Veritabani();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GirisEkrani giris = new GirisEkrani();
            giris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sekreterKullaniciAdi = textBox1.Text;
            var sekreterSifre = textBox2.Text;

            var sekreter = veritabani.Sekreterler.FirstOrDefault(x => x.SekreterKullaniciAdi == sekreterKullaniciAdi && x.SekreterSifre == sekreterSifre);
            if (sekreter == null)
            {
                MessageBox.Show("kullanıcı adı veya şifre yanlış");
                return;

            }

            SekreterPaneli sekreterPaneli = new SekreterPaneli();
            sekreterPaneli.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SekreterSifremiUnuttum sekreterSifremiUnuttum = new SekreterSifremiUnuttum();
            sekreterSifremiUnuttum.Show();

            this.Hide();
        }
    }
}
