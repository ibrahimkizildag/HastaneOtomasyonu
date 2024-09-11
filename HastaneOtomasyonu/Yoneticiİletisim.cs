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
    public partial class Yoneticiİletisim : Form
    {
        Veritabani veritabani;
        public Yoneticiİletisim()
        {
            veritabani = new Veritabani();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var hastaIletisimId = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            if (hastaIletisimId == null)
            {
                MessageBox.Show("seçtiğiniz bir iletişim yok");
            }

            var hastaIletisim = veritabani.HastaIletisimler.FirstOrDefault(x => x.Id == Convert.ToInt16(hastaIletisimId));
            if (hastaIletisim == null)
            {
                MessageBox.Show("böyle bir hasta iletişim yok");
                return;
            }

            hastaIletisim.GeriDonus = richTextBox2.Text;

            veritabani.HastaIletisimler.Update(hastaIletisim);
            veritabani.SaveChanges();
            MessageBox.Show("başarıyla geri dönüş yaptınız.");
            DataGridYenile();
        }
        public void DataGridYenile()
        {
            var hastaIletisimler = veritabani.HastaIletisimler.ToList();
            dataGridView1.DataSource = hastaIletisimler;
        }
        private void Yoneticiİletisim_Load(object sender, EventArgs e)
        {
            DataGridYenile();
        }
    }
}
