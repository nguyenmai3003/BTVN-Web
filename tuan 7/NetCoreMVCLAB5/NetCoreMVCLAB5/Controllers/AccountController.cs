using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreMVCLAB5.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NetCoreMVCLAB5.Controllers
{
    public class AccountController : Controller
    {
        // GET: AccountController
        public ActionResult Index()
        {
            // quick runtime check: visit /Account?test=1 to see a plain text response
            if (Request.Query.ContainsKey("test") && Request.Query["test"] == "1")
            {
                return Content("Index action reached");
            }
            // sample data so the view shows something while developing
            List<Account> accounts = new List<Account>
            {
                new Account { Id = 1, FullName = "Nguyen Van A", Email = "a@example.com", Phone = "0123456789", Address = "Ha Noi", Birthday = DateTime.Now.AddYears(-25), Gender = "Male" },
                new Account { Id = 2, FullName = "Tran Thi B", Email = "b@example.com", Phone = "0987654321", Address = "Ho Chi Minh", Birthday = DateTime.Now.AddYears(-30), Gender = "Female" }
            };

            return View(accounts);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            Account model = new Account();
            return View(model);
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account account)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(account);
                }

                // TODO: save account to a database or repository
                // For now we redirect back to the list
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(account);
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyPhone(string phone)
        {
            Regex _isPhone = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if (!_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} Không đúng định dạng, VD: 0986421127 hoặc 098.421.1127");
            }

            return Json(true);
        }
    }
}
