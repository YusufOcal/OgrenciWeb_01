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
    
    public partial class TBLDersler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLDersler()
        {
            this.TBLNotlar = new HashSet<TBLNotlar>();
        }
    
        public byte DersID { get; set; }
        public string DersAd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLNotlar> TBLNotlar { get; set; }
    }
}
