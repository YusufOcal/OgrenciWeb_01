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
    
    public partial class TBLKulupler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLKulupler()
        {
            this.TBLOgrenciler = new HashSet<TBLOgrenciler>();
        }
    
        public byte KulupID { get; set; }
        public string KulupAd { get; set; }
        public Nullable<short> KulupKontenjan { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLOgrenciler> TBLOgrenciler { get; set; }
    }
}
