using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebAdmin.Common
{
    public static class MyString
    {
        public static String ToBase64(this String s)
        {
            if (s != null)
            {
                var bytes = Encoding.UTF8.GetBytes(s);
                return Convert.ToBase64String(bytes);
            }
            return s;
        }

        public static String FromBase64(this String s)
        {
            if (s != null)
            {
                var bytes = Convert.FromBase64String(s);
                return Encoding.UTF8.GetString(bytes);
            }
            return s;
        }

        public static String ToMD5(this String s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);
            var hash = MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static string str_slug(string s)
        {
            String[][] symbols ={
                                    new String[]{ "[åäāàáạảãâầấậẩẫăằắặẳẵäą]", "a"},
                                    new String[]{ "[đ]", "d"  },
                                    new String[]{ "[èéẹẻẽêềếệểễ]", "e" },
                                    new String[]{ "[ìíịỉĩ]", "i" },
                                    new String[]{ "[òóọỏõôồốộổỗơờớợởỡ]", "o" },
                                    new String[]{ "[ùúūụủũưừứựửữ]", "u" },
                                    new String[]{ "[ỳýỵỷỹ]", "y" },
                                    new String[]{  "[\\s'\";]","-"}
                                };
            s = s.ToLower();
            foreach (var ss in symbols)
            {
                s = Regex.Replace(s, ss[0], ss[1]);
            }
            return s;
        }
    }
}