using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL dal = new DashboardDAL();

        public decimal TongDoanhThu() => dal.TongDoanhThu();
        public int TongSoHoaDon() => dal.TongSoHoaDon();
        public int TongSoSanPham() => dal.TongSoSanPham();
        public int TongSoNhanVien() => dal.TongSoNhanVien();

        public List<(DateTime Ngay, decimal DoanhThu)> DoanhThu7NgayGanNhat()
            => dal.DoanhThu7NgayGanNhat();

        public List<(string PhuongThuc, decimal TongTien, int SoLuong)> PhuongThucThanhToan()
            => dal.PhuongThucThanhToan();

        public List<(string TenSP, int SoLuongBan)> TopSanPhamBanChay(int top = 5)
            => dal.TopSanPhamBanChay(top);

        public List<(string HoTen, decimal DoanhThu)> DoanhThuTheoNhanVien()
            => dal.DoanhThuTheoNhanVien();

        public (int SoHoaDon, decimal DoanhThu) ThongKeCaTruc(string maNV, DateTime ngay)
            => dal.ThongKeCaTruc(maNV, ngay);
    }
}
