using System.ComponentModel.DataAnnotations;

namespace DOTRONGHUY_2210900029_K22CNTT1.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Tên người dùng")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Tài khoản")]
        public string tai_khoan { get; set; }

        [Display(Name = "Mật khẩu")]
        public string mat_khau { get; set; }

        [Display(Name = "Trạng thái")]
        public int trang_thai { get; set; }
    }
}
