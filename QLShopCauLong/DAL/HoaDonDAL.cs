using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<HoaDon> TimKiem(string tuKhoa, DateTime? tuNgay, DateTime? denNgay)
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

                if (tuNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap >= tuNgay.Value);

                if (denNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap <= denNgay.Value);

                return query.OrderByDescending(hd => hd.NgayLap).ToList();
            }
        }

        public HoaDon LayTheoMa(string maHD)
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.HoaDon
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
                        ct.MaChiTietHD = hd.MaHoaDon + "_" + stt.ToString("00");
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
        public List<HoaDon> TimKiemNangCao(string tuKhoa, DateTime? tuNgay, DateTime? denNgay,
                                           string maNhanVien, string phuongThucTT)
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

                if (tuNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap >= tuNgay.Value);

                if (denNgay.HasValue)
                    query = query.Where(hd => hd.NgayLap <= denNgay.Value);

                if (!string.IsNullOrWhiteSpace(maNhanVien))
                    query = query.Where(hd => hd.MaNhanVien == maNhanVien);

                if (!string.IsNullOrWhiteSpace(phuongThucTT))
                    query = query.Where(hd => hd.PhuongThucThanhToan == phuongThucTT);

                return query.OrderByDescending(hd => hd.NgayLap).ToList();
            }
        }
    }
}
