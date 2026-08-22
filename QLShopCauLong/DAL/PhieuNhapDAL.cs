using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class PhieuNhapDAL
    {
        public List<PhieuNhap> LayDanhSach()
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.PhieuNhap
                    .Include("NhaCungCap")
                    .Include("NhanVien")
                    .Include("ChiTietPhieuNhap.SanPham")
                    .OrderByDescending(pn => pn.NgayNhap)
                    .ToList();
            }
        }

        public List<PhieuNhap> TimKiem(string tuKhoa, DateTime? tuNgay, DateTime? denNgay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.PhieuNhap
                    .Include("NhaCungCap")
                    .Include("NhanVien")
                    .Include("ChiTietPhieuNhap.SanPham")
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                    query = query.Where(pn => pn.MaPhieuNhap.Contains(tuKhoa)
                                           || pn.NhaCungCap.TenNCC.Contains(tuKhoa));

                if (tuNgay.HasValue)
                    query = query.Where(pn => pn.NgayNhap >= tuNgay.Value);
                if (denNgay.HasValue)
                    query = query.Where(pn => pn.NgayNhap <= denNgay.Value);

                return query.OrderByDescending(pn => pn.NgayNhap).ToList();
            }
        }

        public PhieuNhap LayTheoMa(string maPN)
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.PhieuNhap
                    .Include("ChiTietPhieuNhap.SanPham")
                    .FirstOrDefault(pn => pn.MaPhieuNhap == maPN);
            }
        }

        public bool KiemTraTonTai(string maPN)
        {
            using (var db = new QLShopCauLongEntities())
                return db.PhieuNhap.Any(pn => pn.MaPhieuNhap == maPN);
        }

        /// <summary>
        /// Thêm phiếu nhập + chi tiết + cộng tồn kho (hoặc tạo mới nếu chưa có size)
        /// </summary>
        public void Them(PhieuNhap pn, List<ChiTietPhieuNhap> chiTiet)
        {
            using (var db = new QLShopCauLongEntities())
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    db.PhieuNhap.Add(pn);
                    db.SaveChanges();

                    int stt = 1;
                    foreach (var ct in chiTiet)
                    {
                        ct.MaCTPN = pn.MaPhieuNhap + "_" + stt.ToString("00");
                        ct.MaPhieuNhap = pn.MaPhieuNhap;
                        db.ChiTietPhieuNhap.Add(ct);

                        // Cập nhật tồn kho
                        var kho = db.ChiTietKho.FirstOrDefault(k =>
                            k.MaSanPham == ct.MaSanPham && k.Size == ct.Size);

                        if (kho != null)
                        {
                            kho.SoLuongTon += ct.SoLuong;
                        }
                        else
                        {
                            // Tạo mã CTK tự động
                            int maxId = db.ChiTietKho.Count() + stt;
                            string maCTK = "CTK" + maxId.ToString("000");

                            db.ChiTietKho.Add(new ChiTietKho
                            {
                                MaCTKho = maCTK,
                                MaSanPham = ct.MaSanPham,
                                Size = ct.Size,
                                SoLuongTon = ct.SoLuong
                            });
                        }
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

        public void Xoa(string maPN)
        {
            using (var db = new QLShopCauLongEntities())
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    var pn = db.PhieuNhap.Include("ChiTietPhieuNhap")
                                         .FirstOrDefault(p => p.MaPhieuNhap == maPN);
                    if (pn == null) return;

                    // Trừ lại tồn kho
                    foreach (var ct in pn.ChiTietPhieuNhap.ToList())
                    {
                        var kho = db.ChiTietKho.FirstOrDefault(k =>
                            k.MaSanPham == ct.MaSanPham && k.Size == ct.Size);
                        if (kho != null)
                        {
                            kho.SoLuongTon -= ct.SoLuong;
                            if (kho.SoLuongTon < 0) kho.SoLuongTon = 0;
                        }
                        db.ChiTietPhieuNhap.Remove(ct);
                    }

                    db.PhieuNhap.Remove(pn);
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

        public List<PhieuNhap> TimKiemNangCao(string tuKhoa, DateTime? tuNgay, DateTime? denNgay,
                                      string maNCC, string maNhanVien)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.PhieuNhap
                    .Include("NhaCungCap")
                    .Include("NhanVien")
                    .Include("ChiTietPhieuNhap.SanPham")
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                    query = query.Where(pn => pn.MaPhieuNhap.Contains(tuKhoa)
                                           || pn.NhaCungCap.TenNCC.Contains(tuKhoa));

                if (tuNgay.HasValue)
                    query = query.Where(pn => pn.NgayNhap >= tuNgay.Value);
                if (denNgay.HasValue)
                    query = query.Where(pn => pn.NgayNhap <= denNgay.Value);

                if (!string.IsNullOrWhiteSpace(maNCC))
                    query = query.Where(pn => pn.MaNCC == maNCC);

                if (!string.IsNullOrWhiteSpace(maNhanVien))
                    query = query.Where(pn => pn.MaNhanVien == maNhanVien);

                return query.OrderByDescending(pn => pn.NgayNhap).ToList();
            }
        }
    }
}
