﻿using DevExpress.XtraEditors;
using OtelProject.Entity;
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

namespace OtelProject.Formlar.Tanımlamalar
{
    public partial class FrmOda : Form
    {
        public FrmOda()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();

        private void FrmOda_Load(object sender, EventArgs e)
        {
            db.TblOda.Load();
            bindingSource1.DataSource = db.TblOda.Local;

            //repositoryLookUpEdit ile bağlanan değerleri gösterme (Durum)
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurum select new { x.DurumID, x.DurumAd }).ToList();
        }

        //Veri Ekleme
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Bilgiler kaydedilirken hata oluştu, kontrol edip tekrar deneyiniz");
            }
        }

        //Sağ klik menü
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }
    }
}
