using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.BLL.DTO;

namespace QLShopCauLong.DAL
{
    public class ThongKeDAL
    {
        // ========== DOANH THU ==========

        public List<ThongKeDoanhThuDTO> DoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                // Query ra anonymous type trước, rồi ToList(), rồi mới format string
                var raw = db.HoaDon
                    .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay)
                    .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                    .Select(g => new
                    {
                        Ngay = g.Key.Value,
                        DoanhThu = g.Sum(hd => hd.TongTien) ?? 0,
                        SoLuongHoaDon = g.Count()
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                return raw.Select(x => new ThongKeDoanhThuDTO
                {
                    ThoiGian = x.Ngay.ToString("dd/MM/yyyy"),
                    DoanhThu = x.DoanhThu,
                    SoLuongHoaDon = x.SoLuongHoaDon
                }).ToList();
            }
        }

        public List<ThongKeDoanhThuDTO> DoanhThuTheoThang(int nam)
        {
            using (var db = new QLShopCauLongEntities())
            {
                // Query raw trước, ToList() rồi mới format string
                var raw = db.HoaDon
                    .Where(hd => hd.NgayLap.Value.Year == nam)
                    .GroupBy(hd => hd.NgayLap.Value.Month)
                    .Select(g => new
                    {
                        Thang = g.Key,
                        DoanhThu = g.Sum(hd => hd.TongTien) ?? 0,
                        SoLuongHoaDon = g.Count()
                    })
                    .OrderBy(x => x.Thang)
                    .ToList();

                return raw.Select(x => new ThongKeDoanhThuDTO
                {
                    ThoiGian = x.Thang.ToString("00") + "/" + nam,
                    DoanhThu = x.DoanhThu,
                    SoLuongHoaDon = x.SoLuongHoaDon
                }).ToList();
            }
        }

        public List<ThongKeDoanhThuDTO> DoanhThuTheoNam()
        {
            using (var db = new QLShopCauLongEntities())
            {
                var raw = db.HoaDon
                    .GroupBy(hd => hd.NgayLap.Value.Year)
                    .Select(g => new
                    {
                        Nam = g.Key,
                        DoanhThu = g.Sum(hd => hd.TongTien) ?? 0,
                        SoLuongHoaDon = g.Count()
                    })
                    .OrderBy(x => x.Nam)
                    .ToList();

                return raw.Select(x => new ThongKeDoanhThuDTO
                {
                    ThoiGian = x.Nam.ToString(),
                    DoanhThu = x.DoanhThu,
                    SoLuongHoaDon = x.SoLuongHoaDon
                }).ToList();
            }
        }

        public (decimal TongDoanhThu, int TongHoaDon) TongKetDoanhThu(DateTime? tuNgay, DateTime? denNgay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.HoaDon.AsQueryable();
                if (tuNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap >= tuNgay.Value);
                if (denNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap <= denNgay.Value);

                var tongDT = query.Sum(hd => (decimal?)hd.TongTien) ?? 0;
                var tongHD = query.Count();
                return (tongDT, tongHD);
            }
        }

        // ========== SẢN PHẨM ==========

        public List<ThongKeSanPhamBanChayDTO> SanPhamBanChay(DateTime? tuNgay, DateTime? denNgay, int top = 10)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.ChiTietHoaDon.AsQueryable();

                if (tuNgay.HasValue)
                    query = query.Where(ct => ct.HoaDon.NgayLap >= tuNgay.Value);
                if (denNgay.HasValue)
                    query = query.Where(ct => ct.HoaDon.NgayLap <= denNgay.Value);

                return query
                    .GroupBy(ct => ct.MaSanPham)
                    .Select(g => new ThongKeSanPhamBanChayDTO
                    {
                        MaSanPham = g.Key,
                        TenSanPham = g.FirstOrDefault().SanPham.TenSanPham,
                        ThuongHieu = g.FirstOrDefault().SanPham.ThuongHieu,
                        TongSoLuongBan = g.Sum(ct => ct.SoLuong),
                        TongDoanhThu = g.Sum(ct => ct.SoLuong * ct.DonGia)
                    })
                    .OrderByDescending(x => x.TongSoLuongBan)
                    .Take(top)
                    .ToList();
            }
        }

        // ========== TỒN KHO ==========

        public List<ThongKeTonKhoDTO> ThongKeTonKho(string maDanhMuc = null, string tuKhoa = null)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.ChiTietKho.AsQueryable();

                if (!string.IsNullOrWhiteSpace(maDanhMuc))
                    query = query.Where(k => k.SanPham.MaDanhMuc == maDanhMuc);

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                    query = query.Where(k => k.SanPham.TenSanPham.Contains(tuKhoa)
                                          || k.SanPham.MaSanPham.Contains(tuKhoa));

                return query
                    .Select(k => new ThongKeTonKhoDTO
                    {
                        MaSanPham = k.MaSanPham,
                        TenSanPham = k.SanPham.TenSanPham,
                        TenDanhMuc = k.SanPham.DanhMuc.TenDanhMuc,
                        Size = k.Size,
                        SoLuongTon = k.SoLuongTon
                    })
                    .OrderBy(x => x.MaSanPham)
                    .ToList();
            }
        }

        public List<ThongKeTonKhoDTO> SanPhamSapHetHang(int nguong = 5)
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.ChiTietKho
                    .Where(k => k.SoLuongTon <= nguong)
                    .Select(k => new ThongKeTonKhoDTO
                    {
                        MaSanPham = k.MaSanPham,
                        TenSanPham = k.SanPham.TenSanPham,
                        TenDanhMuc = k.SanPham.DanhMuc.TenDanhMuc,
                        Size = k.Size,
                        SoLuongTon = k.SoLuongTon
                    })
                    .OrderBy(x => x.SoLuongTon)
                    .ToList();
            }
        }

        // ========== NHẬP HÀNG ==========

        public List<ThongKeNhapHangDTO> ThongKeNhapTheoNCC(DateTime? tuNgay, DateTime? denNgay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.PhieuNhap.AsQueryable();

                if (tuNgay.HasValue)
                    query = query.Where(pn => pn.NgayNhap >= tuNgay.Value);
                if (denNgay.HasValue)
                    query = query.Where(pn => pn.NgayNhap <= denNgay.Value);

                return query
                    .GroupBy(pn => pn.MaNCC)
                    .Select(g => new ThongKeNhapHangDTO
                    {
                        MaNCC = g.Key,
                        TenNCC = g.FirstOrDefault().NhaCungCap.TenNCC,
                        SoPhieuNhap = g.Count(),
                        TongTienNhap = g.Sum(pn => pn.TongTien) ?? 0
                    })
                    .OrderByDescending(x => x.TongTienNhap)
                    .ToList();
            }
        }

        // ========== PHƯƠNG THỨC THANH TOÁN ==========

        public List<ThongKePhuongThucTTDTO> ThongKePhuongThucTT(DateTime? tuNgay, DateTime? denNgay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.HoaDon.AsQueryable();
                if (tuNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap >= tuNgay.Value);
                if (denNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap <= denNgay.Value);

                var raw = query
                    .GroupBy(hd => hd.PhuongThucThanhToan)
                    .Select(g => new { PTTT = g.Key, TongTien = g.Sum(hd => hd.TongTien) ?? 0, SoLuong = g.Count() })
                    .ToList();

                decimal tong = raw.Sum(x => x.TongTien);
                return raw.Select(x => new ThongKePhuongThucTTDTO
                {
                    PhuongThuc = x.PTTT,
                    TongTien = x.TongTien,
                    SoLuong = x.SoLuong,
                    TyLePhanTram = tong > 0 ? (double)(x.TongTien / tong * 100) : 0
                }).ToList();
            }
        }

        // ========== NHÂN VIÊN ==========

        public List<ThongKeNhanVienDTO> DoanhThuTheoNhanVien(DateTime? tuNgay, DateTime? denNgay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.HoaDon.AsQueryable();
                if (tuNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap >= tuNgay.Value);
                if (denNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap <= denNgay.Value);

                return query
                    .GroupBy(hd => hd.MaNhanVien)
                    .Select(g => new ThongKeNhanVienDTO
                    {
                        MaNhanVien = g.Key,
                        HoTen = g.FirstOrDefault().NhanVien.HoTen,
                        SoHoaDon = g.Count(),
                        DoanhThu = g.Sum(hd => hd.TongTien) ?? 0
                    })
                    .OrderByDescending(x => x.DoanhThu)
                    .ToList();
            }
        }

        // ========== DASHBOARD CARD ==========

        public DashboardCardDTO LaySoLieuDashboard()
        {
            using (var db = new QLShopCauLongEntities())
            {
                return new DashboardCardDTO
                {
                    TongDoanhThu = db.HoaDon.Sum(hd => (decimal?)hd.TongTien) ?? 0,
                    TongHoaDon = db.HoaDon.Count(),
                    TongSanPham = db.SanPham.Count(),
                    TongNhanVien = db.NhanVien.Count()
                };
            }
        }

        // ========== NHÂN VIÊN CA TRỰC ==========

        public (int SoHoaDon, decimal DoanhThu) ThongKeCaTruc(string maNV, DateTime ngay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.HoaDon.Where(hd => hd.MaNhanVien == maNV);
                var tu = ngay.Date;
                var den = ngay.Date.AddDays(1).AddSeconds(-1);
                query = query.Where(hd => hd.NgayLap >= tu && hd.NgayLap <= den);

                return (query.Count(), query.Sum(hd => (decimal?)hd.TongTien) ?? 0);
            }
        }
    }
}
