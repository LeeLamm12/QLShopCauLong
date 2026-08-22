using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.BLL
{
    public static class SessionBLL
    {
        public static TaiKhoan TaiKhoanHienTai { get; set; }

        public static bool IsAdmin => TaiKhoanHienTai?.VaiTro == "Quản trị viên";
        public static string TenDangNhap => TaiKhoanHienTai?.TenDangNhap;
        public static string MaNhanVien => TaiKhoanHienTai?.MaNhanVien;
        public static string TenNhanVien => TaiKhoanHienTai?.NhanVien?.HoTen;
    }
}
