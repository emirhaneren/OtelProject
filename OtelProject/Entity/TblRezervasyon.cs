//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OtelProject.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblRezervasyon
    {
        public int RezervasyonID { get; set; }
        public Nullable<int> Misafir { get; set; }
        public Nullable<System.DateTime> GirisTarih { get; set; }
        public Nullable<System.DateTime> CikisTarih { get; set; }
        public string Kisi { get; set; }
        public Nullable<int> Oda { get; set; }
        public string RezervasyonAdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Aciklama { get; set; }
        public Nullable<int> Durum { get; set; }
        public Nullable<int> Kisi1 { get; set; }
        public Nullable<int> Kisi2 { get; set; }
        public Nullable<int> Kisi3 { get; set; }
        public Nullable<decimal> Toplam { get; set; }
        public Nullable<bool> KasayaAktar { get; set; }
    
        public virtual TblDurum TblDurum { get; set; }
        public virtual TblMisafir TblMisafir { get; set; }
        public virtual TblOda TblOda { get; set; }
    }
}
