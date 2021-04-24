using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;
using WebAdmin.Common;

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
                    TempData["SuccessMessage"] = "Đổi trạng thái sản phẩm thành công.";
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
            ViewBag.LoaiSP = new SelectList(db.LOAISPs.ToList(),"MaLoaiSP","TenLoaiSP",0);
            var mangDVT = new SelectList(
                new List<SelectListItem>{
                    new SelectListItem{Text="Cái",Value="Cái"},
                    new SelectListItem{Text="Lon",Value="Lon"},
                    new SelectListItem{Text="Thỏi", Value="Thỏi"},
                    new SelectListItem{Text="Chai",Value="Chai"}
            },"Value","Text");
            ViewBag.DVT = mangDVT;
            return View();
        }
        [HttpPost]
        public ActionResult TaoMoiSanPham(SANPHAM model)
        {
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        var file = Request.Files["Img"];
            //        if (file == null)
            //        {
            //            ModelState.AddModelError("HINHANH", "Hình ảnh chưa được chọn");
            //        }
            //        else
            //        {
            //            //Mãng mỡ rộng
            //            string[] FileExtensions = new string[] { ".jpg", ".gif", ".png" };
            //            //Kiểm tra phần mở rộng
            //            if (!FileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            //            {
            //                ModelState.AddModelError("HINHANH", "Kiểu tập tin" + string.Join(",", FileExtensions) + "không cho phép!");
            //            }
            //            else
            //            {
            //                string strSlug = MyString.str_slug(modelProduct.Name);
            //                String fileName = strSlug + file.FileName.Substring(file.FileName.LastIndexOf('.'));
            //                //Lưu vào CSDL
            //                modelProduct.Img = fileName;
            //                //Thiết lập đường dẫn trên server
            //                String Strpath = Path.Combine(Server.MapPath("~/Public/Images/Product/"), fileName);
            //                //upload hình lên server
            //                file.SaveAs(Strpath);
            //                modelProduct.Updated_By = 1;
            //                modelProduct.Created_By = 1; //Người đăng nhập tạo
            //                modelProduct.Created_At = DateTime.Now;
            //                modelProduct.Updated_At = DateTime.Now;
            //                db.Products.Add(modelProduct);
            //                db.SaveChanges();
            //                return RedirectToAction("Index");
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ModelState.AddModelError("HINHANH", "Thêm không thành công");
            //    }
            //}
            //var listcatid = db.Categorys.Where(m => m.Status != 0).ToList();
            //ViewBag.ListCatId = new SelectList(listcatid, "Id", "Name", 0);
            //return View(modelProduct);
            if (ModelState.IsValid)
            {
                var file = Request.Files["HinhAnh"];
                if (file == null)
                {
                    ModelState.AddModelError("HinhAnh", "Hình ảnh chưa được chọn");
                }
                else
                {
                    //Mảng mở rộng
                    string[] FileExtensions = new string[] { ".jpg", ".gif", ".png" };
                    //Kiểm tra phần mở rộng
                    if (!FileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("HinhAnh", "Kiểu tập tin " + string.Join(",", FileExtensions) + " không cho phép!");
                    }
                    else
                    {
                        string strSlug = MyString.str_slug(model.TenSP);
                        String fileName = strSlug + file.FileName.Substring(file.FileName.LastIndexOf('.'));
                        //Lưu vào CSDL
                        model.HinhAnh = fileName;
                        //Thiết lập đường dẫn trên server
                        String Strpath = Path.Combine(Server.MapPath("~/Content/Images/SanPham/"), fileName);
                    }
                }

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
        public List<SANPHAM> GetSanPhamByMaSP(int ma) 
        {
            return db.SANPHAMs.Where(t => t.MaLoai == ma).ToList();
        }
        #endregion
    }
}