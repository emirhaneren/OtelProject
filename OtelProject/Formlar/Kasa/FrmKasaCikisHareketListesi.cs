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

namespace OtelProject.Formlar.Kasa
{
    public partial class FrmKasaCikisHareketListesi : Form
    {
        public FrmKasaCikisHareketListesi()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();
        private void FrmKasaCİkisHareketListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblKasaCikisHareketi
                                       select new
                                       {
                                           x.Aciklama,
                                           x.Tarih,
                                           x.Tutar
                                       }).ToList();
        }
    }
}
