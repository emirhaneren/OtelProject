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

namespace OtelProject.Formlar.Admin
{
    public partial class FrmSifreIslemleri : Form
    {
        public int id;
        
        public FrmSifreIslemleri()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        Repository<TblAdmin> repo = new Repository<TblAdmin>();

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if(txtSifre1.Text==txtSifre2.Text)
            {
                TblAdmin t = new TblAdmin();
                t.Kullanici = txtKullanici.Text;
                t.Sifre = txtSifre1.Text;
                db.TblAdmin.Add(t);
                db.SaveChanges();
                XtraMessageBox.Show("Yeni Kullanıcı başarılı bir şekilde oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Şifreler uyuşmuyor lütfen yeniden deneyiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if(txtSifre1.Text==txtSifre2.Text)
            {
                var deger = repo.Find(x => x.ID == id);
                deger.Kullanici = txtKullanici.Text;
                deger.Sifre = txtSifre1.Text;
                deger.Rol = txtRol.Text;
                repo.TUpdate(deger);
                XtraMessageBox.Show("Kullanıcı bilgileri başarılı bir şekilde güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Lütfen bilgileri kontorl ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            FrmAdminListesi fr = new FrmAdminListesi();
            fr.Show();
            this.Hide();
        }
        private void FrmSifreIslemleri_Load(object sender, EventArgs e)
        {
            if(id!=0)
            {
                var admin = repo.Find(x => x.ID == id);
                txtKullanici.Text = admin.Kullanici;
                txtMevcutSifre.Text = admin.Sifre;
                txtRol.Text = admin.Rol;
            }
        }
    }
}
