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
    public class TinhLuongController : Controller
    {
        private NhanVienLuongDBContext db = new NhanVienLuongDBContext();

        //
        // GET: /TinhLuong/

        public ActionResult Index()
        {
            return View(db.tinh_luong.ToList());
        }

        //
        // GET: /TinhLuong/Details/5

        public ActionResult Details(int id = 0)
        {
            TinhLuong tinhluong = db.tinh_luong.Find(id);
            if (tinhluong == null)
            {
                return HttpNotFound();
            }
            return View(tinhluong);
        }

        //
        // GET: /TinhLuong/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TinhLuong/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TinhLuong tinhluong)
        {
            if (ModelState.IsValid)
            {
                db.tinh_luong.Add(tinhluong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tinhluong);
        }

        //
        // GET: /TinhLuong/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TinhLuong tinhluong = db.tinh_luong.Find(id);
            if (tinhluong == null)
            {
                return HttpNotFound();
            }
            return View(tinhluong);
        }

        //
        // POST: /TinhLuong/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TinhLuong tinhluong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tinhluong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tinhluong);
        }

        //
        // GET: /TinhLuong/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TinhLuong tinhluong = db.tinh_luong.Find(id);
            if (tinhluong == null)
            {
                return HttpNotFound();
            }
            return View(tinhluong);
        }

        //
        // POST: /TinhLuong/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinhLuong tinhluong = db.tinh_luong.Find(id);
            db.tinh_luong.Remove(tinhluong);
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