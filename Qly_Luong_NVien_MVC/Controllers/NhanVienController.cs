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

        // GET: /getNhanVienByMaSo/{uid}
        public JsonResult getNhanVienByMaSo(string uid)
        {
            NhanVien nvien = db.nhan_vien.Where(nv => nv.ma_so.Equals(uid)).FirstOrDefault();
            return Json(nvien, JsonRequestBehavior.AllowGet);
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
