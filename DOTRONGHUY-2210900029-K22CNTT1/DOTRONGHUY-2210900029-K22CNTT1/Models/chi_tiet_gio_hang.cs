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
    
    public partial class chi_tiet_gio_hang
    {
        public int ma_gio_hang { get; set; }
        public int ma_xe { get; set; }
        public Nullable<int> so_luong { get; set; }
        public string ten_xe { get; set; }
        public string hang_xe { get; set; }
        public string anh { get; set; }
        public Nullable<decimal> gia_ban { get; set; }
    
        public virtual gio_hang gio_hang { get; set; }
        public virtual danh_muc_xe_hoi danh_muc_xe_hoi { get; set; }
    }
}
