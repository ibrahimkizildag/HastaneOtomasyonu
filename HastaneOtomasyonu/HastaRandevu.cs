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
    public partial class HastaRandevu : Form
    {
        Veritabani veritabani = new Veritabani();
        Hasta _hasta;
        Randevu randevu = new Randevu();
        public HastaRandevu(Hasta hasta)
        {
            InitializeComponent();
            _hasta = hasta;
        }

        private void YenileRandevular(DataGridView dataGridView1, DataGridView dataGridView2)
        {
            try
            {
                var eski = veritabani.Randevular.Where(x => x.RandevuTC == _hasta.TC && x.RandevuTarih.Date < DateTime.Now.Date).ToList();
                var aktif = veritabani.Randevular.Where(x => x.RandevuTC == _hasta.TC && x.RandevuTarih.Date >= DateTime.Now.Date).ToList();
                dataGridView1.DataSource = aktif;
                dataGridView2.DataSource = eski;
            }
            catch (Exception)
            {

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var klinikID = veritabani.Klinikler.Where(x => x.KlinikAdi == comboBox1.Text).FirstOrDefault();
            randevu.RandevuKlinikId = klinikID.Id;
            try
            {
                var doktorlar = veritabani.Doktorlar.Where(x => x.DoktorKlinikId == klinikID.Id).ToList();
                comboBox2.Items.Clear();
                foreach (var item in doktorlar)
                {
                    comboBox2.Items.Add(item.DoktorAdi);
                }
                comboBox2.Enabled = true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void HastaRandevu_Load(object sender, EventArgs e)
        {

            DateTime date = DateTime.Now.AddDays(-1).Date;
            YenileRandevular(dataGridView1, dataGridView2);
            var klinikler = veritabani.Klinikler.ToList();
            comboBox1.Items.Clear();
            foreach (var item in klinikler)
            {
                comboBox1.Items.Add(item.KlinikAdi);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            var doktorID = veritabani.Doktorlar.Where(x => x.DoktorAdi == comboBox2.Text).FirstOrDefault();
            randevu.RandevuDoktorId = doktorID.Id;
            dateTimePicker1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaatAl(button1);
        }

        private void SaatAl(Button buton)
        {
            randevu.RandevuSaat = buton.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaatAl(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaatAl(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaatAl(button4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaatAl(button8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaatAl(button7);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaatAl(button6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaatAl(button5);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SaatAl(button12);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaatAl(button11);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaatAl(button10);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SaatAl(button9);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SaatAl(button16);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            SaatAl(button15);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SaatAl(button14);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            SaatAl(button13);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SaatAl(button20);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            SaatAl(button19);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SaatAl(button18);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SaatAl(button17);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (randevu.RandevuSaat == null)
            {
                MessageBox.Show("Saat seçmediniz!");
            }
            else
            {
                randevu.RandevuTC = _hasta.TC;
                randevu.Sikayet = richTextBox1.Text;
                string onayMetni = "Klinik : " + comboBox1.Text + "\nDoktor : " + comboBox2.Text + "\nTC: " + randevu.RandevuTC + "\nTarih: " + randevu.RandevuTarih + "\nSaat: " + randevu.RandevuSaat + "\nŞikayet: " + randevu.Sikayet;
                var randevuOnay = MessageBox.Show(onayMetni, "onaylıyor musunuz?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (randevuOnay == DialogResult.Yes)
                {
                    veritabani.Randevular.Add(randevu);
                    veritabani.SaveChanges();
                    YenileRandevular(dataGridView1, dataGridView2);
                    MessageBox.Show("Randevunuz oluşuruldu!");
                    SayfaTemizle();

                }
            }
        }

        private void SayfaTemizle()
        {
            dateTimePicker1.CustomFormat = "Tarih Seçiniz";
            dateTimePicker1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox2.Text = "Doktor Seçiniz";
            comboBox1.Text = "Klinik Seçiniz";
            richTextBox1.Clear();
            comboBox3.Enabled = false;
            richTextBox1.Enabled = false;
            groupBox3.Visible = false;
            groupBox3.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.CustomFormat = "dd.MM.yyyy";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.Text = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                comboBox3.Enabled = true;
                richTextBox1.Enabled = true;
                groupBox3.Visible = true;
                groupBox3.Enabled = true;
                randevu.RandevuTarih = dateTimePicker1.Value.Date;
                var doktor = veritabani.Randevular.Where(x => x.RandevuDoktorId == randevu.RandevuDoktorId && x.RandevuTarih.Date == dateTimePicker1.Value.Date).ToList();
                List<string> doluSaatler = new List<string>();
                foreach (var item in doktor)
                {
                    doluSaatler.Add(item.RandevuSaat);
                }
                for (int i = 1; i <= 20; i++)
                {
                    string buttonName = "button" + i;
                    Button currentButton = Controls.Find(buttonName, true).FirstOrDefault() as Button;

                    if (currentButton != null)
                    {
                        if (doluSaatler.Contains(currentButton.Text))
                        {
                            currentButton.BackColor = Color.Red;
                            currentButton.Enabled = false;
                        }
                        else
                        {
                            currentButton.BackColor = Color.Green;
                            currentButton.Enabled = true;
                        }
                    }
                }

                button21.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("hata");
            }

        }
    }
}
