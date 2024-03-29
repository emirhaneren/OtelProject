﻿using OtelProject.Entity;
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
    public partial class FrmBirim : Form
    {
        public FrmBirim()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();

        private void FrmBirim_Load(object sender, EventArgs e)
        {
            db.TblBirim.Load();
            bindingSource1.DataSource = db.TblBirim.Local;

            //repositoryLookUpEdit ile bağlanan değerleri gösterme
            repositoryItemLookUpEditDurum.DataSource=(from x in db.TblDurum select new { x.DurumID,x.DurumAd }).ToList();
        }

        //Events -> Cell Value Change  değişiklikleri kaydetmemizi sağlar 
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }
    }
}
