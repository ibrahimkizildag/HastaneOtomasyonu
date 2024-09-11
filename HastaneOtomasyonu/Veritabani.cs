using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonu
{
    public class Veritabani:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=77.92.151.188;Initial Catalog=projeDb;User ID=sa;Password=iexKLW647;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<Tablolar.Doktor> Doktorlar { get; set; }
        public DbSet<Tablolar.Hasta> Hastalar { get; set; }
        public DbSet<Tablolar.Klinik> Klinikler { get; set; }
        public DbSet<Tablolar.Randevu> Randevular { get; set; }
        public DbSet<Tablolar.Yonetici> Yoneticiler { get; set; }
        public DbSet<Tablolar.Sekreter> Sekreterler { get; set; }
        public DbSet<Tablolar.Duyuru> Duyurular { get; set; }
        public DbSet<Tablolar.HastaIletisim> HastaIletisimler { get; set; }
    }
}
