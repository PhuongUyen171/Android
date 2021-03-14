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
        public ActionResult TaoMoiKhachHang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoiKhachHang(KHACHHANG model)
        {
            if (ModelState.IsValid)
            {
                if (CreateKhachHang(model))
                    TempData["SuccessMessage"] = "Tạo mới khách hàng thành công";
                else
                    TempData["DangerMessage"] = "Tạo mới khách hàng thất bại";
                return RedirectToAction("Index");

            }
            return this.View();
        }
        [HttpGet]
        public ActionResult SuaKhachHang(int id)
        {
            KHACHHANG model = KiemTraKhoaChinh(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult SuaKhachHang(KHACHHANG model)
        {
            if (ModelState.IsValid)
            {
                bool result = UpdateKhachHang(model);
                if (result)
                    TempData["SuccessMessage"] = "Chỉnh sửa thông tin khách hàng thành công";
                else
                    TempData["DangerMessage"] = "Chỉnh sửa thông tin khách hàng thất bại";
                return RedirectToAction("Index");
            }
            return this.View();
        }
        public ActionResult ChiTietKhachHang(int id)
        {
            KHACHHANG model = KiemTraKhoaChinh(id);
            //ViewBag.SoLuongNV = db.LOAISPs.Count();
            return View(model);
        }
        public ActionResult XoaKhachHang(int id)
        {
            if (DeleteKhachHang(id))
                TempData["SuccessMessage"] = "Xóa khách hàng thành công";
            else
                TempData["DangerMessage"] = "Xóa khách hàng thất bại";
            return RedirectToAction("Index");
        }
        #region Thêm, xóa, sửa khách hàng
        public KHACHHANG KiemTraKhoaChinh(int ma)
        {
            KHACHHANG k = db.KHACHHANGs.FirstOrDefault(t => t.MaKH == ma);
            return k;
        }
        public bool UpdateKhachHang(KHACHHANG model)
        {
            try
            {
                KHACHHANG item = KiemTraKhoaChinh(model.MaKH);
                if (item != null)
                {
                    item.TenKH = model.TenKH;
                    item.SDT = model.SDT;
                    item.Email = model.Email;
                    item.DiaChi = model.DiaChi;
                    item.MatKhau = Encryptor.MD5Hash(item.MatKhau);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CreateKhachHang(KHACHHANG model)
        {
            try
            {
                model.MatKhau = Encryptor.MD5Hash(model.MatKhau);
                db.KHACHHANGs.InsertOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteKhachHang(int ma)
        {
            try
            {
                KHACHHANG item = KiemTraKhoaChinh(ma);
                if (item != null)
                {
                    db.KHACHHANGs.DeleteOnSubmit(item);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}