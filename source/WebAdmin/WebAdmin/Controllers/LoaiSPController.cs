using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;
using WebAdmin.Common;
using System.IO;

namespace WebAdmin.Controllers
{
    public class LoaiSPController : Controller
    {
        ShopMyPhamDataContext db = new ShopMyPhamDataContext();
        public ActionResult Index()
        {
            try
            {
                List<LOAISP> list = db.LOAISPs.ToList();
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult SuaLoaiSP(int id)
        {
            LOAISP model = KiemTraKhoaChinh(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult SuaLoaiSP(LOAISP model)
        {
            if (ModelState.IsValid)
            {
                bool result = UpdateLoaiSP(model);
                if (result)
                    TempData["SuccessMessage"] = "Chỉnh sửa thông tin thành công";
                else
                    TempData["DangerMessage"] = "Chỉnh sửa thông tin thất bại";
                return RedirectToAction("Index");
            }
            return this.View();
        }
        public ActionResult ChiTietLoaiSP(int id)
        {
            LOAISP model = KiemTraKhoaChinh(id);
            ViewBag.SoLuongNV = db.LOAISPs.Count();
            return View(model);
        }
        [HttpGet]
        public ActionResult TaoMoiLoaiSP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoiLoaiSP(LOAISP model)
        {
            if (ModelState.IsValid)
            {
                //var file = Request.Files["Image"];
                //var file = Request.Files["HinhAnh"];
                //if (file == null)
                //{
                //    ModelState.AddModelError("HinhAnh", "Hình ảnh chưa được chọn");
                //    return this.View();
                //}
                //else
                //{
                var file = Request.Files["HinhAnh"];
                    //Mảng mở rộng
                    string[] FileExtensions = new string[] { ".jpg", ".gif", ".png" };
                    //Kiểm tra phần mở rộng
                    if (!FileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("HinhAnh", "Kiểu tập tin " + string.Join(",", FileExtensions) + " không cho phép!");
                        return this.View();
                    }
                    else
                    {
                        string strSlug = MyString.str_slug(model.TenLoaiSP);
                        String fileName = strSlug + file.FileName.Substring(file.FileName.LastIndexOf('.'));
                        //Lưu vào CSDL
                        model.HinhAnh = fileName;
                        //Thiết lập đường dẫn trên server
                        String Strpath = Path.Combine(Server.MapPath("~/Content/Images/LoaiSP/"), fileName);
                    }
                //}
                if (CreateLoaiSP(model))
                    TempData["SuccessMessage"] = "Tạo mới loại sản phẩm thành công";
                else
                    TempData["DangerMessage"] = "Tạo mới loại sản phẩm thất bại";
                return RedirectToAction("Index");
            }
            return this.View();
        }
        public ActionResult XoaLoaiSP(int id)
        {
            if (DeleteLoaiSP(id))
                TempData["SuccessMessage"] = "Xóa loại sản phẩm thành công";
            else
                TempData["DangerMessage"] = "Xóa loại sản phẩm thất bại";
            return RedirectToAction("Index");
        }

        #region Thêm, xóa, sửa loại sản phẩm
        public LOAISP KiemTraKhoaChinh(int ma)
        {
            LOAISP l = db.LOAISPs.FirstOrDefault(t => t.MaLoaiSP == ma);
            return l;
        }
        public bool UpdateLoaiSP(LOAISP model)
        {
            try
            {
                LOAISP item = KiemTraKhoaChinh(model.MaLoaiSP);
                if (item != null)
                {
                    item.TenLoaiSP = model.TenLoaiSP;
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
        public bool CreateLoaiSP(LOAISP model)
        {
            try
            {
                db.LOAISPs.InsertOnSubmit(model);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteLoaiSP(int ma)
        {
            try
            {
                LOAISP item = KiemTraKhoaChinh(ma);
                if (item != null)
                {
                    db.LOAISPs.DeleteOnSubmit(item);
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