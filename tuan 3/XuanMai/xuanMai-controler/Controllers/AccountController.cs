using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAppMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<Account> accounts = new List<Account>
            {
                new Account()
                {
                    Id = 1, Name = "Hoàng Anh",
                    Email = "anh@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/02.jfif"),
                    Gender = 1, Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },
                new Account()
                {
                    Id = 2, Name = "Trường Giang",
                    Email = "giang@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/03.jfif"),
                    Gender = 1, Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                },
                new Account()
                {
                    Id = 3, Name = "Hoàng Thúy",
                    Email = "thuy@gmail.com",
                    Phone = "0986456789",
                    Address = "Hà Nội",
                    Avatar = Url.Content("~/Avatar/04.jfif"),
                    Gender = 1, Bio = "My name is small",
                    Birthday = new DateTime(1998, 7, 15)
                }
            };

            ViewBag.Accounts = accounts;
            return View();
        } // <-- Đã thêm ngoặc đóng cho hàm Index() tại đây

        [Route("ho-so-cua-toi", Name = "profile")]
        public IActionResult Profile(int id)
        {
            // Danh sách Account giống như trong Index
            List<Account> accounts = new List<Account>
            {
                new Account(){ Id = 1, Name = "Hoàng Anh", Email = "anh@gmail.com", Phone = "0986456789", Address = "Hà Nội", Avatar = Url.Content("~/Avatar/02.jfif"), Gender = 1, Bio = "My name is small", Birthday = new DateTime(1998,7,15) },
                new Account(){ Id = 2, Name = "Trường Giang", Email = "giang@gmail.com", Phone = "0986456789", Address = "Hà Nội", Avatar = Url.Content("~/Avatar/03.jfif"), Gender = 1, Bio = "My name is small", Birthday = new DateTime(1998,7,15) },
                new Account(){ Id = 3, Name = "Hoàng Thúy", Email = "thuy@gmail.com", Phone = "0986456789", Address = "Hà Nội", Avatar = Url.Content("~/Avatar/04.jfif"), Gender = 1, Bio = "My name is small", Birthday = new DateTime(1998,7,15) }
            };

            // tìm account theo id; nếu không tìm thấy, lấy phần tử đầu làm mặc định
            Account account = accounts.FirstOrDefault(ac => ac.Id == id) ?? accounts.First();

            // gửi đối tượng account qua view
            ViewBag.account = account;
            return View();
        }
    }
}