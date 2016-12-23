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
    public class LichSuChucVuController : Controller
    {
        private NhanVienLuongDBContext db = new NhanVienLuongDBContext();

        // GET: /LichSuChucVu/
        public ActionResult Index(int? id)
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

        // GET: /LichSuChucVu/getLichSuChucVu/nhan_vien_id
        public JsonResult getLichSuChucVu(int? nhan_vien_id)
        {
            if (nhan_vien_id == null)
            {
                return null;
            }
            ICollection<LichSuChucVu> lichsuchucvu = db.lich_su_chuc_vu.Where(l => l.nhan_vien.id == nhan_vien_id).ToList();
            return Json(lichsuchucvu, JsonRequestBehavior.AllowGet);
        }

        // GET: /LichSuChucVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichSuChucVu lichsuchucvu = db.lich_su_chuc_vu.Find(id);
            if (lichsuchucvu == null)
            {
                return HttpNotFound();
            }
            return View(lichsuchucvu);
        }

        // GET: /LichSuChucVu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /LichSuChucVu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,ngay_bat_dau,ngay_ket_thuc")] LichSuChucVu lichsuchucvu)
        {
            if (ModelState.IsValid)
            {
                db.lich_su_chuc_vu.Add(lichsuchucvu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lichsuchucvu);
        }

        // GET: /LichSuChucVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichSuChucVu lichsuchucvu = db.lich_su_chuc_vu.Find(id);
            if (lichsuchucvu == null)
            {
                return HttpNotFound();
            }
            return View(lichsuchucvu);
        }

        // POST: /LichSuChucVu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,ngay_bat_dau,ngay_ket_thuc")] LichSuChucVu lichsuchucvu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lichsuchucvu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lichsuchucvu);
        }

        // GET: /LichSuChucVu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LichSuChucVu lichsuchucvu = db.lich_su_chuc_vu.Find(id);
            if (lichsuchucvu == null)
            {
                return HttpNotFound();
            }
            return View(lichsuchucvu);
        }

        // POST: /LichSuChucVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LichSuChucVu lichsuchucvu = db.lich_su_chuc_vu.Find(id);
            db.lich_su_chuc_vu.Remove(lichsuchucvu);
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
