using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class KhachHangDAL
    {
        public List<KhachHang> LayDanhSach()
        {
            using (var db = new QLShopCauLongEntities())
                return db.KhachHang.OrderBy(k => k.MaKhachHang).ToList();
        }

        public List<KhachHang> TimKiem(string tuKhoa)
        {
            using (var db = new QLShopCauLongEntities())
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                    return db.KhachHang.ToList();
                return db.KhachHang
                    .Where(k => k.HoTen.Contains(tuKhoa) || k.SoDienThoai.Contains(tuKhoa))
                    .ToList();
            }
        }

        public bool KiemTraTonTai(string maKhachHang)
        {
            using (var db = new QLShopCauLongEntities())
                return db.KhachHang.Any(k => k.MaKhachHang == maKhachHang);
        }

        public bool DaCoHoaDon(string maKhachHang)
        {
            using (var db = new QLShopCauLongEntities())
                return db.HoaDon.Any(hd => hd.MaKhachHang == maKhachHang);
        }

        public void Them(KhachHang kh)
        {
            using (var db = new QLShopCauLongEntities())
            {
                db.KhachHang.Add(kh);
                db.SaveChanges();
            }
        }

        public bool Sua(KhachHang kh)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var khCu = db.KhachHang.Find(kh.MaKhachHang);
                if (khCu == null) return false;

                khCu.HoTen = kh.HoTen;
                khCu.SoDienThoai = kh.SoDienThoai;
                khCu.Email = kh.Email;
                khCu.DiaChi = kh.DiaChi;
                db.SaveChanges();
                return true;
            }
        }

        public void Xoa(string maKhachHang)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var kh = db.KhachHang.Find(maKhachHang);
                if (kh != null)
                {
                    db.KhachHang.Remove(kh);
                    db.SaveChanges();
                }
            }
        }
    }
}
