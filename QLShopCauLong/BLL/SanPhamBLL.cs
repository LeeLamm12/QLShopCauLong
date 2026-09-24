// SanPhamBLL.cs — bổ sung
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class SanPhamBLL
    {
        private readonly SanPhamDAL dal = new SanPhamDAL();

        private static readonly Regex RegexMaSanPham = new Regex(@"^SP\d{3}$");

        public List<SanPham> LayDanhSach() => dal.LayDanhSach();

        public List<SanPham> TimKiem(string tuKhoa, string maDanhMuc = null, string thuongHieu = null)
            => dal.TimKiem(tuKhoa, maDanhMuc, thuongHieu);

        public bool KiemTraTrungMa(string maSanPham) => dal.KiemTraTonTai(maSanPham);

        public bool KiemTraDinhDangMa(string maSanPham)
        {
            if (string.IsNullOrEmpty(maSanPham)) return false;
            return RegexMaSanPham.IsMatch(maSanPham.Trim());
        }

        public string SinhMaMoi()
        {
            var dsMa = dal.LayDanhSach()
                .Select(sp => (sp.MaSanPham ?? "").Trim())
                .Where(ma => KiemTraDinhDangMa(ma))
                .Select(ma => int.Parse(ma.Substring(2)))
                .ToList();

            int soTiepTheo = dsMa.Count > 0 ? dsMa.Max() + 1 : 0;

            if (soTiepTheo > 999)
                throw new Exception("Đã hết mã sản phẩm khả dụng (SP000 - SP999).");

            return "SP" + soTiepTheo.ToString("D3");
        }

        // Trả về mã sản phẩm bị trùng (nếu có) khi cùng Tên + Thương hiệu (không phân biệt hoa/thường, đã trim)
        public string TimSanPhamTrungTenVaThuongHieu(string tenSanPham, string thuongHieu, string maSanPhamBoQua = null)
        {
            var sp = dal.LayDanhSach().FirstOrDefault(x =>
                !string.Equals((x.MaSanPham ?? "").Trim(), (maSanPhamBoQua ?? "").Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals((x.TenSanPham ?? "").Trim(), (tenSanPham ?? "").Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals((x.ThuongHieu ?? "").Trim(), (thuongHieu ?? "").Trim(), StringComparison.OrdinalIgnoreCase));

            return sp?.MaSanPham;
        }

        // Nếu thương hiệu người dùng gõ trùng (không phân biệt hoa/thường) với thương hiệu đã có,
        // trả về đúng cách viết cũ để tránh phát sinh 2 thương hiệu na ná nhau ("Yonex" / "yonex").
        public string ChuanHoaThuongHieu(string thuongHieuNhap)
        {
            string nhap = (thuongHieuNhap ?? "").Trim();
            if (string.IsNullOrEmpty(nhap)) return nhap;

            var trungKhongPhanBietHoaThuong = dal.LayDanhSach()
                .Select(sp => sp.ThuongHieu)
                .Where(th => !string.IsNullOrEmpty(th))
                .FirstOrDefault(th => string.Equals(th.Trim(), nhap, StringComparison.OrdinalIgnoreCase));

            return trungKhongPhanBietHoaThuong ?? nhap;
        }

        public List<string> Validate(SanPham sp, bool laThemMoi)
        {
            var loi = new List<string>();

            if (ValidationHelper.IsNullOrEmpty(sp.MaSanPham))
                loi.Add("Mã sản phẩm không được để trống.");
            else if (!KiemTraDinhDangMa(sp.MaSanPham))
                loi.Add("Mã sản phẩm không đúng định dạng. Yêu cầu: SP + 3 chữ số, ví dụ SP000, SP101 (viết hoa 'SP').");

            if (ValidationHelper.IsNullOrEmpty(sp.TenSanPham))
                loi.Add("Tên sản phẩm không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(sp.MaDanhMuc))
                loi.Add("Vui lòng chọn danh mục.");
            if (!ValidationHelper.IsPositiveDecimal(sp.DonGia))
                loi.Add("Đơn giá phải lớn hơn 0.");

            if (laThemMoi && KiemTraTrungMa(sp.MaSanPham))
                loi.Add($"Mã sản phẩm '{sp.MaSanPham}' đã tồn tại.");

            string maTrungTenTH = TimSanPhamTrungTenVaThuongHieu(
                sp.TenSanPham, sp.ThuongHieu,
                maSanPhamBoQua: laThemMoi ? null : sp.MaSanPham);

            if (maTrungTenTH != null)
                loi.Add($"Sản phẩm '{sp.TenSanPham}' của thương hiệu '{sp.ThuongHieu}' đã tồn tại (mã {maTrungTenTH}).");

            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(SanPham sp, List<ChiTietKho> dsSize)
        {
            var loi = Validate(sp, laThemMoi: true);

            if (dsSize == null || dsSize.Count == 0)
                loi.Add("Phải nhập ít nhất 1 size cho sản phẩm.");
            else if (dsSize.Select(s => s.Size).Distinct().Count() != dsSize.Count)
                loi.Add("Có size bị trùng, mỗi size chỉ nhập 1 dòng.");

            if (loi.Count > 0) return (false, loi);

            dal.Them(sp, dsSize);
            return (true, loi);
        }

        public (bool ThanhCong, List<string> Loi) Sua(SanPham sp, List<ChiTietKho> dsSize)
        {
            var loi = Validate(sp, laThemMoi: false);
            if (loi.Count > 0) return (false, loi);

            bool ok = dal.Sua(sp, dsSize);
            if (!ok) loi.Add("Sản phẩm không tồn tại.");

            return (ok, loi);
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maSanPham)
        {
            if (dal.DaXuatHienTrongHoaDon(maSanPham))
                return (false, "Không thể xóa: sản phẩm đã có trong hóa đơn.");

            if (!dal.KiemTraTonTai(maSanPham))
                return (false, "Sản phẩm không tồn tại.");

            dal.Xoa(maSanPham);
            return (true, "Xóa thành công.");
        }
    }
}