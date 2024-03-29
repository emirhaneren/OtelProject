﻿using OtelProject.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject.Formlar.Rezervasyon
{
    public partial class FrmGelecekRezervasyon : Form
    {
        public FrmGelecekRezervasyon()
        {
            InitializeComponent();
        }

        //DB
        DbOtelEntities db = new DbOtelEntities();

        private void FrmGelecekRezervasyon_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblRezervasyon
                                       select new
                                       {
                                           x.RezervasyonID,
                                           x.TblMisafir.AdSoyad,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Kisi,
                                           x.TblOda.OdaNo,
                                           x.Telefon,
                                           x.TblDurum.DurumAd,
                                       }).Where(y => y.DurumAd == "Rezervasyon Yapıldı").ToList();
        }
    }
}
