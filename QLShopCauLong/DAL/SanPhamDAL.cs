using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class SanPhamDAL
    {
        public List<SanPham> LayDanhSach()
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.SanPham.Include("DanhMuc").Include("ChiTietKho")
                                  .OrderBy(sp => sp.MaSanPham).ToList();
            }
        }

        public List<SanPham> TimKiem(string tuKhoa, string maDanhMuc, string thuongHieu)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.SanPham.Include("DanhMuc").Include("ChiTietKho").AsQueryable();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                    query = query.Where(sp => sp.TenSanPham.Contains(tuKhoa) || sp.MaSanPham.Contains(tuKhoa));

                if (!string.IsNullOrWhiteSpace(maDanhMuc))
                    query = query.Where(sp => sp.MaDanhMuc == maDanhMuc);

                if (!string.IsNullOrWhiteSpace(thuongHieu))
                    query = query.Where(sp => sp.ThuongHieu == thuongHieu);

                return query.ToList();
            }
        }

        public bool KiemTraTonTai(string maSanPham)
        {
            using (var db = new QLShopCauLongEntities())
                return db.SanPham.Any(sp => sp.MaSanPham == maSanPham);
        }

        public bool DaXuatHienTrongHoaDon(string maSanPham)
        {
            using (var db = new QLShopCauLongEntities())
                return db.ChiTietHoaDon.Any(ct => ct.MaSanPham == maSanPham);
        }

        public void Them(SanPham sp, List<ChiTietKho> dsSize)
        {
            using (var db = new QLShopCauLongEntities())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.SanPham.Add(sp);
                    db.SaveChanges(); // lưu SanPham trước để có MaSanPham cho FK

                    int stt = 1;
                    foreach (var ct in dsSize)
                    {
                        ct.MaCTKho = sp.MaSanPham + "_" + stt.ToString("00");
                        ct.MaSanPham = sp.MaSanPham;
                        db.ChiTietKho.Add(ct);
                        stt++;
                    }
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public bool Sua(SanPham sp, List<ChiTietKho> dsSize)
        {
            using (var db = new QLShopCauLongEntities())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var spCu = db.SanPham.Find(sp.MaSanPham);
                    if (spCu == null)
                    {
                        transaction.Rollback();
                        return false;
                    }

                    spCu.TenSanPham = sp.TenSanPham;
                    spCu.MaDanhMuc = sp.MaDanhMuc;
                    spCu.ThuongHieu = sp.ThuongHieu;
                    spCu.DonGia = sp.DonGia;
                    if (!string.IsNullOrWhiteSpace(sp.HinhAnh))
                        spCu.HinhAnh = sp.HinhAnh;

                    var sizeCu = db.ChiTietKho.Where(c => c.MaSanPham == sp.MaSanPham).ToList();
                    db.ChiTietKho.RemoveRange(sizeCu);
                    db.SaveChanges();

                    int stt = 1;
                    foreach (var ct in dsSize)
                    {
                        ct.MaCTKho = sp.MaSanPham + "_" + stt.ToString("00");
                        ct.MaSanPham = sp.MaSanPham;
                        db.ChiTietKho.Add(ct);
                        stt++;
                    }
                    db.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Xoa(string maSanPham)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var sizeCu = db.ChiTietKho.Where(c => c.MaSanPham == maSanPham).ToList();
                db.ChiTietKho.RemoveRange(sizeCu);

                var sp = db.SanPham.Find(maSanPham);
                if (sp != null)
                    db.SanPham.Remove(sp);

                db.SaveChanges();
            }
        }
    }
}
