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
    public partial class HastaGirisi : Form
    {
        Veritabani veritabani = new Veritabani();
        public HastaGirisi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var hasta = veritabani.Hastalar.Where(x => x.HastaKullaniciAdi == textBox1.Text && x.HastaParola == textBox2.Text).FirstOrDefault();
            if (hasta != null)
            {
                MessageBox.Show("Başarıyla giriş yaptınız.");
                AppInfo.GirisYapanHastaTc = hasta.TC;
                HastaPanel hastaPanel = new HastaPanel(hasta);
                hastaPanel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("kullanıcı veya şifre yanlış");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GirisEkrani giris = new GirisEkrani();
            giris.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaSifremiUnuttum sifremiUnuttum = new HastaSifremiUnuttum();
            sifremiUnuttum.Show();
        }
    }
}
