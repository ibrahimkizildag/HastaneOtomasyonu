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

namespace HastaneOtomasyonu
{
    public partial class DoktorGirisi : Form
    {
        Veritabani veritabani = new Veritabani();
        public DoktorGirisi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GirisEkrani giris = new GirisEkrani();
            giris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string doktorKAdi = textBox1.Text;
            string doktorSifre = textBox2.Text;
            var doktor = veritabani.Doktorlar.Where(x => x.KullaniciAdi == doktorKAdi && x.Sifre == doktorSifre).FirstOrDefault();
            if (doktor != null)
            {
                DoktorPaneli doktorPanel = new DoktorPaneli(doktor);
                AppInfo.GirisYapanDoktorTc = doktor.TC;
                MessageBox.Show("başarıyla giriş yapıldı");
                doktorPanel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("kullanıcı adı veya şifre yanlış");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoktorSifremiUnuttum sifremiUnuttum = new DoktorSifremiUnuttum();
            sifremiUnuttum.Show();
        }
    }
}
