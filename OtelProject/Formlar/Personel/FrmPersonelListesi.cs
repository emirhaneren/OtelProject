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

namespace OtelProject.Formlar.Personel
{
    public partial class FrmPersonelListesi : Form
    {
        public FrmPersonelListesi()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();

        //istenilen veriler
        private void FrmPersonelListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblPersonel
                                       select new
                                       {
                                           x.PersonelID,
                                           x.AdSoyad,
                                           x.TC,
                                           x.Telefon,
                                           x.Mail,
                                           x.TblDepartman.DepartmanAd,
                                           x.TblGorev.GorevAdı,
                                           x.TblDurum.DurumAd
                                       }).ToList(); 
        }

        //formlar arası veri taşıma, Mdi ile listeleme
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            Formlar.Personel.FrmPersonelKarti fr = new FrmPersonelKarti();
            //odaklanılan satırdaki değei al
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("PersonelID").ToString());
            fr.Show();
         }
    }
}
