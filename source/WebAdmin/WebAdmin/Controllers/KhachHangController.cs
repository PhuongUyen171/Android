using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class KhachHangController : Controller
    {
        ShopMyPhamDataContext db = new ShopMyPhamDataContext();
        public ActionResult Index()
        {
            try
            {
                List<KHACHHANG> list = db.KHACHHANGs.ToList();
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}