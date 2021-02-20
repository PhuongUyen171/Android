using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;
namespace WebAdmin.Controllers
{
    public class NhanVienController : Controller
    {
        // GET: NhanVien
        ShopMyPhamDataContext db = new ShopMyPhamDataContext();
        public ActionResult Index()
        {
            try
            {
                List<NHANVIEN> list = db.NHANVIENs.ToList();
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult ChangeStatus(string id)
        {
            try
            {
                NHANVIEN nv = db.NHANVIENs.FirstOrDefault(t => t.TaiKhoan == id);
                if (nv != null)
                {
                    nv.Quyen = !nv.Quyen;
                    db.SubmitChanges();
                    TempData["SuccessMessage"] = "Đổi quyền truy cập nhân viên thành công.";
                }
                else
                    TempData["DangerMessage"] = "Có lỗi xảy ra";
                return RedirectToAction("Index", "NhanVien");
            }
            catch (Exception)
            {
                TempData["DangerMessage"] = "Có lỗi xảy ra";
                return RedirectToAction("Index", "NhanVien");
            }
        }
    }
}