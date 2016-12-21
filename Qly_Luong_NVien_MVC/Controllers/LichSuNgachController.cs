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
    public class LichSuNgachController : Controller
    {
        private NhanVienLuongDBContext db = new NhanVienLuongDBContext();

        // GET: /LichSuNgach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ICollection<LichSuNgach> lichsungach = db.lich_su_ngach.Where(l => l.nhan_vien.id == id).ToList();
            if (lichsungach == null)
            {
                return HttpNotFound();
            }
            return View(lichsungach);
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
