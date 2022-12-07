using OtelProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject.Formlar.Grafikler
{
    public partial class FrmUrunStokGrafigi : Form
    {
        public FrmUrunStokGrafigi()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();
        private void FrmUrunStokGrafigi_Load(object sender, EventArgs e)
        {
            //Urun-Stok Grafiği
            var urunler = db.TblUrun.ToList();
            foreach (var x in urunler)
            {
                chartControl1.Series["Urun-Stok"].Points.AddPoint(x.UrunAd, double.Parse(x.Toplam.ToString()));
            }
        }
    }
}
