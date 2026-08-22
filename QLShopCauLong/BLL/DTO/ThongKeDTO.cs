using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.BLL.DTO
{
    public class ThongKeDoanhThuDTO
    {
        public string ThoiGian { get; set; }      // "dd/MM/yyyy" hoặc "MM/yyyy"
        public decimal DoanhThu { get; set; }
        public int SoLuongHoaDon { get; set; }
    }

    public class ThongKeSanPhamBanChayDTO
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string ThuongHieu { get; set; }
        public int TongSoLuongBan { get; set; }
        public decimal TongDoanhThu { get; set; }
    }

    public class ThongKeTonKhoDTO
    {
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string TenDanhMuc { get; set; }
        public int? Size { get; set; }
        public int SoLuongTon { get; set; }
    }

    public class ThongKeNhapHangDTO
    {
        public string MaNCC { get; set; }
        public string TenNCC { get; set; }
        public int SoPhieuNhap { get; set; }
        public decimal TongTienNhap { get; set; }
    }

    public class ThongKePhuongThucTTDTO
    {
        public string PhuongThuc { get; set; }
        public decimal TongTien { get; set; }
        public int SoLuong { get; set; }
        public double TyLePhanTram { get; set; }
    }

    public class ThongKeNhanVienDTO
    {
        public string MaNhanVien { get; set; }
        public string HoTen { get; set; }
        public int SoHoaDon { get; set; }
        public decimal DoanhThu { get; set; }
    }

    public class DashboardCardDTO
    {
        public decimal TongDoanhThu { get; set; }
        public int TongHoaDon { get; set; }
        public int TongSanPham { get; set; }
        public int TongNhanVien { get; set; }
    }
}
