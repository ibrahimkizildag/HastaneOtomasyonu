using Microsoft.EntityFrameworkCore;

namespace HastaneOtomasyonu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Veritabani veritabani = new Veritabani();
            veritabani.Database.EnsureCreated();
            veritabani.Database.Migrate();

ApplicationConfiguration.Initialize();
            Application.Run(new GirisEkrani());
        }
    }
}