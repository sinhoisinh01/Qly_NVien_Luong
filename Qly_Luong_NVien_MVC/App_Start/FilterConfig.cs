﻿using System.Web;
using System.Web.Mvc;

namespace Qly_Luong_NVien_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}