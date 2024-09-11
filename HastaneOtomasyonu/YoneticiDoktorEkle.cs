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
using static System.Windows.Forms.LinkLabel;

namespace HastaneOtomasyonu
{
    public partial class YoneticiDoktorEkle : Form
    {
        Veritabani veritabani;
        public YoneticiDoktorEkle()
        {
            veritabani = new Veritabani();
            InitializeComponent();

            DataGridYenile();
        }

        public void DataGridYenile()
        {
            var doktorlar = veritabani.Doktorlar.ToList();
            foreach (var item in doktorlar)
            {
                item.DoktorKlinik = veritabani.Klinikler.FirstOrDefault(x => x.Id == item.DoktorKlinikId);
                if (item.DoktorKlinik == null)
                {
                    item.DoktorKlinik = new()
                    {
                        KlinikAdi = ""
                    };
                }

            }
            var dataGridSource = doktorlar.Select(x => new
            {
                Tc = x.TC,
                KullaniciAdi = x.KullaniciAdi,
                Sifre = x.Sifre,
                DoktorAdi = x.DoktorAdi,
                DoktorSoyadi = x.DoktorSoyadi,
                DoktorTel = x.DoktorTel,
                DoktorAdres = x.DoktorAdres,
                DoktorEmail = x.DoktorEmail,
                DoktorKlinik = x.DoktorKlinik.KlinikAdi ?? "",
            }).ToList();
            dataGridView1.DataSource = dataGridSource;
        }
        public void FormTemizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            richTextBox1.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var doktor = veritabani.Doktorlar.FirstOrDefault(x => x.TC == maskedTextBox1.Text);
            if (doktor is not null)
            {
                MessageBox.Show("böyle bir tc'ye sahip zaten bir doktor var ");
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Doktor eklerken bir klinik seçiniz");
                return;
            }


            var secilenKlinik = veritabani.Klinikler.FirstOrDefault(x => x.KlinikAdi == comboBox1.Text);

            if (secilenKlinik == null)
            {
                MessageBox.Show("Böyle bir klinik mevcut değil");
                return;
            }
            Doktor eklencekDoktor = new Doktor()
            {
                TC = maskedTextBox1.Text,
                DoktorAdi = textBox2.Text,
                DoktorSoyadi = textBox3.Text,
                DoktorKlinikId = secilenKlinik.Id,
                KullaniciAdi = textBox4.Text,
                Sifre = textBox1.Text,
                DoktorEmail = textBox5.Text,
                DoktorAdres = richTextBox1.Text,
                DoktorTel = maskedTextBox2.Text,

            };

            veritabani.Doktorlar.Add(eklencekDoktor);
            veritabani.SaveChanges();
            MessageBox.Show("başarıyla eklenmiştir.");
            FormTemizle();
            DataGridYenile();
        }

        private void YoneticiDoktorEkle_Load(object sender, EventArgs e)
        {
            var klinikler = veritabani.Klinikler.Select(x => x.KlinikAdi).ToList();
            comboBox1.Items.AddRange(klinikler.ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string doktorTc = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (string.IsNullOrEmpty(doktorTc))
            {
                MessageBox.Show("lütfen tablodan bir doktor seçiniz");
                return;
            }

            var doktor = veritabani.Doktorlar.FirstOrDefault(x => x.TC == doktorTc);
            if (doktor is null)
            {
                MessageBox.Show("böyle bir doktor yoktur");
                return;
            }

            veritabani.Doktorlar.Remove(doktor);
            veritabani.SaveChanges();

            MessageBox.Show("başarıyla doktor silindi.");
            FormTemizle();
            DataGridYenile();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var tcKimlik = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var doktor = veritabani.Doktorlar.FirstOrDefault(x => x.TC == tcKimlik);
            if (tcKimlik == null)
            {
                MessageBox.Show("böyle bir doktor bulunamadı");
                DataGridYenile();
            }
            else
            {
                var secilenKlinik = veritabani.Klinikler.FirstOrDefault(x => x.Id == doktor.DoktorKlinikId);
                if (secilenKlinik == null)
                {
                    secilenKlinik = new()
                    {
                        KlinikAdi = ""
                    };
                }
                maskedTextBox1.Text = doktor.TC;
                textBox1.Text = doktor.Sifre;
                textBox2.Text = doktor.DoktorAdi;
                textBox3.Text = doktor.DoktorSoyadi;
                textBox4.Text = doktor.KullaniciAdi;
                textBox5.Text = doktor.DoktorEmail;
                richTextBox1.Text = doktor.DoktorAdres;
                maskedTextBox2.Text = doktor.DoktorTel;
                comboBox1.Text = secilenKlinik.KlinikAdi ?? "";

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var doktor = veritabani.Doktorlar.FirstOrDefault(x => x.TC == maskedTextBox1.Text);
            if (doktor is null)
            {
                MessageBox.Show("böyle bir tc'ye sahip doktor yoktur");
                return;
            }
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Doktor eklerken bir klinik seçiniz");
                return;
            }


            var secilenKlinik = veritabani.Klinikler.FirstOrDefault(x => x.KlinikAdi == comboBox1.Text);

            if (secilenKlinik == null)
            {
                MessageBox.Show("Böyle bir klinik mevcut değil");
                return;
            }

            doktor.Sifre = textBox1.Text;
            doktor.DoktorAdi = textBox2.Text;
            doktor.KullaniciAdi = textBox4.Text;
            doktor.DoktorEmail = textBox5.Text;
            doktor.DoktorAdres = richTextBox1.Text;
            doktor.DoktorTel = maskedTextBox2.Text;
            doktor.DoktorKlinikId = secilenKlinik.Id;

            veritabani.Doktorlar.Update(doktor);
            veritabani.SaveChanges();


            MessageBox.Show("başarı bir şekilde doktor güncellendi.");
            DataGridYenile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormTemizle();
            MessageBox.Show("Form başarıyla temizlenmiştir.");
        }
    }
}
