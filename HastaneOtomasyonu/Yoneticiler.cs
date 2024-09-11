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
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonu
{
    public partial class Yoneticiler : Form
    {
        Veritabani veritabani;
        public Yoneticiler()
        {
            veritabani = new Veritabani();
            InitializeComponent();
        }

        void gridyenile()
        {
            var yoneticiler = veritabani.Yoneticiler.AsNoTracking().ToList();
            dataGridView1.DataSource = yoneticiler;
        }

        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void Yoneticiler_Load(object sender, EventArgs e)
        {
            gridyenile();

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            textBox6.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Tablolar.Yonetici yonetici = new Tablolar.Yonetici()
            {
                YoneticiAdi = textBox3.Text ?? "",
                YoneticiSoyadi = textBox4.Text ?? "",
                YoneticiKullaniciAdi = textBox2.Text ?? "",
                YoneticiSifre = textBox5.Text ?? "",
                YoneticiMail = textBox6.Text ?? ""
            };

            if (string.IsNullOrEmpty(yonetici.YoneticiKullaniciAdi))
            {
                MessageBox.Show("Lütfen bir kullanıcı adı giriniz");
                return;
            }

            if (string.IsNullOrEmpty(yonetici.YoneticiSifre))
            {
                MessageBox.Show("Lütfen bir şifre giriniz");
                return;
            }

            veritabani.Yoneticiler.Add(yonetici);
            veritabani.SaveChanges();
            textBox1.Text = yonetici.Id.ToString();
            gridyenile();
            temizle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var yoneticiId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            if (yoneticiId is null)
            {
                MessageBox.Show("tablodan lütfen yönetici seçiniz");
                return;
            }

            var yonetici = veritabani.Yoneticiler.FirstOrDefault(x => x.Id == Convert.ToInt16(yoneticiId));
            if (yonetici is null)
            {
                MessageBox.Show("silmek istediğiniz yönetici veritabanında bulunamadı");
                gridyenile();
                return;
            }

            veritabani.Yoneticiler.Remove(yonetici);
            veritabani.SaveChanges();
            MessageBox.Show("Başarıyla silinmiştir.");
            temizle();
            gridyenile();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var yoneticiId = textBox1.Text;
            if (string.IsNullOrEmpty(yoneticiId))
            {
                MessageBox.Show("tablodan lütfen yönetici seçiniz");
                return;
            }
            var yonetici = veritabani.Yoneticiler.FirstOrDefault(x => x.Id == Convert.ToInt16(yoneticiId));

            yonetici.YoneticiKullaniciAdi = textBox2.Text;
            yonetici.YoneticiSifre = textBox5.Text;
            yonetici.YoneticiMail = textBox6.Text;
            yonetici.YoneticiAdi = textBox3.Text;
            yonetici.YoneticiSoyadi = textBox4.Text;

            veritabani.Yoneticiler.Update(yonetici);
            veritabani.SaveChanges();

            gridyenile();
            MessageBox.Show("başarıyla güncellendi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
