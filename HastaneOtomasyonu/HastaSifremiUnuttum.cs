using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace HastaneOtomasyonu
{
    public partial class HastaSifremiUnuttum : Form
    {
        Veritabani veritabani = new Veritabani();
        public HastaSifremiUnuttum()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            var hasta = veritabani.Hastalar.Where(x => x.HastaMail == textBox1.Text).FirstOrDefault();
            if (hasta != null)
            {
                MailSender.Send(textBox1.Text, "Şifreniz => " + hasta.HastaParola);
                this.Close();
            }
            else
            {
                MessageBox.Show("bu mail kayıtlı değil");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HastaGirisi hastaGirisi = new HastaGirisi();
            hastaGirisi.Show();
            this.Hide();
        }
    }
}
