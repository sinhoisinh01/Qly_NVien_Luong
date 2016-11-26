using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Qly_Luong_NVien_Model;
using Qly_Luong_NVien_MVC.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Qly_Luong_NVien_MVC.Controllers
{
    public class TinhLuongController : Controller
    {
        private NhanVienLuongDBContext db = new NhanVienLuongDBContext();

        // GET: /TinhLuong/get/{id}
        public JsonResult get(int id)
        {
            //DateTime dt = date == null ?
            //    DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now;
            ICollection<TinhLuong> tlTable = db.tinh_luong
                .Where(tl => tl.nhan_vien.id == id)
                //.Where(tl => tl.ngay_ket_thuc == null
                //    || (new Regex(@"/" + dt.Month.ToString() + "/" + dt.Year.ToString() + "$")).IsMatch(tl.ngay_ket_thuc.ToString()))
                .ToList();
            return Json(tlTable, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getLuongCoBan()
        {
            HangSo hangSo = db.hang_so.Where(hs => hs.ten_hang_so == "LUONG_CO_BAN").First();
            return Json(hangSo, JsonRequestBehavior.AllowGet);
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
