using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class NhanVienController : Controller
    {
        private NhanVienLuongDBContext db = new NhanVienLuongDBContext();

        //
        // GET: /NhanVien/

        public ActionResult Index()
        {
            return View(db.nhan_vien.ToList());
        }

        //
        // GET: /NhanVien/Details/5

        public ActionResult Details(int id = 0)
        {
            NhanVien nhanvien = db.nhan_vien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        //
        // GET: /NhanVien/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NhanVien/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.nhan_vien.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanvien);
        }

        //
        // GET: /NhanVien/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NhanVien nhanvien = db.nhan_vien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        //
        // POST: /NhanVien/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanvien);
        }

        //
        // GET: /NhanVien/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NhanVien nhanvien = db.nhan_vien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        //
        // POST: /NhanVien/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanvien = db.nhan_vien.Find(id);
            db.nhan_vien.Remove(nhanvien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}