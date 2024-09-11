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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HastaneOtomasyonu
{
    public partial class YoneticiPersoneller : Form
    {
        Veritabani veritabani;
        public YoneticiPersoneller()
        {
            veritabani = new Veritabani();
            InitializeComponent();
            DataGridYenile();
        }
        bool sec = true;

        private void button3_Click(object sender, EventArgs e)
        {

            if (sec == false)
            {
                var sekreter = veritabani.Sekreterler.FirstOrDefault(x => x.TC == maskedTextBox1.Text);
                if (sekreter is null)
                {
                    MessageBox.Show("böyle bir tc'ye sahip sekreter yoktur");
                    return;
                }


                sekreter.SekreterAdi = textBox1.Text;
                sekreter.SekreterSoyadi = textBox2.Text;
                sekreter.SekreterKullaniciAdi = textBox5.Text;
                sekreter.SekreterSifre = textBox4.Text;
                sekreter.SekreterMail = textBox3.Text;

                veritabani.Sekreterler.Update(sekreter);
                veritabani.SaveChanges();
                MessageBox.Show("Sekreter başarıyla güncellendi.");
            }
            else
            {

                var doktor = veritabani.Doktorlar.FirstOrDefault(x => x.TC == maskedTextBox1.Text);
                if (doktor is null)
                {
                    MessageBox.Show("böyle bir tc'ye sahip doktor yoktur");
                    return;
                }

                doktor.DoktorAdi = textBox1.Text;
                doktor.DoktorSoyadi = textBox2.Text;
                doktor.KullaniciAdi = textBox5.Text;
                doktor.Sifre = textBox4.Text;
                doktor.DoktorEmail = textBox3.Text;

                veritabani.Doktorlar.Update(doktor);
                veritabani.SaveChanges();


                MessageBox.Show("başarı bir şekilde doktor güncellendi.");
            }

            DataGridYenile();
        }

        private void YoneticiPersoneller_Load(object sender, EventArgs e)
        {


        }
        public void DataGridYenile()
        {
            // doktorların datagridi için
            var doktorlar = veritabani.Doktorlar.ToList();
            foreach (var item in doktorlar)
            {
                var klinik = veritabani.Klinikler.FirstOrDefault(x => x.Id == item.DoktorKlinikId);
                if (klinik != null)
                {
                    item.DoktorKlinik = klinik;
                }
                else
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

            //sekreterlerin datagridi için
            var sekreterler = veritabani.Sekreterler.ToList();
            dataGridView2.DataSource = sekreterler;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("lütfen bir tc kimlik numarası giriniz.");
            }

            if (sec == false)
            {
                var db = veritabani.Sekreterler.FirstOrDefault(x => x.TC == maskedTextBox1.Text);
                if (db != null)
                {
                    MessageBox.Show("böyle bir tc ye sahip kullanıcı zaten var");
                    return;
                }
                Sekreter sekreter = new Sekreter()
                {
                    TC = maskedTextBox1.Text,
                    SekreterAdi = textBox1.Text,
                    SekreterSoyadi = textBox2.Text,
                    SekreterMail = textBox3.Text,
                    SekreterKullaniciAdi = textBox5.Text,
                    SekreterSifre = textBox4.Text

                };
                veritabani.Sekreterler.Add(sekreter);
                MessageBox.Show("Sekreter başarıyla eklenmiştir");
            }
            else
            {
                var db = veritabani.Doktorlar.FirstOrDefault(x => x.TC == maskedTextBox1.Text);
                if (db != null)
                {
                    MessageBox.Show("böyle bir tc ye sahip kullanıcı zaten var");
                    return;
                }
                Doktor doktor = new Doktor()
                {
                    TC = maskedTextBox1.Text,
                    DoktorAdi = textBox1.Text,
                    DoktorSoyadi = textBox2.Text,
                    DoktorEmail = textBox3.Text,
                    KullaniciAdi = textBox5.Text,
                    Sifre = textBox4.Text
                };

                veritabani.Doktorlar.Add(doktor);
                MessageBox.Show("Doktor başarıyla eklenmiştir");

            }
            veritabani.SaveChanges();
            DataGridYenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelVeSekreterSecButonlari();
        }


        public void PersonelVeSekreterSecButonlari()
        {
            sec = !sec;
            button1.Enabled = !sec;
            button2.Enabled = sec;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonelVeSekreterSecButonlari();
            FormTemizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (sec)
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
                    maskedTextBox1.Text = doktor.TC;
                    textBox4.Text = doktor.Sifre;
                    textBox1.Text = doktor.DoktorAdi;
                    textBox2.Text = doktor.DoktorSoyadi;
                    textBox5.Text = doktor.KullaniciAdi;
                    textBox3.Text = doktor.DoktorEmail;
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sec == false)
            {
                var tcKimlik = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                var sekreter = veritabani.Sekreterler.FirstOrDefault(x => x.TC == tcKimlik);
                if (sekreter == null)
                {
                    MessageBox.Show("böyle bir sekreter bulunamadı");
                    DataGridYenile();
                }
                else
                {
                    maskedTextBox1.Text = sekreter.TC;
                    textBox4.Text = sekreter.SekreterSifre;
                    textBox1.Text = sekreter.SekreterAdi;
                    textBox2.Text = sekreter.SekreterSoyadi;
                    textBox5.Text = sekreter.SekreterKullaniciAdi;
                    textBox3.Text = sekreter.SekreterMail;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (sec == false)
            {
                var tcKimlik = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                if (string.IsNullOrEmpty(tcKimlik))
                {
                    MessageBox.Show("lütfen bir doktor veya sekreter seçiniz.");
                    return;
                }

                var sekreter = veritabani.Sekreterler.FirstOrDefault(x => x.TC == tcKimlik);
                if (sekreter == null)
                {
                    MessageBox.Show("böyle bir sekreter bulunamadı");
                    return;
                }
                veritabani.Sekreterler.Remove(sekreter);
                veritabani.SaveChanges();
                MessageBox.Show("Sekreter başarıyla silindi.");
            }
            else
            {
                var tcKimlik = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(tcKimlik))
                {
                    MessageBox.Show("lütfen bir doktor veya sekreter seçiniz.");
                    return;
                }

                var doktor = veritabani.Doktorlar.FirstOrDefault(x => x.TC == tcKimlik);
                if (doktor == null)
                {
                    MessageBox.Show("böyle bir doktor bulunamadı");
                    return;
                }
                veritabani.Doktorlar.Remove(doktor);
                veritabani.SaveChanges();
                MessageBox.Show("Sekreter başarıyla silindi.");
            }

            DataGridYenile();
        }

        public void FormTemizle()
        {

            maskedTextBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }
        private void button6_Click(object sender, EventArgs e)
        {
            FormTemizle();
        }
    }
}
