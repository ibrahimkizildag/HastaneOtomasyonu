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
    public partial class YoneticiSifremiUnuttum : Form
    {
        Veritabani veritabani;
        public YoneticiSifremiUnuttum()
        {
            InitializeComponent();
            veritabani = new Veritabani();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var doktorEmail = textBox1.Text;

            var yonetici = veritabani.Yoneticiler.FirstOrDefault(x => x.YoneticiMail == doktorEmail);
            if (yonetici is null)
            {
                MessageBox.Show("böyle bir email'e ait yönetici bulunamadı");
            }
            else
            {
                MailSender.Send(yonetici.YoneticiMail, $"şifreniz : {yonetici.YoneticiSifre}");
                MessageBox.Show("Mailinize şifreniz gönderildi.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            YoneticiGirisi yoneticiGirisi = new YoneticiGirisi();
            yoneticiGirisi.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
