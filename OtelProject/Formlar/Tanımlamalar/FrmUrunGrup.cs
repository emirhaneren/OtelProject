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
    public partial class FrmUrunGrup : Form
    {
        public FrmUrunGrup()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunGrup_Load(object sender, EventArgs e)
        {
            db.TblUrunGrup.Load();
            bindingSource1.DataSource = db.TblUrunGrup.Local;

            //repositoryLookUpEdit ile bağlanan değerleri gösterme (Durum)
            repositoryItemLookUpEditDurum.DataSource = (from x in db.TblDurum select new { x.DurumID, x.DurumAd }).ToList();
        }

        //Sağ klik menü
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
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
    }
}
