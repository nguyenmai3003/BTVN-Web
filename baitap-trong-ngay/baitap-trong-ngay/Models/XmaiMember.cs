using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace baitap_trong_ngay.Models
{
    /// <summary>
    /// Model class Member
    /// 
    /// Author: Xuan Mai 
    /// </summary>
    public class XmaiMember
    {
        public int Id { get; set; }
        [DisplayName(" Taì khoản")]
        [Required(ErrorMessage = "Tên tài khoản không được để trống.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tên tài khoản phải từ 3 đến 20 ký tự.")]
        public string XmaiUsername { get; set; }
        [DisplayName(" Mật khẩu")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 100 ký tự.")]
        public string XmaiPassword { get; set; }
        [DisplayName(" Email")]
        [Required(ErrorMessage = "Email không được để trống.")]
        [DataType(DataType.EmailAddress)]
        public string XmaiEmail { get; set; }
        [DisplayName(" Điện thoại")]
        [Required(ErrorMessage = "bạn chưa nhập số điện thoại.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số.")]
        public string XmaiPhone { get; set; }
        [DisplayName(" Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime XmaiBirthDate { get; set; }
    }
}
