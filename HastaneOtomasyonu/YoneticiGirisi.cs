


namespace HastaneOtomasyonu
{
    public partial class YoneticiGirisi : Form
    {

        Veritabani veritabani = new Veritabani();
        public YoneticiGirisi()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var yoneticiKadi = textBox1.Text;
            var yoneticiSifre = textBox2.Text;

            var yonetici = veritabani.Yoneticiler.Where(x => x.YoneticiKullaniciAdi == yoneticiKadi && x.YoneticiSifre == yoneticiSifre).FirstOrDefault();
            if (yonetici is not null)
            {
                MessageBox.Show("Başarıyla giriş yaptınız yönetici paneline yönlendiriliyorsunuz.");
                Yonetici yoneticiPaneliForm = new Yonetici();
                this.Hide();
                yoneticiPaneliForm.Show();
            }
            else
            {

                MessageBox.Show("kullanıcı adı veya şifre yanlış");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GirisEkrani giris = new GirisEkrani();
            giris.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YoneticiSifremiUnuttum yoneticiSifremiUnuttum = new YoneticiSifremiUnuttum();
            yoneticiSifremiUnuttum.Show();
            this.Hide();
        }
    }
}
