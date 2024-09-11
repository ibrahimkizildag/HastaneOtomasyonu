using HastaneOtomasyonu.Tablolar;
using Microsoft.EntityFrameworkCore;
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
    public partial class DoktorBilgiler : Form
    {
        Veritabani veritabani = new Veritabani();
        Doktor _doktor;
        public DoktorBilgiler(Doktor doktor)
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var klinikID = veritabani.Klinikler.Where(x => x.KlinikAdi == comboBox1.Text).FirstOrDefault();
            var doktor = veritabani.Doktorlar.FirstOrDefault(x => x.TC == maskedTextBox1.Text);

            doktor.KullaniciAdi = textBox4.Text;
            doktor.Sifre = textBox1.Text;
            doktor.DoktorAdres = richTextBox1.Text;
            doktor.DoktorTel = maskedTextBox2.Text;
            doktor.DoktorEmail = textBox5.Text;

            veritabani.Doktorlar.Update(doktor);
            veritabani.SaveChanges();

            _doktor = doktor;
            Yenile();
            MessageBox.Show("başarıyla bilgileriniz güncellendi.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var hedefKlasorYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProfilResimleri");

                // Hedef klasörü oluştur
                Directory.CreateDirectory(hedefKlasorYolu);

                // Seçilen resmi kopyala
                string dosyaAdi = new Random().Next(1111, 9999).ToString() + Path.GetFileName(openFileDialog.FileName);
                string hedefDosyaYolu = Path.Combine(hedefKlasorYolu, dosyaAdi);

                File.Copy(openFileDialog.FileName, hedefDosyaYolu, true);
                pictureBox1.Image = Image.FromFile(hedefDosyaYolu);

                textBox6.Text = "/" + dosyaAdi;

            }
        }

        private void DoktorBilgiler_Load(object sender, EventArgs e)
        {
            _doktor = veritabani.Doktorlar.FirstOrDefault(x => x.TC == AppInfo.GirisYapanDoktorTc);
            Yenile();
        }

        private void Yenile()
        {
            try
            {
                Image resim = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "ProfilResimleri" + _doktor.ProfilResmi);
                pictureBox1.Image = resim;
            }
            catch (Exception)
            {
                pictureBox1.Image = Properties.Resources.logo;
            }
            var klinik = veritabani.Klinikler.Where(x => x.Id == _doktor.DoktorKlinikId).FirstOrDefault();
            maskedTextBox1.Text = _doktor.TC;
            textBox2.Text = _doktor.DoktorAdi;
            textBox3.Text = _doktor.DoktorSoyadi;
            textBox4.Text = _doktor.KullaniciAdi;
            textBox5.Text = _doktor.DoktorEmail;
            maskedTextBox2.Text = _doktor.DoktorTel;
            textBox1.Text = _doktor.Sifre;
            comboBox1.Text = klinik.KlinikAdi;
            richTextBox1.Text = _doktor.DoktorAdres;
        }
    }
}
