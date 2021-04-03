using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        ShopMyPhamDataContext db = new ShopMyPhamDataContext();
        // GET: Login
        public ActionResult Index(string user)
        {
            try
            {
                NHANVIEN nv = KiemTraKhoaChinh(user);
                return View(nv);
            }
            catch (Exception)
            {
                return View("Login");
            }
        }
        [HttpPost]
        public ActionResult Index(NHANVIEN model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = SuaNhanVien(model);
                    if (result)
                        TempData["SuccessMessage"] = "Chỉnh sửa nhân viên thành công.";
                    else
                        TempData["DangerMessage"] = "Chỉnh sửa nhân viên thất bại.";
                }
                else
                    TempData["DangerMessage"] = "Thiếu thông tin";
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }

        }
        public ActionResult Login()
        {
            try
            {
                NHANVIEN nv = KiemTraTaiKhoanCookies();
                if (nv == null)
                    return View();
                else if (nv.Quyen == false)
                    return View();
                else
                {
                    //Save token API
                    Session["ADMIN_SESSION"] = nv;
                    //string tokenUser = GetToken(model.TaiKhoan);
                    //HttpCookie cookie = new HttpCookie("TOKEN_NUMBER", tokenUser);
                    //Response.Cookies.Add(cookie);
                    return RedirectToAction("Login", "Login", new { model = nv });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Login(NHANVIEN model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int result = LayKetQuaDangNhap(model.TaiKhoan, model.MatKhau);
                    switch (result)
                    {
                        case 3:
                            {
                                var adSession = new NHANVIEN { TaiKhoan = model.TaiKhoan, MatKhau = model.MatKhau, Quyen = model.Quyen, TenNV = model.TenNV };
                                
                                //Xử lý remember me
                                Session.Add("ADMIN_SESSION", adSession);
                                if (model.RememberMe)
                                {
                                    HttpCookie ckUser = new HttpCookie("USERNAME_ADMIN");
                                    ckUser.Expires = DateTime.Now.AddHours(48);
                                    ckUser.Value = model.TaiKhoan;
                                    Response.Cookies.Add(ckUser);

                                    HttpCookie ckPass = new HttpCookie("PASSWORD_ADMIN");
                                    ckPass.Expires = DateTime.Now.AddHours(48);
                                    ckPass.Value = model.MatKhau;
                                    Response.Cookies.Add(ckPass);

                                    HttpCookie ckName = new HttpCookie("NAME_ADMIN");
                                    ckName.Expires = DateTime.Now.AddHours(48);
                                    ckName.Value = model.MatKhau;
                                    Response.Cookies.Add(ckName);
                                }
                                return RedirectToAction("Index", "Login", new { user = adSession.TaiKhoan });
                            }
                        case 0:
                            TempData["DangerMessage"] = "Tài khoản không tồn tại.";
                            break;
                        case 2:
                            TempData["DangerMessage"] = "Mật khẩu không đúng.";
                            break;
                        case 1:
                            TempData["DangerMessage"] = "Tài khoản bạn đã bị khóa.";
                            break;
                        default:
                            TempData["DangerMessage"] = "Đăng nhập thất bại.";
                            break;
                    }
                }
                return this.View();
            }
            catch (Exception)
            {
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            try
            {
                Session.Remove("ADMIN_SESSION");
                if (Response.Cookies["USERNAME_ADMIN"] != null)
                {
                    HttpCookie ckUser = new HttpCookie("USERNAME_ADMIN");
                    ckUser.Expires = DateTime.Now.AddHours(-48);
                    Response.Cookies.Add(ckUser);
                }
                if (Response.Cookies["PASSWORD_ADMIN"] != null)
                {
                    HttpCookie ckPass = new HttpCookie("PASSWORD_ADMIN");
                    ckPass.Expires = DateTime.Now.AddHours(-48);
                    Response.Cookies.Add(ckPass);
                }
                if (Response.Cookies["NAME_ADMIN"] != null)
                {
                    HttpCookie ckName = new HttpCookie("NAME_ADMIN");
                    ckName.Expires = DateTime.Now.AddHours(-48);
                    Response.Cookies.Add(ckName);
                }
                return View("Login");
            }
            catch (Exception)
            {
                return View("Login");
            }
        }

        #region Lấy kiểm tra thông tin tài khoản admin
        public NHANVIEN KiemTraTaiKhoanCookies()
        {
            NHANVIEN nv = null;
            string username = string.Empty;
            string fullname = string.Empty;
            if (Request.Cookies["USERNAME_ADMIN"] != null)
                username = Request.Cookies["USERNAME_ADMIN"].Value;
            if (Request.Cookies["NAME_ADMIN"] != null)
                fullname = Request.Cookies["NAME_ADMIN"].Value;
            if (!string.IsNullOrEmpty(username) & !string.IsNullOrEmpty(fullname))
                nv = new NHANVIEN { TaiKhoan = username, TenNV = fullname };
            return nv;
        }
        public int LayKetQuaDangNhap(string user, string pass)
        {
            //0: Tài khoản ko tồn tại
            //1: Tài khoản đang bị khóa
            //2: Mật khẩu không đúng
            //3: Thành công
            var nv = db.NHANVIENs.FirstOrDefault(x => x.TaiKhoan == user);
            if (nv == null)
                return 0;
            else if (nv.Quyen == false)
                return 1;
            else if (nv.MatKhau != Encryptor.MD5Hash(pass))
                return 2;
            else
                return 3;
        }
        public NHANVIEN KiemTraKhoaChinh(string username)
        {
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(t => t.TaiKhoan == username);
            return nv;
        }

        #endregion

        #region Đổi mật khẩu
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (KiemTraKhoaChinh(model.Email) == null)
            {
                ModelState.AddModelError("Email", "Tài khoản chưa được đăng kí.");
                return this.View();
            }
            return RedirectToAction("ResetPassword", new { account = model.Email });
        }
        public ActionResult ResetPassword(string account)
        {
            if (string.IsNullOrWhiteSpace(account))
                return View("~/Views/Shared/404NotFound.cshtml");
            NHANVIEN nv = KiemTraKhoaChinh(account);
            ResetPasswordModel model = new ResetPasswordModel();
            model.Mail = nv.TaiKhoan;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            NHANVIEN resultReset = KiemTraKhoaChinh(model.Mail);
            resultReset.MatKhau = Encryptor.MD5Hash(model.NewPassword);
            db.SubmitChanges();
            return RedirectToAction("Login");
        }
        #endregion
        public bool SuaNhanVien(NHANVIEN model)
        {
            try
            {
                var nv = KiemTraKhoaChinh(model.TaiKhoan);
                if (nv != null)
                {
                    nv.TenNV = model.TenNV;
                    nv.MatKhau = Encryptor.MD5Hash(model.MatKhau);
                    nv.Quyen = model.Quyen;
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
    }
}