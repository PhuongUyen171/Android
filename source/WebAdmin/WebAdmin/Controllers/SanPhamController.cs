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
        public ActionResult ChangeStatus(int id)
        {
            try
            {
                SANPHAM nv = db.SANPHAMs.FirstOrDefault(t => t.MaSP == id);
                if (nv != null)
                {
                    nv.TrangThai = !nv.TrangThai;
                    db.SubmitChanges();
                    TempData["SuccessMessage"] = "Đổi quyền truy cập nhân viên thành công.";
                }
                else
                    TempData["DangerMessage"] = "Có lỗi xảy ra";
                return RedirectToAction("Index", "SanPham");
            }
            catch (Exception)
            {
                TempData["DangerMessage"] = "Có lỗi xảy ra";
                return RedirectToAction("Index", "SanPham");
            }
        }
        [HttpGet]
        public ActionResult SuaSanPham(int id)
        {
            SANPHAM model = KiemTraKhoaChinh(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult SuaSanPham(SANPHAM model)
        {
            if (ModelState.IsValid)
            {
                bool result = UpdateSanPham(model);
                if (result)
                    TempData["SuccessMessage"] = "Chỉnh sửa thông tin thành công";
                else
                    TempData["DangerMessage"] = "Chỉnh sửa thông tin thất bại";
                return RedirectToAction("Index");
            }
            return this.View();
        }
        public ActionResult ChiTietSanPham(int id)
        {
            SANPHAM model = KiemTraKhoaChinh(id);
            //ViewBag.SoLuongNV = db.LOAISPs.Count();
            return View(model);
        }
        [HttpGet]
        public ActionResult TaoMoiSanPham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoiSanPham(SANPHAM model)
        {
            if (ModelState.IsValid)
            {
                if (CreateSanPham(model))
                    TempData["SuccessMessage"] = "Tạo mới thông tin thành công";
                else
                    TempData["DangerMessage"] = "Tạo mới thông tin thất bại";
                return RedirectToAction("Index");

            }
            return this.View();
        }
        public ActionResult XoaSanPham(int id)
        {
            if (DeleteSanPham(id))
                TempData["SuccessMessage"] = "Xóa thông tin thành công";
            else
                TempData["DangerMessage"] = "Xóa thông tin thất bại";
            return RedirectToAction("Index");
        }

        #region Thêm, xóa, sửa sản phẩm
        public SANPHAM KiemTraKhoaChinh(int ma)
        {
            SANPHAM s = db.SANPHAMs.FirstOrDefault(t => t.MaSP == ma);
            return s;
        }
        public bool UpdateSanPham(SANPHAM model)
        {
            try
            {
                SANPHAM item = KiemTraKhoaChinh(model.MaSP);
                if (item != null)
                {
                    item.TenSP = model.TenSP;
                    item.MoTa = model.MoTa;
                    item.SoLuong = model.SoLuong;
                    item.TrangThai = model.TrangThai;
                    item.MaLoai = model.MaLoai;
                    item.HinhAnh = model.HinhAnh;
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
        public bool CreateSanPham(SANPHAM model)
        {
            try
            {
                db.SANPHAMs.InsertOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteSanPham(int ma)
        {
            try
            {
                SANPHAM item = KiemTraKhoaChinh(ma);
                if (item != null)
                {
                    db.SANPHAMs.DeleteOnSubmit(item);
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