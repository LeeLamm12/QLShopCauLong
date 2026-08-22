using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class DashboardDAL
    {
        // ===== CARD TỔNG QUAN (Admin) =====
        public decimal TongDoanhThu()
        {
            using (var db = new QLShopCauLongEntities())
                return db.HoaDon.Sum(hd => (decimal?)hd.TongTien) ?? 0;
        }

        public int TongSoHoaDon()
        {
            using (var db = new QLShopCauLongEntities())
                return db.HoaDon.Count();
        }

        public int TongSoSanPham()
        {
            using (var db = new QLShopCauLongEntities())
                return db.SanPham.Count();
        }

        public int TongSoNhanVien()
        {
            using (var db = new QLShopCauLongEntities())
                return db.NhanVien.Count();
        }

        // ===== DOANH THU THEO NGÀY (biểu đồ đường) =====
        public List<(DateTime Ngay, decimal DoanhThu)> DoanhThu7NgayGanNhat()
        {
            using (var db = new QLShopCauLongEntities())
            {
                var denNgay = DateTime.Now.Date;
                var tuNgay = denNgay.AddDays(-6);

                return db.HoaDon
                    .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay)
                    .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                    .Select(g => new
                    {
                        Ngay = g.Key.Value,
                        DoanhThu = g.Sum(hd => hd.TongTien) ?? 0
                    })
                    .ToList()
                    .Select(x => (x.Ngay, x.DoanhThu))
                    .ToList();
            }
        }

        // ===== PHƯƠNG THỨC THANH TOÁN (Pie Chart) =====
        public List<(string PhuongThuc, decimal TongTien, int SoLuong)> PhuongThucThanhToan()
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.HoaDon
                    .GroupBy(hd => hd.PhuongThucThanhToan)
                    .Select(g => new
                    {
                        PhuongThuc = g.Key,
                        TongTien = g.Sum(hd => hd.TongTien) ?? 0,
                        SoLuong = g.Count()
                    })
                    .ToList()
                    .Select(x => (x.PhuongThuc, x.TongTien, x.SoLuong))
                    .ToList();
            }
        }

        // ===== TOP SẢN PHẨM BÁN CHẠY (Bar Chart) =====
        public List<(string TenSP, int SoLuongBan)> TopSanPhamBanChay(int top = 5)
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.ChiTietHoaDon
                    .GroupBy(ct => ct.MaSanPham)
                    .Select(g => new
                    {
                        MaSP = g.Key,
                        TongSL = g.Sum(ct => ct.SoLuong)
                    })
                    .OrderByDescending(x => x.TongSL)
                    .Take(top)
                    .ToList()
                    .Select(x => (
                        db.SanPham.FirstOrDefault(sp => sp.MaSanPham == x.MaSP)?.TenSanPham ?? x.MaSP,
                        x.TongSL
                    ))
                    .ToList();
            }
        }

        // ===== DOANH THU THEO NHÂN VIÊN (Bar Chart) =====
        public List<(string HoTen, decimal DoanhThu)> DoanhThuTheoNhanVien()
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.HoaDon
                    .GroupBy(hd => hd.MaNhanVien)
                    .Select(g => new
                    {
                        MaNV = g.Key,
                        DoanhThu = g.Sum(hd => hd.TongTien) ?? 0
                    })
                    .ToList()
                    .Select(x => (
                        db.NhanVien.FirstOrDefault(nv => nv.MaNhanVien == x.MaNV)?.HoTen ?? x.MaNV,
                        x.DoanhThu
                    ))
                    .OrderByDescending(x => x.DoanhThu)
                    .ToList();
            }
        }

        // ===== CHO NHÂN VIÊN: Thống kê ca trực =====
        public (int SoHoaDon, decimal DoanhThu) ThongKeCaTruc(string maNV, DateTime ngay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.HoaDon.Where(hd => hd.MaNhanVien == maNV);
                if (ngay != DateTime.MinValue)
                    query = query.Where(hd => hd.NgayLap.Value.Year == ngay.Year
                                           && hd.NgayLap.Value.Month == ngay.Month
                                           && hd.NgayLap.Value.Day == ngay.Day);

                var soHD = query.Count();
                var dt = query.Sum(hd => (decimal?)hd.TongTien) ?? 0;
                return (soHD, dt);
            }
        }
    }
}
