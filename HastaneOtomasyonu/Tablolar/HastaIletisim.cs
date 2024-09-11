using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneOtomasyonu.Tablolar
{
    public class HastaIletisim
    {
        public int Id { get; set; }
        public string TC { get; set; }
        public string HastaAdi { get; set; }
        public string HastaSoyadi { get; set; }
        public string HastaEmail { get; set; }
        public string HastaIcerigi { get; set; }


        public string? GeriDonus { get; set; }
    }
}
