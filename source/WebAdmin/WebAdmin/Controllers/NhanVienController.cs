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
        [HttpGet]
        public ActionResult SuaNhanVien(string id)
        {
            NHANVIEN model = KiemTraKhoaChinh(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult SuaNhanVien(NHANVIEN model)
        {
            if (ModelState.IsValid)
            {
                bool result = UpdateNhanVien(model);
                if (result)
                    TempData["SuccessMessage"] = "Chỉnh sửa thông tin thành công";
                else
                    TempData["DangerMessage"] = "Chỉnh sửa thông tin thất bại";
                return RedirectToAction("Index");
            }
            return this.View();
        }
        public ActionResult ChiTietNhanVien(string id)
        {
            NHANVIEN model = KiemTraKhoaChinh(id);
            //ViewBag.SoLuongNV = db.LOAISPs.Count();
            return View(model);
        }
        [HttpGet]
        public ActionResult TaoMoiNhanVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoiNhanVien(NHANVIEN model)
        {
            if (ModelState.IsValid)
            {
                if (CreateNhanVien(model))
                    TempData["SuccessMessage"] = "Tạo mới nhân viên thành công";
                else
                    TempData["DangerMessage"] = "Tạo mới nhân viên thất bại";
                return RedirectToAction("Index");

            }
            return this.View();
        }
        public ActionResult XoaNhanVien(string id)
        {
            if (DeleteNhanVien(id))
                TempData["SuccessMessage"] = "Xóa nhân viên thành công";
            else
                TempData["DangerMessage"] = "Xóa nhân viên thất bại";
            return RedirectToAction("Index");
        }

        #region Thêm, xóa, sửa nhân viên
        public NHANVIEN KiemTraKhoaChinh(string username)
        {
            NHANVIEN n = db.NHANVIENs.FirstOrDefault(t => t.TaiKhoan == username);
            return n;
        }
        public bool UpdateNhanVien(NHANVIEN model)
        {
            try
            {
                NHANVIEN item = KiemTraKhoaChinh(model.TaiKhoan);
                if (item != null)
                {
                    item.MatKhau = model.MatKhau;
                    item.Quyen = model.Quyen;
                    item.TenNV = model.TenNV;
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
        public bool CreateNhanVien(NHANVIEN model)
        {
            try
            {
                model.Quyen = true;
                model.MatKhau = Encryptor.MD5Hash(model.MatKhau);
                db.NHANVIENs.InsertOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteNhanVien(string username)
        {
            try
            {
                NHANVIEN item = KiemTraKhoaChinh(username);
                if (item != null)
                {
                    db.NHANVIENs.DeleteOnSubmit(item);
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