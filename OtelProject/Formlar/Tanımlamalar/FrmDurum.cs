using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//Db ile formu bağla
using OtelProject.Entity;

namespace OtelProject.Formlar.Tanımlamalar
{
    public partial class FrmDurum : Form
    {
        public FrmDurum()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();

        private void FrmDurum_Load(object sender, EventArgs e)
        {
            //Durum tablosundaki istediğimiz sütunları belirleme
            //////////
            //var durumlar = (from x in db.TblDurum
            //                select new
            //                {
            //                    x.DurumID,
            //                    x.DurumAd
            //                });
            //gridControl1.DataSource = durumlar.ToList();

            db.TblDurum.Load();
            bindingSource1.DataSource = db.TblDurum.Local;
        }

        //gridview üzerinden yapılan işlemi kayıt etme
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            //hata yakalamak için try catch kullanılır
            //karakter sayısı aşılırsa hata mesajı pencere olarak belirtilir
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lütfen değerleri kontrol edip yeniden giriş yapın !", " Uyarı ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void durumuSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
