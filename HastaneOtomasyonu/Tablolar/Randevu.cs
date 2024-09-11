namespace HastaneOtomasyonu.Tablolar
{
    public class Randevu
    {
        public int Id { get; set; }
        public string RandevuTC { get; set; }
        public DateTime RandevuTarih { get; set; }
        public string RandevuSaat { get; set; }
        public string Sikayet { get; set; }
        public int RandevuKlinikId { get; set; }
        public int RandevuDoktorId { get; set; }
    }
}
