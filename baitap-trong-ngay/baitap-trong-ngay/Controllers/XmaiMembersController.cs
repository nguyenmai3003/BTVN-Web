using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using baitap_trong_ngay.Models;
using System.Collections.Generic;
using System.Linq;

namespace baitap_trong_ngay.Controllers
{
    public class XmaiMembersController : Controller
    {
        private static List<XmaiMember> XmaiMembers = new List<XmaiMember>();
        // GET: XmaiMembersController 
        public ActionResult Index()
        {
            // pass the in-memory list to the view
            return View(XmaiMembers);
        }

        // GET: XmaiMembersController/Details/5
        public ActionResult Details(int id)
        {
            var member = XmaiMembers.Find(m => m.Id == id);
            return View(member);
        }

        // GET: XmaiMembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: XmaiMembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(XmaiMember member)
        {
            try
            {
                if (member != null)
                {
                    member.Id = XmaiMembers.Count > 0 ? XmaiMembers.Max(m => m.Id) + 1 : 1;
                    XmaiMembers.Add(member);
                    return RedirectToAction(nameof(Index));
                }

                return View(member);
            }
            catch
            {
                return View(member);
            }
        }

        // GET: XmaiMembersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: XmaiMembersController/Edit/5
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

        // GET: XmaiMembersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: XmaiMembersController/Delete/5
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
    }
}
