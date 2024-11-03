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
    }
}
