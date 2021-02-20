using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class SanPhamController : Controller
    {
        ShopMyPhamDataContext db = new ShopMyPhamDataContext();
        public ActionResult Index()
        {
            try
            {
                List<SANPHAM> list = db.SANPHAMs.ToList();
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}