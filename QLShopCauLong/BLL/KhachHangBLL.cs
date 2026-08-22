using System;
using System.Collections.Generic;
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

        public List<string> Validate(KhachHang kh, bool laThemMoi)
        {
            var loi = new List<string>();
            if (ValidationHelper.IsNullOrEmpty(kh.MaKhachHang))
                loi.Add("Mã khách hàng không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(kh.HoTen))
                loi.Add("Họ tên không được để trống.");
            if (!ValidationHelper.IsValidPhone(kh.SoDienThoai))
                loi.Add("Số điện thoại không đúng định dạng (VD: 0901234567).");
            if (!ValidationHelper.IsValidEmail(kh.Email))
                loi.Add("Email không đúng định dạng.");
            if (laThemMoi && KiemTraTrungMa(kh.MaKhachHang))
                loi.Add($"Mã khách hàng '{kh.MaKhachHang}' đã tồn tại.");
            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(KhachHang kh)
        {
            var loi = Validate(kh, laThemMoi: true);
            if (loi.Count > 0) return (false, loi);

            dal.Them(kh);
            return (true, loi);
        }

        public (bool ThanhCong, List<string> Loi) Sua(KhachHang kh)
        {
            var loi = Validate(kh, laThemMoi: false);
            if (loi.Count > 0) return (false, loi);

            bool ok = dal.Sua(kh);
            if (!ok) loi.Add("Khách hàng không tồn tại.");

            return (ok, loi);
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
