using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLShopCauLong.BLL
{
    public class ValidationHelper
    {
        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsValidPhone(string phone)
        {
            if (IsNullOrEmpty(phone)) return true; // SĐT không bắt buộc ở 1 số bảng
            return Regex.IsMatch(phone, @"^(0)[0-9]{9,10}$");
        }

        public static bool IsValidEmail(string email)
        {
            if (IsNullOrEmpty(email)) return true; // Email không bắt buộc
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsPositiveDecimal(decimal value)
        {
            return value > 0;
        }

        public static bool IsPositiveInt(int value)
        {
            return value >= 0;
        }
    }
}
