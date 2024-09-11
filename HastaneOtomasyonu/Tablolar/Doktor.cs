using System.ComponentModel.DataAnnotations;

namespace HastaneOtomasyonu.Tablolar
{
    public class Doktor
    {
        [Key]
        public int Id { get; set; }
        public string TC { get; set; }
        public string? ProfilResmi { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string? DoktorAdi { get; set; }
        public string? DoktorSoyadi { get; set; }
        public string? DoktorTel { get; set; }
        public string? DoktorAdres { get; set; }
        public string DoktorEmail { get; set; }
        public int? DoktorKlinikId { get; set; }

        public Klinik DoktorKlinik { get; set; }
    }
}
