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
using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonu
{
    public partial class DoktorSifremiUnuttum : Form
    {
        Veritabani veritabani = new Veritabani();
        public DoktorSifremiUnuttum()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var doktor = veritabani.Doktorlar.Where(x => x.DoktorEmail == textBox1.Text).FirstOrDefault();
            if (doktor != null)
            {
                MailSender.Send(textBox1.Text, "Şifreniz => " + doktor.Sifre);
                this.Close();
            }
            else
            {
                MessageBox.Show("bu mail kayıtlı değil");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DoktorGirisi doktorGirisi = new DoktorGirisi();
            doktorGirisi.Show();
            this.Hide();
        }
    }
}
