using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAdmin.Models
{
    public partial class NHANVIEN
    {
        public bool RememberMe { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage = "please enter the confirm password.")]
        //[Compare(otherProperty: "MatKhau", ErrorMessage = "new & confirm password does not match.")]
        //public string Matkhau2 { get; set; }


    }
}