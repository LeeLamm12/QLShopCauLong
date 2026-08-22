using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.BLL.DTO;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class ThongKeBLL
    {
        private readonly ThongKeDAL dal = new ThongKeDAL();

        // Doanh thu
        public List<ThongKeDoanhThuDTO> DoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
            => dal.DoanhThuTheoNgay(tuNgay, denNgay);

        public List<ThongKeDoanhThuDTO> DoanhThuTheoThang(int nam)
            => dal.DoanhThuTheoThang(nam);

        public List<ThongKeDoanhThuDTO> DoanhThuTheoNam()
            => dal.DoanhThuTheoNam();

        public (decimal TongDoanhThu, int TongHoaDon) TongKetDoanhThu(DateTime? tuNgay, DateTime? denNgay)
            => dal.TongKetDoanhThu(tuNgay, denNgay);

        // Sản phẩm
        public List<ThongKeSanPhamBanChayDTO> SanPhamBanChay(DateTime? tuNgay, DateTime? denNgay, int top = 10)
            => dal.SanPhamBanChay(tuNgay, denNgay, top);

        // Tồn kho
        public List<ThongKeTonKhoDTO> ThongKeTonKho(string maDanhMuc = null, string tuKhoa = null)
            => dal.ThongKeTonKho(maDanhMuc, tuKhoa);

        public List<ThongKeTonKhoDTO> SanPhamSapHetHang(int nguong = 5)
            => dal.SanPhamSapHetHang(nguong);

        // Nhập hàng
        public List<ThongKeNhapHangDTO> ThongKeNhapTheoNCC(DateTime? tuNgay, DateTime? denNgay)
            => dal.ThongKeNhapTheoNCC(tuNgay, denNgay);

        // Phương thức thanh toán (Pie chart)
        public List<ThongKePhuongThucTTDTO> ThongKePhuongThucTT(DateTime? tuNgay, DateTime? denNgay)
            => dal.ThongKePhuongThucTT(tuNgay, denNgay);

        // Nhân viên (Bar chart)
        public List<ThongKeNhanVienDTO> DoanhThuTheoNhanVien(DateTime? tuNgay, DateTime? denNgay)
            => dal.DoanhThuTheoNhanVien(tuNgay, denNgay);

        // Dashboard card
        public DashboardCardDTO LaySoLieuDashboard()
            => dal.LaySoLieuDashboard();

        // Ca trực nhân viên
        public (int SoHoaDon, decimal DoanhThu) ThongKeCaTruc(string maNV, DateTime ngay)
            => dal.ThongKeCaTruc(maNV, ngay);
    }
}
