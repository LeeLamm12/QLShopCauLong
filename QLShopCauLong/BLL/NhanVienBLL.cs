using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class NhanVienBLL
    {
        private readonly NhanVienDAL dal = new NhanVienDAL();

        public List<NhanVien> LayDanhSach() => dal.LayDanhSach();
        public NhanVien LayTheoMa(string ma) => dal.LayTheoMa(ma);

        public List<string> Validate(NhanVien nv, bool laThemMoi)
        {
            var loi = new List<string>();
            if (ValidationHelper.IsNullOrEmpty(nv.MaNhanVien))
                loi.Add("Mã nhân viên không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(nv.HoTen))
                loi.Add("Họ tên không được để trống.");
            if (!ValidationHelper.IsValidPhone(nv.SoDienThoai))
                loi.Add("Số điện thoại không hợp lệ.");
            if (!ValidationHelper.IsValidEmail(nv.Email))
                loi.Add("Email không hợp lệ.");
            if (nv.Luong <= 0)
                loi.Add("Lương phải lớn hơn 0.");
            if (laThemMoi && dal.KiemTraTonTai(nv.MaNhanVien))
                loi.Add($"Mã nhân viên '{nv.MaNhanVien}' đã tồn tại.");
            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(NhanVien nv)
        {
            var loi = Validate(nv, true);
            if (loi.Count > 0) return (false, loi);
            dal.Them(nv);
            return (true, loi);
        }

        public (bool ThanhCong, List<string> Loi) Sua(NhanVien nv)
        {
            var loi = Validate(nv, false);
            if (loi.Count > 0) return (false, loi);
            bool ok = dal.Sua(nv);
            if (!ok) loi.Add("Nhân viên không tồn tại.");
            return (ok, loi);
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maNV)
        {
            if (!dal.KiemTraTonTai(maNV))
                return (false, "Nhân viên không tồn tại.");
            if (dal.DaCoTaiKhoan(maNV))
                return (false, "Không thể xóa: nhân viên đã có tài khoản đăng nhập.");
            dal.Xoa(maNV);
            return (true, "Xóa thành công.");
        }
    }
}
