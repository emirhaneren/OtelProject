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

namespace OtelProject.Formlar.Misafir
{
    public partial class FrmMisafirListesi : Form
    {
        public FrmMisafirListesi()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();

        private void FrmMisafirListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblMisafir
                                       select new
                                       {
                                           x.MisafirID,
                                           x.AdSoyad,
                                           x.TC,
                                           x.Telefon,
                                           x.Mail,
                                           x.Ulke,
                                           //x.Sehir,
                                           //x.Ilce
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmMisafirKarti fr = new FrmMisafirKarti();
            //odaklanılan satırdaki değei al
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("MisafirID").ToString());
            fr.Show();
        }
    }
}
