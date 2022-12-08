using DevExpress.XtraEditors;
using OtelProject.Entity;
using OtelProject.Repositories;
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
    public partial class FrmKasaCikisKarti : Form
    {
        public FrmKasaCikisKarti()
        {
            InitializeComponent();
        }
        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();
        //repo
        Repository<TblKasaCikisHareketi> repo = new Repository<TblKasaCikisHareketi>();
        TblKasaCikisHareketi t = new TblKasaCikisHareketi();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.Aciklama = TxtAciklama.Text;
            t.Tarih = DateTime.Parse(dateEdit1.Text);
            t.Tutar = decimal.Parse(txtToplam.Text);

            repo.TAdd(t);
            XtraMessageBox.Show("Çıkış Hareketi Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
