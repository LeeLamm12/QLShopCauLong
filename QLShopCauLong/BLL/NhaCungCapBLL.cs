using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class NhaCungCapBLL
    {
        private readonly NhaCungCapDAL dal = new NhaCungCapDAL();

        public List<NhaCungCap> LayDanhSach() => dal.LayDanhSach();
        public NhaCungCap LayTheoMa(string ma) => dal.LayTheoMa(ma);

        public List<string> Validate(NhaCungCap ncc, bool laThemMoi, string maNCCLoaiTru = null)
        {
            var loi = new List<string>();
            if (ValidationHelper.IsNullOrEmpty(ncc.MaNCC))
                loi.Add("Mã NCC không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(ncc.TenNCC))
                loi.Add("Tên NCC không được để trống.");

            if (ValidationHelper.IsNullOrEmpty(ncc.SoDienThoai))
                loi.Add("Số điện thoại nhà cung cấp không được để trống.");
            else if (!ValidationHelper.IsValidPhone(ncc.SoDienThoai))
                loi.Add("Số điện thoại không hợp lệ.");

            if (!ValidationHelper.IsValidEmail(ncc.Email))
                loi.Add("Email không hợp lệ.");
            if (laThemMoi && dal.KiemTraTonTai(ncc.MaNCC))
                loi.Add($"Mã NCC '{ncc.MaNCC}' đã tồn tại.");

            if (!string.IsNullOrWhiteSpace(ncc.SoDienThoai) && dal.KiemTraTrungSDT(ncc.SoDienThoai, maNCCLoaiTru))
                loi.Add($"Số điện thoại '{ncc.SoDienThoai}' đã được dùng bởi nhà cung cấp khác.");

            if (!string.IsNullOrWhiteSpace(ncc.Email) && dal.KiemTraTrungEmail(ncc.Email, maNCCLoaiTru))
                loi.Add($"Email '{ncc.Email}' đã được dùng bởi nhà cung cấp khác.");

            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(NhaCungCap ncc)
        {
            var loi = Validate(ncc, true, maNCCLoaiTru: null);
            if (loi.Count > 0) return (false, loi);
            dal.Them(ncc);
            return (true, loi);
        }

        public (bool ThanhCong, List<string> Loi) Sua(NhaCungCap ncc)
        {
            var loi = Validate(ncc, false, maNCCLoaiTru: ncc.MaNCC);
            if (loi.Count > 0) return (false, loi);
            bool ok = dal.Sua(ncc);
            if (!ok) loi.Add("NCC không tồn tại.");
            return (ok, loi);
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maNCC)
        {
            if (!dal.KiemTraTonTai(maNCC))
                return (false, "NCC không tồn tại.");
            if (dal.DaCoPhieuNhap(maNCC))
                return (false, "Không thể xóa: NCC đã có phiếu nhập.");
            dal.Xoa(maNCC);
            return (true, "Xóa thành công.");
        }

        public bool KiemTraTrungSDT(string sdt, string maNCCLoaiTru = null) => dal.KiemTraTrungSDT(sdt, maNCCLoaiTru);

        public bool KiemTraTrungEmail(string email, string maNCCLoaiTru = null) => dal.KiemTraTrungEmail(email, maNCCLoaiTru);
    }
}