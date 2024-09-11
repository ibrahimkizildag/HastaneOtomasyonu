using HastaneOtomasyonu.Tablolar;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HastaneOtomasyonu
{
    public partial class DoktorRandevu : Form
    {
        Veritabani veritabani = new Veritabani();
        Doktor _doktor;
        int id;
        public DoktorRandevu(Doktor doktor)
        {
            InitializeComponent();
            _doktor = doktor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var mail = veritabani.Hastalar.Where(x => x.TC == dataGridView1.CurrentRow.Cells[1].Value.ToString()).FirstOrDefault();
            MailSender.Send(mail.HastaMail, richTextBox2.Text);

            var randevu = veritabani.Randevular.Where(x => x.Id == id).FirstOrDefault();
            var updatedEntity = veritabani.Entry(randevu);
            updatedEntity.State = EntityState.Modified;
            veritabani.SaveChanges();
            dataGridView1.DataSource = veritabani.Randevular.Where(x => x.RandevuDoktorId == _doktor.Id).ToList();

            MessageBox.Show("başarılı bir şekilde teşhis konuldu");
        }

        private void DoktorRandevu_Load(object sender, EventArgs e)
        {
            Yenile();
        }

        private void Yenile()
        {
            dataGridView1.DataSource = veritabani.Randevular.Where(x => x.RandevuDoktorId == _doktor.Id).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var randevu = veritabani.Randevular.Where(x => x.Id == id).FirstOrDefault();
            var deletedEntity = veritabani.Entry(randevu);
            deletedEntity.State = EntityState.Deleted;
            veritabani.SaveChanges();
            Yenile();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
