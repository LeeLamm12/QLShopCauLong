using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLShopCauLong.Forms;

namespace QLShopCauLong.BLL
{
    public static class SessionBLL
    {
        public static TaiKhoan TaiKhoanHienTai { get; set; }

        public static bool IsAdmin => TaiKhoanHienTai?.VaiTro == "Quản trị viên";
        public static string TenDangNhap => TaiKhoanHienTai?.TenDangNhap;
        public static string MaNhanVien => TaiKhoanHienTai?.MaNhanVien;
        public static string TenNhanVien => TaiKhoanHienTai?.NhanVien?.HoTen;

        // Trong SessionBLL hoặc 1 class helper chung
        public static bool XacNhanVaDangXuat(Form formHienTai)
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return false;

            SessionBLL.TaiKhoanHienTai = null;
            var dn = new DangNhap();
            dn.FormClosed += (s, args) => formHienTai.Close();
            dn.Show();
            formHienTai.Hide();
            return true;
        }
    }
}
