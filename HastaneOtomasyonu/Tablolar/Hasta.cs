using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonu.Tablolar
{
    public class Hasta
    {
        [Key]
        public string TC { get; set; }
        public string HastaAdi { get; set; }
        public string HastaSoyadi { get; set; }
        public string KanGrubu { get; set; }
        public string HastaCinsiyeti { get; set; }
        public string HastaDogumYeri { get; set; }
        public string HastaDogumTarihi { get; set; }
        public string HastaBabaAdi { get; set; }
        public string HastaAnneAdi { get; set; }
        public string HastaCepTel { get; set; }
        public string HastaMail { get; set; }
        public string Adres { get; set; }
        public string HastaParola { get; set; }
        public string HastaKullaniciAdi { get; set; }
        public string ProfilResmi { get; set; }
    }
}
