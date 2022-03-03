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

namespace OtelProject.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();

        //fprmlar arası veri taşıma
        public int id;

        //repo nesnesi
        Repository<TblPersonel> repo = new Repository<TblPersonel>();

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        //lookup editleri bağlama
        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            this.Text = id.ToString();
            
            //personel listesinde çift tıklayınca personel kartının dolu gelmesi
            if (id != 0)
            {
                var personel = repo.Find(x => x.PersonelID == id);
                TxtAdSoyad.Text = personel.AdSoyad;
                TxtTc.Text = personel.TC;
                TxtAdres.Text = personel.Adres;
                TxtTelefon.Text = personel.Telefon;
                TxtMail.Text = personel.Mail;
                dateEditGiris.Text = personel.IseGirisTarihi.ToString();
                dateEditCikis.Text = personel.IstenCikisTarihi.ToString();
                TxtAciklama.Text = personel.Aciklama;
                TxtSifre.Text = personel.Sifre;
                pictureEditKimlikOn.Image = Image.FromFile(personel.KimlikOn);
                pictureEditKimlikArka.Image = Image.FromFile(personel.KimlikArka);
                lookUpEditDepartman.EditValue = personel.Departman;
                lookUpEditGorev.EditValue = personel.Gorev;
                //labellara image konumları ataması
                labelControl15.Text = personel.KimlikOn;
                labelControl16.Text = personel.KimlikArka;
            }
           
            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman select new { x.DepartmanID, x.DepartmanAd }).ToList() ;
            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev select new {x.GorevID,x.GorevAdı}).ToList();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Önce repository classı çağırılır
        //tblpersonel parametre olarak gönderilir
        //t nesnesi oluşturulur
        //Kaydetme İşlemi
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            
            TblPersonel t = new TblPersonel();
            t.AdSoyad = TxtAdSoyad.Text;
            t.TC = TxtTc.Text;
            t.Adres = TxtAdres.Text;
            t.Telefon = TxtTelefon.Text;
            t.IseGirisTarihi =DateTime.Parse(dateEditGiris.Text);
            t.Departman = int.Parse (lookUpEditDepartman.EditValue.ToString());
            t.Gorev =int.Parse (lookUpEditGorev.EditValue.ToString());
            t.Aciklama = TxtAciklama.Text;
            t.Mail = TxtMail.Text;
            t.Sifre = TxtSifre.Text;
            t.Durum = 1;
            t.KimlikOn = pictureEditKimlikOn.GetLoadedImageLocation();
            t.KimlikArka = pictureEditKimlikArka.GetLoadedImageLocation();

            repo.TAdd(t);
            XtraMessageBox.Show("Personel başarılı bir şekilde sisteme kaydedildi");
        }

        private void lookUpEditGorev_EditValueChanged(object sender, EventArgs e)
        {

        }

        //Güncelleme İşlemi
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.PersonelID == id);
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTc.Text;
            deger.Adres = TxtAdres.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.IseGirisTarihi = DateTime.Parse(dateEditGiris.Text);
            deger.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            deger.Aciklama = TxtAciklama.Text;
            deger.Mail = TxtMail.Text;
            //deger.Durum = 1;
            deger.KimlikOn = labelControl15.Text;
            deger.KimlikArka = labelControl16.Text;
            deger.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            deger.Sifre = TxtSifre.Text;
            repo.TUpdate(deger);
            XtraMessageBox.Show("Personel Kartı Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //image sorunu için labellara dosya konumu ataması
        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            labelControl15.Text = pictureEditKimlikOn.GetLoadedImageLocation().ToString();

        }
        //image sorunu için labellara dosya konumu ataması
        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            labelControl16.Text = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }
    }
}
