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

namespace OtelProject.Formlar.Admin
{
    public partial class FrmAdminListesi : Form
    {
        public FrmAdminListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmAdminListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TblAdmin.ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmSifreIslemleri fr = new FrmSifreIslemleri();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}
