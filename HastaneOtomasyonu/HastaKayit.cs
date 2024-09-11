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
using HastaneOtomasyonu.Tablolar;

namespace HastaneOtomasyonu
{
    public partial class HastaKayit : Form
    {
        Veritabani veritabani;
        public HastaKayit()
        {
            veritabani = new Veritabani();
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("lütfen bir tc kimlik giriniz");
                return;

            }
            try
            {

                Hasta hasta = new Hasta()
                {
                    TC = maskedTextBox1.Text,
                    HastaAdi = textBox1.Text,
                    HastaSoyadi = textBox2.Text,
                    HastaCepTel = maskedTextBox3.Text,
                    HastaMail = textBox3.Text,
                    HastaKullaniciAdi = textBox4.Text,
                    HastaParola = textBox5.Text,
                    HastaDogumYeri = comboBox3.Text,
                    HastaDogumTarihi = maskedTextBox2.Text,
                    HastaCinsiyeti = comboBox1.Text,
                    KanGrubu = comboBox2.Text,
                    Adres = richTextBox1.Text,
                    ProfilResmi = textBox6.Text,
                    HastaAnneAdi = "",
                    HastaBabaAdi = ""
                };
                veritabani.Hastalar.Add(hasta);
                veritabani.SaveChanges();
                MessageBox.Show("hasta başarıyla kaydedildi.");
            }
            catch
            {
                MessageBox.Show("lütfen tam olarak formu doldurunuz!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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
    }

}

