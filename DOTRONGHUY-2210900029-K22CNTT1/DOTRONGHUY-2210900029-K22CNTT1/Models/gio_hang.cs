//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DOTRONGHUY_2210900029_K22CNTT1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class gio_hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gio_hang()
        {
            this.chi_tiet_gio_hang = new HashSet<chi_tiet_gio_hang>();
        }
    
        public int ma_gio_hang { get; set; }
        public Nullable<int> ma_kh { get; set; }
        public Nullable<System.DateTime> ngay_tao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chi_tiet_gio_hang> chi_tiet_gio_hang { get; set; }
        public virtual khach_hang khach_hang { get; set; }
    }
}
