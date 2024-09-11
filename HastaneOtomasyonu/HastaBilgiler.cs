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
    public partial class HastaBilgiler : Form
    {
        Veritabani veritabani = new Veritabani();
        Hasta _hasta;
        public HastaBilgiler(Hasta hasta)
        {
            InitializeComponent();
            _hasta = hasta;
        }

        private void HastaBilgiler_Load(object sender, EventArgs e)
        {
            Yenile();
        }

        private void Yenile()
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
            maskedTextBox1.Text = _hasta.TC;
            textBox1.Text = _hasta.HastaAdi;
            textBox2.Text = _hasta.HastaSoyadi;
            textBox3.Text = _hasta.HastaMail;
            textBox4.Text = _hasta.HastaKullaniciAdi;
            textBox5.Text = _hasta.HastaParola;
            textBox6.Text = _hasta.ProfilResmi;
            richTextBox1.Text = _hasta.Adres;
            maskedTextBox3.Text = _hasta.HastaCepTel;
            comboBox1.Text = _hasta.HastaCinsiyeti;
            comboBox2.Text = _hasta.KanGrubu;
            comboBox3.Text = _hasta.HastaDogumYeri;
            maskedTextBox2.Text = _hasta.HastaDogumTarihi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hasta updateHasta = _hasta;
            updateHasta.HastaCepTel = maskedTextBox3.Text;
            updateHasta.Adres = richTextBox1.Text;
            updateHasta.HastaMail = textBox3.Text;
            updateHasta.HastaKullaniciAdi = textBox4.Text;
            updateHasta.HastaParola = textBox5.Text;
            updateHasta.ProfilResmi = textBox6.Text;
            updateHasta.KanGrubu = comboBox2.Text;
            var updatedEntity = veritabani.Entry(updateHasta);
            updatedEntity.State = EntityState.Modified;
            veritabani.SaveChanges();
            _hasta = updateHasta;
            MessageBox.Show("hasta bilgileri başarıyla güncellendi");
            Yenile();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var hedefKlasorYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProfilResimleri");

                Directory.CreateDirectory(hedefKlasorYolu);

                string dosyaAdi = new Random().Next(1111, 9999).ToString() + Path.GetFileName(openFileDialog.FileName);
                string hedefDosyaYolu = Path.Combine(hedefKlasorYolu, dosyaAdi);

                File.Copy(openFileDialog.FileName, hedefDosyaYolu, true);

                textBox6.Text = "/" + dosyaAdi;

            }
        }
    }
}
