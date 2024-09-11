using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyonu
{
    public partial class SekreterRandevular : Form
    {
        Veritabani veritabani;
        public SekreterRandevular()
        {
            veritabani = new Veritabani();
            InitializeComponent();
        }

        private void SekreterRandevular_Load(object sender, EventArgs e)
        {
            var randevular = veritabani.Randevular.ToList();
            dataGridView1.DataSource = randevular;
        }
    }
}
