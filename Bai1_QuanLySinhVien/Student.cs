using System;

namespace Bai1_QuanLySinhVien
{
    public class Student
    {
      
        public static int TotalStudents { get; private set; } = 0;

        
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;

        
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }

        public string NganhHoc { get; set; } = string.Empty;
        public double DiemTB { get; set; }
        public string TrangThaiHocTap { get; set; } = string.Empty;

        
        public Student()
        {
            TotalStudents++; 
        }
    }
}