using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.BLL
{
    public static class MatKhauHelper
    {
        /// <summary>
        /// Mã hóa MD5
        /// </summary>
        public static string MaHoaMD5(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>
        /// Mã hóa SHA256 (bảo mật hơn MD5, khuyên dùng)
        /// </summary>
        public static string MaHoaSHA256(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            using (var sha = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
