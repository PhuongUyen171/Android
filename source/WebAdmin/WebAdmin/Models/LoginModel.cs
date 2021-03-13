using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAdmin.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter your username.")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Please enter your password.")]
        [Display(Name = "Password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
        public string RoleID { set; get; }
        public LoginModel() { }
    }
}