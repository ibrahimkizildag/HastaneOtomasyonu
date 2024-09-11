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
    public partial class Hastaİletisim : Form
    {
        Veritabani veritabani;
        public Hastaİletisim()
        {
            veritabani = new Veritabani();
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            HastaIletisim hastaIletisim = new HastaIletisim()
            {
                TC = AppInfo.GirisYapanHastaTc,
                HastaAdi = textBox1.Text,
                HastaSoyadi = textBox2.Text,
                HastaEmail = textBox3.Text,
                HastaIcerigi = richTextBox1.Text,
            };

            veritabani.HastaIletisimler.Add(hastaIletisim);
            veritabani.SaveChanges();
            MessageBox.Show("başarıyla mesajınız gönderildi.");
            DataGridYenile();
        }

        public void DataGridYenile()
        {
            var hastaIletisimler = veritabani.HastaIletisimler.Where(x => x.TC == AppInfo.GirisYapanHastaTc).ToList();
            dataGridView1.DataSource = hastaIletisimler;
        }

        private void Hastaİletisim_Load(object sender, EventArgs e)
        {
            DataGridYenile();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var hastaIletisimId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var hastaIletisim = veritabani.HastaIletisimler.FirstOrDefault(x => x.Id == hastaIletisimId);
            if (hastaIletisim == null)
            {
                MessageBox.Show("böyle bir iletişim bulunamadı");
                DataGridYenile();
            }

            richTextBox2.Text = hastaIletisim.GeriDonus ?? "";
        }
    }
}
