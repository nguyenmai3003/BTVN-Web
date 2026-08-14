using System;

namespace Bai1_QuanLySinhVien
{
    public class MenuManager
    {
        private StudentService _service = new StudentService();

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách");
                Console.WriteLine("3. Tìm sinh viên theo mã");
                Console.WriteLine("4. Hiển thị sinh viên điểm cao nhất");
                Console.WriteLine("5. Thống kê theo ngành học");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-5): ");

                string choice = Console.ReadLine() ?? "";

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddStudentUI();
                            break;
                        case "2":
                            StudentConsoleView.ShowList(_service.GetAll());
                            break;
                        case "3":
                            SearchStudentUI();
                            break;
                        case "4":
                            StudentConsoleView.ShowList(_service.GetTopScorers());
                            break;
                        case "5":
                            ShowStats();
                            break;
                        case "0":
                            return;
                        default:
                            StudentConsoleView.PrintMessage("Chức năng không hợp lệ!", true);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    StudentConsoleView.PrintMessage(ex.Message, true);
                }

                Console.WriteLine("Nhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }

        private void AddStudentUI()
        {
            Console.WriteLine("--- THÊM SINH VIÊN ---");
            Student s = new Student();

            Console.Write("Nhập Mã SV: "); s.MaSV = Console.ReadLine() ?? "";
            Console.Write("Nhập Họ tên: "); s.HoTen = Console.ReadLine() ?? "";
            Console.Write("Nhập Ngày sinh (yyyy-mm-dd): "); s.NgaySinh = DateTime.Parse(Console.ReadLine() ?? "2000-01-01");
            Console.Write("Nhập Giới tính: "); s.GioiTinh = Console.ReadLine() ?? "";
            Console.Write("Nhập Email: "); s.Email = Console.ReadLine();
            Console.Write("Nhập SĐT: "); s.SoDienThoai = Console.ReadLine();
            Console.Write("Nhập Ngành học: "); s.NganhHoc = Console.ReadLine() ?? "";
            Console.Write("Nhập Điểm TB: "); s.DiemTB = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhập Trạng thái: "); s.TrangThaiHocTap = Console.ReadLine() ?? "";

            _service.AddStudent(s);
            StudentConsoleView.PrintMessage("Thêm sinh viên thành công!");
        }

        private void SearchStudentUI()
        {
            Console.Write("Nhập Mã SV cần tìm: ");
            string ma = Console.ReadLine() ?? "";
            var student = _service.FindById(ma);

            if (student != null)
                StudentConsoleView.ShowList(new System.Collections.Generic.List<Student> { student });
            else
                StudentConsoleView.PrintMessage("Không tìm thấy sinh viên!", true);
        }

        private void ShowStats()
        {
            Console.WriteLine("--- THỐNG KÊ THEO NGÀNH ---");
            var stats = _service.StatByMajor();
            foreach (var item in stats)
            {
                Console.WriteLine($"- Ngành {item.Key}: {item.Value} sinh viên");
            }
        }
    }
}