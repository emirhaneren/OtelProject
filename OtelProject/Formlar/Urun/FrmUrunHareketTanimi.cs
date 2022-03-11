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

namespace OtelProject.Formlar.Urun
{
    public partial class FrmUrunHareketTanimi : Form
    {
        public FrmUrunHareketTanimi()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();
        
        //id
        public int id;

        //repo
        Repository<TblUrunHareket> repo = new Repository<TblUrunHareket>();
        TblUrunHareket t = new TblUrunHareket();

        private void FrmUrunHareketTanimi_Load(object sender, EventArgs e)
        {
            //id
            textId.Text = id.ToString();
            textId.Enabled = false;


            //Ürün Listesi
            lookUpEditUrun.Properties.DataSource = (from x in db.TblUrun select new { x.UrunID, x.UrunAd }).ToList();

            //verilerin kart alanına doldurulması
            if(id!=0)
            {
                var urun = repo.Find(x => x.HareketID == id);
                lookUpEditUrun.EditValue = urun.Urun;
                TxtMiktar.Text = urun.Miktar.ToString();
                TxtAciklama.Text = urun.Aciklama;
                comboBox1.Text = urun.HareketTuru;
                dateEdit1.Text = urun.Tarih.ToString();
            }
        }

        //Vazgeç Butonu
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Kaydet Butonu
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            t.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
            t.Tarih = DateTime.Parse(dateEdit1.Text);
            t.HareketTuru = comboBox1.Text;
            t.Miktar = decimal.Parse(TxtMiktar.Text);
            t.Aciklama = TxtAciklama.Text;

            repo.TAdd(t);
            XtraMessageBox.Show("Ürün Hareketi Listeye Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urun = repo.Find(x => x.HareketID == id);
            urun.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
            urun.Tarih = DateTime.Parse(dateEdit1.Text);
            urun.HareketTuru = comboBox1.Text;
            urun.Miktar = decimal.Parse(TxtMiktar.Text);
            urun.Aciklama = TxtAciklama.Text;

            repo.TUpdate(urun);
            XtraMessageBox.Show("Ürün Hareketi Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
