using System;
using System.Collections.Generic;

namespace Bai1_QuanLySinhVien
{
    public class StudentConsoleView
    {
        public static void ShowList(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }

            Console.WriteLine(new string('-', 120));
            Console.WriteLine($"{"Mã SV",-10} | {"Họ tên",-20} | {"Ngày sinh",-12} | {"Giới tính",-10} | {"Điểm TB",-8} | {"Ngành học",-15} | {"Trạng thái",-15}");
            Console.WriteLine(new string('-', 120));

            foreach (var s in students)
            {
                Console.WriteLine($"{s.MaSV,-10} | {s.HoTen,-20} | {s.NgaySinh:dd/MM/yyyy} | {s.GioiTinh,-10} | {s.DiemTB,-8:F2} | {s.NganhHoc,-15} | {s.TrangThaiHocTap,-15}");
            }
            Console.WriteLine(new string('-', 120));
        }

        public static void PrintMessage(string msg, bool isError = false)
        {
            Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}