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
    
    public partial class khach_hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khach_hang()
        {
            this.don_hang = new HashSet<don_hang>();
            this.gio_hang = new HashSet<gio_hang>();
        }
    
        public int ma_kh { get; set; }
        public string ho_ten { get; set; }
        public string tai_khoan { get; set; }
        public string mat_khau { get; set; }
        public string dia_chi { get; set; }
        public string dien_thoai { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> ngay_sinh { get; set; }
        public Nullable<System.DateTime> ngay_cap_nhat { get; set; }
        public Nullable<byte> gioi_tinh { get; set; }
        public Nullable<int> tich_diem { get; set; }
        public Nullable<byte> trang_thai { get; set; }
        public Nullable<bool> isAdmin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<don_hang> don_hang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<gio_hang> gio_hang { get; set; }
        public virtual user_auth user_auth { get; set; }
    }
}
