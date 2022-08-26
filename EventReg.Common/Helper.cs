using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace EventReg.Common
{
    public static class Helper
    {
        public static string gen_Digits(this string s ,int length)
        {
            var rndDigits = new System.Text.StringBuilder().Insert(0, "0123456789", length).ToString().ToCharArray();
            return s=string.Join("", rndDigits.OrderBy(o => Guid.NewGuid()).Take(length));
        }
        public static string ReplaceAllWhiteSpaces(this string str)
        {
            return Regex.Replace(str, @"\s+", String.Empty);
        }
    }
}
