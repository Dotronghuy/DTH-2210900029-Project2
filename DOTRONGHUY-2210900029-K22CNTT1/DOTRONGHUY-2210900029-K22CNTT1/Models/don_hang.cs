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
    
    public partial class don_hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public don_hang()
        {
            this.thanh_toan = new HashSet<thanh_toan>();
        }
    
        public int ma_dh { get; set; }
        public Nullable<int> ma_kh { get; set; }
        public Nullable<decimal> tong_tien { get; set; }
        public Nullable<System.DateTime> ngay_dat { get; set; }
        public Nullable<byte> trang_thai { get; set; }
    
        public virtual khach_hang khach_hang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thanh_toan> thanh_toan { get; set; }
    }
}
