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

namespace OtelProject.Formlar.Misafir
{
    public partial class FrmMisafirKarti : Form
    {
        public FrmMisafirKarti()
        {
            InitializeComponent();
        }

        //Database ile Formu bağla
        DbOtelEntities db = new DbOtelEntities();

        public int id;
        public string resim1, resim2;

        Repository<TblMisafir> repo = new Repository<TblMisafir>();
        TblMisafir t = new TblMisafir();

        private void FrmMisafirKarti_Load(object sender, EventArgs e)
        {
            try
            {
                //Güncelenecek kart bilgileri
                if (id != 0)
                {
                    var misafir = repo.Find(x => x.MisafirID == id);
                    TxtAdSoyad.Text = misafir.AdSoyad;
                    TxtTc.Text = misafir.TC;
                    TxtAdres.Text = misafir.Adres;
                    TxtTelefon.Text = misafir.Telefon;
                    TxtMail.Text = misafir.Mail;
                    TxtAciklama.Text = misafir.Aciklama;
                    lookUpEditSehir.EditValue = misafir.Sehir;
                    lookUpEditUlke.EditValue = misafir.Ulke;
                    lookUpEditIlce.EditValue = misafir.Ilce;

                    pictureEditKimlikOn.Image = Image.FromFile(misafir.KimlikFoto1);
                    pictureEditKimlikArka.Image = Image.FromFile(misafir.KimlikFoto2);

                    //labellara image konumları ataması
                    resim1 = misafir.KimlikFoto1;
                    resim2 = misafir.KimlikFoto2;

                }
            }
            catch (Exception)
            {

                XtraMessageBox.Show("Bir hata oluştu lütfen sütunları kontrol edin.","Hata",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
            //Ulke Listesi
            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlke select new { x.UlkeID, x.UlkeAd }).ToList();
            //Şehir Listesi,Anonymus Type
            lookUpEditSehir.Properties.DataSource = (from x in db.iller select new { ID = x.id, Şehir = x.sehir }).ToList();
        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            //Seçilen şehire göre ilçeleri getirme
            int secilen;
            secilen = int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditIlce.Properties.DataSource = (from x in db.ilceler select new { ID = x.id, İlçe = x.ilce, x.sehir }).Where(y => y.sehir == secilen).ToList();
        }

        //kimlik fotoğraflarını alma
        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            resim1 = pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            resim2 = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }

        //Vazgeç Butonu
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.MisafirID == id);
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTc.Text;
            deger.Mail = TxtMail.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Adres = TxtAdres.Text;
            deger.Aciklama = TxtAciklama.Text;
            deger.KimlikFoto1 = resim1;
            deger.KimlikFoto2 = resim2;
            deger.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
            deger.Sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
            deger.Ilce = int.Parse(lookUpEditIlce.EditValue.ToString());
            deger.Durum = 1;
            repo.TUpdate(deger);
            XtraMessageBox.Show("Misafir Kartı Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Yeni misafir kayıt
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(pictureEditKimlikArka.Image!=null && pictureEditKimlikOn.Image!=null)
            {
                //fluent validation ?
                t.AdSoyad = TxtAdSoyad.Text;
                t.TC = TxtTc.Text;
                t.Telefon = TxtTelefon.Text;
                t.Mail = TxtMail.Text;
                t.Adres = TxtAdres.Text;
                t.Aciklama = TxtAciklama.Text;
                t.Durum = 1;
                t.Sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
                t.Ilce = int.Parse(lookUpEditIlce.EditValue.ToString());
                t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
                t.KimlikFoto1 = resim1;
                t.KimlikFoto2 = resim2;

                repo.TAdd(t);
                XtraMessageBox.Show("Misafir sistme başarılı bir şekilde kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Lütfen bilgileri eksiksiz doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }
    }
}
