//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciWeb.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLOgrenciler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLOgrenciler()
        {
            this.TBLNotlar = new HashSet<TBLNotlar>();
        }
    
        public int OgrenciID { get; set; }
        //[Required(ErrorMessage = "��renci Ad� girilmesi zorunludur.")]
        public string OgrAd { get; set; }
        //[Required(ErrorMessage = "��renci Soyad� girilmesi zorunludur.")]
        public string OgrSoyad { get; set; }
        public string OgrFotograf { get; set; }
        public string OgrCinsiyet { get; set; }
        //[Required(ErrorMessage ="Kul�p tablosuna g�re kul�p bilgisini giriniz")]
        public Nullable<byte> OgrKulup { get; set; }
    
        public virtual TBLKulupler TBLKulupler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLNotlar> TBLNotlar { get; set; }
    }
}
