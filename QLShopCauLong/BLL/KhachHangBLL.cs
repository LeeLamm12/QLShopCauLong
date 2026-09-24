using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL dal = new KhachHangDAL();

        public List<KhachHang> LayDanhSach() => dal.LayDanhSach();
        public List<KhachHang> TimKiem(string tuKhoa) => dal.TimKiem(tuKhoa);
        public bool KiemTraTrungMa(string maKhachHang) => dal.KiemTraTonTai(maKhachHang);

        // Trả về mã khách hàng đang trùng SĐT (nếu có), bỏ qua chính khách hàng đang sửa
        public string TimTrungSDT(string sdt, string maKhachHangBoQua = null)
        {
            if (string.IsNullOrWhiteSpace(sdt)) return null;

            var kh = dal.LayDanhSach().FirstOrDefault(x =>
                !string.Equals((x.MaKhachHang ?? "").Trim(), (maKhachHangBoQua ?? "").Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals((x.SoDienThoai ?? "").Trim(), sdt.Trim()));

            return kh?.MaKhachHang;
        }

        public string TimTrungEmail(string email, string maKhachHangBoQua = null)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            var kh = dal.LayDanhSach().FirstOrDefault(x =>
                !string.Equals((x.MaKhachHang ?? "").Trim(), (maKhachHangBoQua ?? "").Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals((x.Email ?? "").Trim(), email.Trim(), StringComparison.OrdinalIgnoreCase));

            return kh?.MaKhachHang;
        }

        public List<string> Validate(KhachHang kh, bool laThemMoi)
        {
            var loi = new List<string>();

            if (ValidationHelper.IsNullOrEmpty(kh.MaKhachHang))
                loi.Add("Mã khách hàng không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(kh.HoTen))
                loi.Add("Họ tên không được để trống.");

            if (string.IsNullOrWhiteSpace(kh.SoDienThoai))
                loi.Add("Số điện thoại không được để trống.");
            else if (!ValidationHelper.IsValidPhone(kh.SoDienThoai))
                loi.Add("Số điện thoại không đúng định dạng (VD: 0901234567).");

            if (!string.IsNullOrWhiteSpace(kh.Email) && !ValidationHelper.IsValidEmail(kh.Email))
                loi.Add("Email không đúng định dạng.");

            if (laThemMoi && KiemTraTrungMa(kh.MaKhachHang))
                loi.Add($"Mã khách hàng '{kh.MaKhachHang}' đã tồn tại.");

            string maBoQua = laThemMoi ? null : kh.MaKhachHang;

            string maTrungSDT = TimTrungSDT(kh.SoDienThoai, maBoQua);
            if (maTrungSDT != null)
                loi.Add($"Số điện thoại '{kh.SoDienThoai}' đã được dùng bởi khách hàng '{maTrungSDT}'.");

            string maTrungEmail = TimTrungEmail(kh.Email, maBoQua);
            if (maTrungEmail != null)
                loi.Add($"Email '{kh.Email}' đã được dùng bởi khách hàng '{maTrungEmail}'.");

            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(KhachHang kh)
        {
            var loi = Validate(kh, laThemMoi: true);
            if (loi.Count > 0) return (false, loi);

            try
            {
                dal.Them(kh);
                return (true, loi);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // vi phạm UNIQUE/PK constraint
            {
                loi.Add("Số điện thoại hoặc Email đã tồn tại trong hệ thống.");
                return (false, loi);
            }
        }

        public (bool ThanhCong, List<string> Loi) Sua(KhachHang kh)
        {
            var loi = Validate(kh, laThemMoi: false);
            if (loi.Count > 0) return (false, loi);

            try
            {
                bool ok = dal.Sua(kh);
                if (!ok) loi.Add("Khách hàng không tồn tại.");
                return (ok, loi);
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                loi.Add("Số điện thoại hoặc Email đã tồn tại trong hệ thống.");
                return (false, loi);
            }
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maKhachHang)
        {
            if (maKhachHang == "KH000")
                return (false, "Không thể xóa khách hàng vãng lai (dùng chung hệ thống).");

            if (dal.DaCoHoaDon(maKhachHang))
                return (false, "Không thể xóa: khách hàng đã có hóa đơn trong hệ thống.");

            if (!dal.KiemTraTonTai(maKhachHang))
                return (false, "Khách hàng không tồn tại.");

            dal.Xoa(maKhachHang);
            return (true, "Xóa thành công.");
        }
    }
}