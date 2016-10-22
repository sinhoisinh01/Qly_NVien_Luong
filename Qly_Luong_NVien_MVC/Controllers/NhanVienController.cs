using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Qly_Luong_NVien_Model;

namespace Qly_Luong_NVien_MVC.Controllers
{
    public class NhanVienController : Controller
    {
        private NhanVienLuongDBContext db = new NhanVienLuongDBContext();

        // GET: /NhanVien/
        public ActionResult Index()
        {
            return View(db.nhan_vien.ToList());
        }

        // GET: /NhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.nhan_vien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: /NhanVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,ma_so,ho,ten,gioi_tinh,ngay_sinh,dan_toc,dia_chi,cmnd,hinh_anh,ngay_vao_lam,ngay_nghi_lam")] NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.nhan_vien.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanvien);
        }

        // GET: /NhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.nhan_vien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: /NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,ma_so,ho,ten,gioi_tinh,ngay_sinh,dan_toc,dia_chi,cmnd,hinh_anh,ngay_vao_lam,ngay_nghi_lam")] NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanvien);
        }

        // GET: /NhanVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.nhan_vien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

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
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
