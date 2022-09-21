using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace InformationSecurity.BusinessLogic.Helpers
{
    public static class StringHashHelper
    {
        public static string Md5(this string val)
        {
            return val.Md5(true);
        }

        public static string Md5(this string val, bool upperCase)
        {
            return val.Md5(upperCase, Encoding.Default);
        }

        public static string Md5(this string val, bool upperCase, Encoding encoding)
        {
            return
                new MD5CryptoServiceProvider()
                    .ComputeHash(encoding.GetBytes(val))
                    .Aggregate(new StringBuilder(), (curr, value) => curr.Append(value.ToString(upperCase ? "X2" : "x2"))).ToString();
        }
    }
}
