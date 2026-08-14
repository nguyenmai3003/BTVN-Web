using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai1_QuanLySinhVien
{
    public class StudentService
    {
    
        private List<Student> _students = new List<Student>();

     
        public void AddStudent(Student student)
        {
            if (_students.Any(s => s.MaSV == student.MaSV))
                throw new Exception("Lỗi: Mã sinh viên đã tồn tại trong hệ thống.");

            StudentValidator.ValidateStudent(student);
            _students.Add(student);
        }

        public List<Student> GetAll() => _students;

       
        public Student? FindById(string maSV) => _students.FirstOrDefault(s => s.MaSV == maSV);

        
        public List<Student> FindByName(string name) =>
            _students.Where(s => s.HoTen.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();

        
        public void UpdateStudent(Student updateInfo)
        {
            var student = FindById(updateInfo.MaSV);
            if (student == null) throw new Exception("Lỗi: Không tìm thấy sinh viên để cập nhật.");

            StudentValidator.ValidateStudent(updateInfo);

            student.HoTen = updateInfo.HoTen;
            student.NgaySinh = updateInfo.NgaySinh;
            student.GioiTinh = updateInfo.GioiTinh;
            student.Email = updateInfo.Email;
            student.SoDienThoai = updateInfo.SoDienThoai;
            student.NganhHoc = updateInfo.NganhHoc;
            student.DiemTB = updateInfo.DiemTB;
            student.TrangThaiHocTap = updateInfo.TrangThaiHocTap;
        }

        
        public void DeleteStudent(string maSV)
        {
            var student = FindById(maSV);
            if (student == null) throw new Exception("Lỗi: Không tìm thấy sinh viên để xóa.");
            _students.Remove(student);
        }

        
        public List<Student> SortByName() => _students.OrderBy(s => s.HoTen).ToList();
        public List<Student> SortByScore() => _students.OrderByDescending(s => s.DiemTB).ToList();

        
        public List<Student> GetStudentsAbove8() => _students.Where(s => s.DiemTB >= 8).ToList();
        public List<Student> GetTopScorers()
        {
            if (_students.Count == 0) return new List<Student>();
            double maxScore = _students.Max(s => s.DiemTB);
            return _students.Where(s => s.DiemTB == maxScore).ToList();
        }

        
        public double GetAverageScoreAll() => _students.Count > 0 ? _students.Average(s => s.DiemTB) : 0;

        
        public Dictionary<string, int> StatByMajor() =>
            _students.GroupBy(s => s.NganhHoc).ToDictionary(g => g.Key, g => g.Count());

        public Dictionary<string, int> StatByStatus() =>
            _students.GroupBy(s => s.TrangThaiHocTap).ToDictionary(g => g.Key, g => g.Count());
    }
}