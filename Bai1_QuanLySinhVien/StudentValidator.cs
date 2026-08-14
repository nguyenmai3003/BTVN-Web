using System;
using System.Text.RegularExpressions;

namespace Bai1_QuanLySinhVien
{
    public class StudentValidator
    {
        
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        public static void ValidateStudent(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.HoTen))
                throw new Exception("Lỗi: Họ tên không được để trống.");

            if (student.DiemTB < 0 || student.DiemTB > 10)
                throw new Exception("Lỗi: Điểm trung bình phải nằm trong khoảng từ 0 đến 10.");

            if (!string.IsNullOrWhiteSpace(student.Email) && !IsValidEmail(student.Email))
                throw new Exception("Lỗi: Email không đúng định dạng (VD: abc@gmail.com).");
        }
    }
}