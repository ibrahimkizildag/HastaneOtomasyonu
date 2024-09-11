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
    public partial class HastaRandevularım : Form
    {
        Veritabani veritabani = new Veritabani();
        Hasta _hasta;
        Randevu randevu = new Randevu();
        public HastaRandevularım(Hasta hasta)
        {
            InitializeComponent();
            _hasta = hasta;
        }

        private void HastaRandevularım_Load(object sender, EventArgs e)
        {
            Yenile();
        }

        private void Yenile()
        {
            dataGridView1.DataSource = veritabani.Randevular.Where(x => x.RandevuTC == _hasta.TC && x.RandevuTarih.Date >= DateTime.Now.Date).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            randevu = veritabani.Randevular.Where(x => x.Id == id).FirstOrDefault();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var randevuId = Convert.ToInt16(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var randevu = veritabani.Randevular.Where(x => x.Id == randevuId).FirstOrDefault();

                if (randevu is null)
                {
                    MessageBox.Show("böyle bir randevu bulunamadı");
                    Yenile();
                }
                else
                {
                    veritabani.Randevular.Remove(randevu);
                    veritabani.SaveChanges();
                    MessageBox.Show("Randevu Başarıyla İptal Edildi.");
                    Yenile();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("bir hata oluştu!");
            }
        }
    }
}
