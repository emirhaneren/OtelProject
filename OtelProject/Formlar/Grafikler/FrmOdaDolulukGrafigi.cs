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
    public partial class FrmOdaDolulukGrafigi : Form
    {
        public FrmOdaDolulukGrafigi()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();
        private void FrmOdaDolulukGrafigi_Load(object sender, EventArgs e)
        {
            //Oda Doluluk Grafiği
            var durumlar = db.OdaDurum();
            foreach (var x in durumlar)
            {
                chartControl1.Series["Odalar"].Points.AddPoint(x.DurumAd, double.Parse(x.Sayı.ToString()));
            }
        }
    }
}
