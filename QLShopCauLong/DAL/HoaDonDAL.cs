using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.BLL.DTO;

namespace QLShopCauLong.DAL
{
    public class HoaDonDAL
    {
        public List<HoaDon> LayDanhSach()
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.HoaDon
                    .Include("KhachHang")
                    .Include("NhanVien")
                    .Include("ChiTietHoaDon.SanPham")
                    .OrderByDescending(hd => hd.NgayLap)
                    .ToList();
            }
        }

        public List<HoaDon> TimKiem(string tuKhoa)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.HoaDon
                    .Include("KhachHang")
                    .Include("NhanVien")
                    .Include("ChiTietHoaDon.SanPham")
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                    query = query.Where(hd => hd.MaHoaDon.Contains(tuKhoa)
                                           || hd.KhachHang.HoTen.Contains(tuKhoa));

                return query.OrderByDescending(hd => hd.NgayLap).ToList();
            }
        }

        public HoaDon LayTheoMa(string maHD)
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.HoaDon
                    .Include("KhachHang")
                    .Include("NhanVien")
                    .Include("ChiTietHoaDon.SanPham")
                    .FirstOrDefault(hd => hd.MaHoaDon == maHD);
            }
        }

        public bool KiemTraTonTai(string maHD)
        {
            using (var db = new QLShopCauLongEntities())
                return db.HoaDon.Any(hd => hd.MaHoaDon == maHD);
        }

        /// <summary>
        /// Thêm hóa đơn + chi tiết + trừ tồn kho
        /// </summary>
        public void Them(HoaDon hd, List<ChiTietHoaDon> chiTiet)
        {
            using (var db = new QLShopCauLongEntities())
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.HoaDon.Add(hd);
                    db.SaveChanges(); // có MaHoaDon

                    int stt = 1;
                    foreach (var ct in chiTiet)
                    {
                        ct.MaChiTietHD = "CT" + DateTime.Now.ToString("HHmmss") + stt.ToString("D2");
                        ct.MaHoaDon = hd.MaHoaDon;
                        db.ChiTietHoaDon.Add(ct);

                        // Trừ tồn kho
                        var kho = db.ChiTietKho.FirstOrDefault(k =>
                            k.MaSanPham == ct.MaSanPham && k.Size == ct.Size);

                        if (kho == null)
                            throw new Exception($"Sản phẩm {ct.MaSanPham} size {ct.Size} không có trong kho.");

                        if (kho.SoLuongTon < ct.SoLuong)
                            throw new Exception($"Sản phẩm {ct.MaSanPham} size {ct.Size} chỉ còn {kho.SoLuongTon} cái.");

                        kho.SoLuongTon -= ct.SoLuong;
                        stt++;
                    }

                    db.SaveChanges();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Xóa hóa đơn + hoàn trả tồn kho
        /// </summary>
        public void Xoa(string maHD)
        {
            using (var db = new QLShopCauLongEntities())
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var hd = db.HoaDon.Include("ChiTietHoaDon").FirstOrDefault(h => h.MaHoaDon == maHD);
                    if (hd == null) return;

                    // Hoàn trả tồn kho
                    foreach (var ct in hd.ChiTietHoaDon.ToList())
                    {
                        var kho = db.ChiTietKho.FirstOrDefault(k =>
                            k.MaSanPham == ct.MaSanPham && k.Size == ct.Size);
                        if (kho != null)
                            kho.SoLuongTon += ct.SoLuong;

                        db.ChiTietHoaDon.Remove(ct);
                    }

                    db.HoaDon.Remove(hd);
                    db.SaveChanges();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Tìm kiếm nâng cao: theo ngày + nhân viên + phương thức TT
        /// </summary>
        public List<HoaDon> TimKiemNangCao(string tuKhoa, string maNhanVien, string phuongThucTT)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.HoaDon
                    .Include("KhachHang")
                    .Include("NhanVien")
                    .Include("ChiTietHoaDon.SanPham")
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                    query = query.Where(hd => hd.MaHoaDon.Contains(tuKhoa)
                                           || hd.KhachHang.HoTen.Contains(tuKhoa));

                if (!string.IsNullOrWhiteSpace(maNhanVien))
                    query = query.Where(hd => hd.MaNhanVien == maNhanVien);

                var result = query.OrderByDescending(hd => hd.NgayLap).ToList();

                // Lọc PTTT ở client để tránh lỗi padding/khoảng trắng từ cột kiểu char/nchar
                if (!string.IsNullOrWhiteSpace(phuongThucTT))
                {
                    string p = phuongThucTT.Trim();
                    result = result.Where(hd => hd.PhuongThucThanhToan != null
                                              && hd.PhuongThucThanhToan.Trim() == p).ToList();
                }

                return result;
            }
        }

        /// <summary>
        /// Lấy doanh thu theo từng ngày trong khoảng thời gian (cho line chart Dashboard)
        /// </summary>
        public List<ThongKeDoanhThuDTO> LayDoanhThuTheoNgay()
        {
            using (var db = new QLShopCauLongEntities())
            {
                var rawData = db.HoaDon
                    .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                    .Select(g => new
                    {
                        Ngay = g.Key.Value,
                        TongDoanhThu = g.Sum(x => x.TongTien) ?? 0,
                        SoLuong = g.Count()
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                return rawData.Select(x => new ThongKeDoanhThuDTO
                {
                    ThoiGian = x.Ngay.ToString("dd/MM/yyyy"),
                    DoanhThu = x.TongDoanhThu,
                    SoLuongHoaDon = x.SoLuong
                }).ToList();
            }
        }

        public List<ThongKeNhanVienDTO> LayDoanhThuTheoNhanVien()
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.HoaDon
                    .Include("NhanVien")
                    .GroupBy(hd => new { hd.MaNhanVien, hd.NhanVien.HoTen })
                    .Select(g => new ThongKeNhanVienDTO
                    {
                        MaNhanVien = g.Key.MaNhanVien,
                        HoTen = g.Key.HoTen,
                        SoHoaDon = g.Count(),
                        DoanhThu = g.Sum(x => x.TongTien) ?? 0
                    })
                    .OrderByDescending(x => x.DoanhThu)
                    .Take(5)
                    .ToList();
            }
        }
    }
}
