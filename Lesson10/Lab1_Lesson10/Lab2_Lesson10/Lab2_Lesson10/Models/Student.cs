using System.ComponentModel.DataAnnotations;

namespace Lab2_Lesson10.Models;

public class Student
{
    private string? name;

    [Display(Name = "Mã sinh viên")]
    public int Id { get; set; }

    [Display(Name = "Họ tên")]
    [Required(ErrorMessage = "Vui lòng nhập họ tên.")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải từ 4 đến 100 ký tự.")]
    public string? Name
    {
        get => name;
        set => name = value?.Trim();
    }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Vui lòng nhập email.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    [RegularExpression(@"[A-Za-z0-9._%+-]+@[gG][mM][aA][iI][lL]\.[cC][oO][mM]",
        ErrorMessage = "Email phải đúng định dạng và có đuôi gmail.com.")]
    [StringLength(200, ErrorMessage = "Email không quá 200 ký tự.")]
    public string? Email { get; set; }

    [Display(Name = "Mật khẩu")]
    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 đến 100 ký tự.")]
    [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9\s]).+",
        ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, chữ số và ký tự đặc biệt.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Ngành học")]
    [Required(ErrorMessage = "Vui lòng chọn ngành học.")]
    [EnumDataType(typeof(Branch), ErrorMessage = "Ngành học không hợp lệ.")]
    public Branch? Branch { get; set; }

    [Display(Name = "Giới tính")]
    [Required(ErrorMessage = "Vui lòng chọn giới tính.")]
    [EnumDataType(typeof(Gender), ErrorMessage = "Giới tính không hợp lệ.")]
    public Gender? Gender { get; set; }

    [Display(Name = "Hệ chính quy")]
    public bool IsRegular { get; set; }

    [Display(Name = "Địa chỉ")]
    [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
    [StringLength(250, ErrorMessage = "Địa chỉ không quá 250 ký tự.")]
    [DataType(DataType.MultilineText)]
    public string? Address { get; set; }

    // Giữ tên DateOfBorth theo đề để thống nhất model và Razor.
    [Display(Name = "Ngày sinh")]
    [Required(ErrorMessage = "Vui lòng nhập ngày sinh.")]
    [Range(typeof(DateTime), "1/1/1963", "12/31/2005", ParseLimitsInInvariantCulture = true,
        ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005.")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBorth { get; set; }

    [Display(Name = "Điểm")]
    [Required(ErrorMessage = "Vui lòng nhập điểm.")]
    [Range(typeof(decimal), "0.0", "10.0", ParseLimitsInInvariantCulture = true,
        ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10.")]
    public decimal? Score { get; set; }

    [Display(Name = "Ảnh đại diện")]
    public string? AvatarPath { get; set; }
}
