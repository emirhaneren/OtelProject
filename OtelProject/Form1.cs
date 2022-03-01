using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        //DurumTanımları
        private void BtnDurumTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Butonu form ile bağlama
            Formlar.Tanımlamalar.FrmDurum fr = new Formlar.Tanımlamalar.FrmDurum();
            fr.Show();
        }

        //BirimTanımları
        private void BtnBirimTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Butonu form ile bağlama
            Formlar.Tanımlamalar.FrmBirim fr = new Formlar.Tanımlamalar.FrmBirim();
            fr.Show();
        }

        //Departman Tanımları
        private void BtnDepartmanTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Butonu form ile bağlama
            Formlar.Tanımlamalar.FrmDepartman fr = new Formlar.Tanımlamalar.FrmDepartman();
            fr.Show();
        }

        //Görev Tanımları 
        private void BtnGorevTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmGorev fr = new Formlar.Tanımlamalar.FrmGorev();
            fr.Show();
        }

        //Kasa Tanımları
        private void BtnKasaTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKasa fr = new Formlar.Tanımlamalar.FrmKasa();
            fr.Show();
        }

        //Kur Tanımları
        private void BtnKurTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKur fr = new Formlar.Tanımlamalar.FrmKur();
            fr.Show();
        }

        //Oda Tanımları
        private void BtnOdaTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmOda fr = new Formlar.Tanımlamalar.FrmOda();
            fr.Show();
        }

        //Telefon Tanımları
        private void BtnTelefonTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmTelefon fr = new Formlar.Tanımlamalar.FrmTelefon();
            fr.Show();
        }

        //Ulke Tanımları
        private void BtnUlkeTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUlke fr = new Formlar.Tanımlamalar.FrmUlke();
            fr.Show();
        }

        //Grup Tanımları
        private void BtnUrunGrupTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUrunGrup fr = new Formlar.Tanımlamalar.FrmUrunGrup();
            fr.Show();
        }

        //Personel Kartı
        private void BtnPersonelKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Personel.FrmPersonelKarti fr = new Formlar.Personel.FrmPersonelKarti();
            fr.Show();
        }
    }
}
