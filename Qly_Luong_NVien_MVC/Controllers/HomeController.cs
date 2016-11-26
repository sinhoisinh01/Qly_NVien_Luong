using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Qly_Luong_NVien_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "SGU - Trang chủ";
            ViewBag.PageType = "index";
            return View();
        }

        public ActionResult Salary()
        {
            ViewBag.Title = "SGU - Xem lương";
            ViewBag.PageType = "xem_luong";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
