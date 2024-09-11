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
    public partial class SekreterSifremiUnuttum : Form
    {
        Veritabani veritabani;
        public SekreterSifremiUnuttum()
        {
            InitializeComponent();
            veritabani = new Veritabani();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SekreterGirisi sekreterGirisi = new SekreterGirisi();
            sekreterGirisi.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sekreter = veritabani.Sekreterler.FirstOrDefault(x => x.SekreterMail == textBox1.Text);
            if (sekreter == null)
            {
                MessageBox.Show("böyle bir sekreter hesabı bulunamadı");
            }
            else
            {
                MailSender.Send(sekreter.SekreterMail, "Şifreniz => " + sekreter.SekreterSifre);
                MessageBox.Show("mailinize başarıyla şifreniz gönderildi.");
            }
        }
    }
}
