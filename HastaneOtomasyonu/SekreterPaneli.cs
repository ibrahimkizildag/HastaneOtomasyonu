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
    public partial class SekreterPaneli : Form
    {
        Veritabani veritabani;
        int? secilenDuyuruId;
        public SekreterPaneli()
        {
            veritabani = new Veritabani();
            InitializeComponent();
        }
        public void DataGridYenile()
        {
            dataGridView1.DataSource = veritabani.Doktorlar.ToList();
            dataGridView2.DataSource = veritabani.Klinikler.ToList();
            dataGridView3.DataSource = veritabani.Duyurular.ToList();
        }
        private void SekreterPaneli_Load(object sender, EventArgs e)
        {
            DataGridYenile();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var duyuruIcerigi = richTextBox1.Text;
            if (string.IsNullOrEmpty(duyuruIcerigi))
            {
                MessageBox.Show("lütfen bir duyuru içeriği giriniz");
                return;
            }

            Duyuru duyuru = new Duyuru()
            {
                DuyuruIcerigi = duyuruIcerigi
            };

            veritabani.Duyurular.Add(duyuru);
            veritabani.SaveChanges();
            MessageBox.Show("başarıyla duyuru eklendi");

            DataGridYenile();
        }

        public void FormTemizle()
        {
            richTextBox1.Text = "";
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenDuyuruId = Convert.ToInt16(dataGridView3.CurrentRow.Cells[0].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            secilenDuyuruId = Convert.ToInt16(dataGridView3.CurrentRow.Cells[0].Value.ToString());
            if (secilenDuyuruId == null)
            {
                MessageBox.Show("Lütfen duyuru seçiniz");
                DataGridYenile();
                return;
            }
            var duyuru = veritabani.Duyurular.FirstOrDefault(x => x.Id == secilenDuyuruId);
            if (duyuru is null)
            {
                MessageBox.Show("Lütfen duyuru seçiniz");
                DataGridYenile();
                return;
            }
            veritabani.Duyurular.Remove(duyuru);
            veritabani.SaveChanges();

            MessageBox.Show("başarıyla silindi duyuru");
            DataGridYenile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SekreterDuyurular sekreterduyuru = new SekreterDuyurular();
            sekreterduyuru.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SekreterRandevular sekreterrandevu = new SekreterRandevular();
            sekreterrandevu.Show();
        }
    }
}
