using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class TaiKhoanBLL
    {
        private readonly TaiKhoanDAL dal = new TaiKhoanDAL();

        /// <summary>
        /// Đăng nhập: trả về (thành công?, tài khoản, thông báo lỗi)
        /// </summary>
        public (bool ThanhCong, TaiKhoan TaiKhoan, string ThongBao) DangNhap(string tenDangNhap, string matKhau)
        {
            if (ValidationHelper.IsNullOrEmpty(tenDangNhap))
                return (false, null, "Vui lòng nhập tên đăng nhập.");
            if (ValidationHelper.IsNullOrEmpty(matKhau))
                return (false, null, "Vui lòng nhập mật khẩu.");

            var tk = dal.LayTheoTenDangNhap(tenDangNhap);
            if (tk == null)
                return (false, null, "Tên đăng nhập không tồn tại.");

            // So sánh mật khẩu đã mã hóa
            string mkHash = MatKhauHelper.MaHoaSHA256(matKhau);
            if (tk.MatKhau != mkHash)
                return (false, null, "Mật khẩu không đúng.");

            if (tk.TrangThai == false)
                return (false, null, "Tài khoản đã bị khóa.");

            return (true, tk, "Đăng nhập thành công.");
        }

        public List<TaiKhoan> LayDanhSach() => dal.LayDanhSach();

        public List<string> Validate(TaiKhoan tk, bool laThemMoi)
        {
            var loi = new List<string>();
            if (ValidationHelper.IsNullOrEmpty(tk.TenDangNhap))
                loi.Add("Tên đăng nhập không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(tk.MatKhau))
                loi.Add("Mật khẩu không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(tk.MaNhanVien))
                loi.Add("Vui lòng chọn nhân viên.");
            if (laThemMoi && dal.KiemTraTonTai(tk.TenDangNhap))
                loi.Add($"Tên đăng nhập '{tk.TenDangNhap}' đã tồn tại.");
            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(TaiKhoan tk)
        {
            var loi = Validate(tk, true);
            if (loi.Count > 0) return (false, loi);

            // Mã hóa mật khẩu trước khi lưu
            tk.MatKhau = MatKhauHelper.MaHoaSHA256(tk.MatKhau);
            dal.Them(tk);
            return (true, loi);
        }

        public (bool ThanhCong, List<string> Loi) Sua(TaiKhoan tk)
        {
            var loi = Validate(tk, false);
            if (loi.Count > 0) return (false, loi);

            // Nếu mật khẩu chưa mã hóa (length != 64) thì mã hóa lại
            if (tk.MatKhau.Length != 64)
                tk.MatKhau = MatKhauHelper.MaHoaSHA256(tk.MatKhau);

            bool ok = dal.Sua(tk);
            if (!ok) loi.Add("Tài khoản không tồn tại.");
            return (ok, loi);
        }

        public (bool ThanhCong, string ThongBao) DoiMatKhau(string tenDangNhap, string mkCu, string mkMoi, string mkXacNhan)
        {
            if (mkMoi != mkXacNhan)
                return (false, "Mật khẩu xác nhận không khớp.");

            var tk = dal.LayTheoTenDangNhap(tenDangNhap);
            if (tk == null) return (false, "Tài khoản không tồn tại.");

            string mkCuHash = MatKhauHelper.MaHoaSHA256(mkCu);
            if (tk.MatKhau != mkCuHash)
                return (false, "Mật khẩu cũ không đúng.");

            dal.DoiMatKhau(tenDangNhap, MatKhauHelper.MaHoaSHA256(mkMoi));
            return (true, "Đổi mật khẩu thành công.");
        }

        public (bool ThanhCong, string ThongBao) Xoa(string tenDangNhap)
        {
            if (!dal.KiemTraTonTai(tenDangNhap))
                return (false, "Tài khoản không tồn tại.");
            dal.Xoa(tenDangNhap);
            return (true, "Xóa thành công.");
        }

        /// <summary>
        /// Admin reset mật khẩu về mặc định "123456"
        /// </summary>
        public (bool ThanhCong, string ThongBao) ResetMatKhau(string tenDangNhap)
        {
            if (!SessionBLL.IsAdmin)
                return (false, "Bạn không có quyền thực hiện thao tác này.");

            if (!dal.KiemTraTonTai(tenDangNhap))
                return (false, "Tài khoản không tồn tại.");

            if (tenDangNhap == SessionBLL.TenDangNhap)
                return (false, "Không thể tự reset mật khẩu của chính mình.");

            string mkMacDinh = MatKhauHelper.MaHoaSHA256("123456");
            dal.DoiMatKhau(tenDangNhap, mkMacDinh);
            return (true, "Reset mật khẩu thành công. Mật khẩu mặc định: 123456");
        }

        public (bool ThanhCong, string ThongBao) KhoaTaiKhoan(string tenDangNhap)
        {
            if (!SessionBLL.IsAdmin)
                return (false, "Không có quyền.");

            if (tenDangNhap == SessionBLL.TenDangNhap)
                return (false, "Không thể tự khóa chính mình.");

            if (!dal.KiemTraTonTai(tenDangNhap))
                return (false, "Tài khoản không tồn tại.");

            dal.KhoaTaiKhoan(tenDangNhap);
            return (true, "Khóa tài khoản thành công.");
        }

        public (bool ThanhCong, string ThongBao) MoKhoaTaiKhoan(string tenDangNhap)
        {
            if (!SessionBLL.IsAdmin)
                return (false, "Không có quyền.");

            if (!dal.KiemTraTonTai(tenDangNhap))
                return (false, "Tài khoản không tồn tại.");

            dal.MoKhoaTaiKhoan(tenDangNhap);
            return (true, "Mở khóa tài khoản thành công.");
        }
    }
}
