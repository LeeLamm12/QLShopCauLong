using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class DanhMucDAL
    {
        public List<DanhMuc> LayDanhSach()
        {
            using (var db = new QLShopCauLongEntities())
                return db.DanhMuc.OrderBy(d => d.MaDanhMuc).ToList();
        }

        public List<DanhMuc> TimKiem(string tuKhoa)
        {
            using (var db = new QLShopCauLongEntities())
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                    return db.DanhMuc.ToList();
                return db.DanhMuc.Where(d => d.TenDanhMuc.Contains(tuKhoa)).ToList();
            }
        }

        public bool KiemTraTonTai(string maDanhMuc)
        {
            using (var db = new QLShopCauLongEntities())
                return db.DanhMuc.Any(d => d.MaDanhMuc == maDanhMuc);
        }

        public bool DangDuocSanPhamSuDung(string maDanhMuc)
        {
            using (var db = new QLShopCauLongEntities())
                return db.SanPham.Any(sp => sp.MaDanhMuc == maDanhMuc);
        }

        public void Them(DanhMuc dm)
        {
            using (var db = new QLShopCauLongEntities())
            {
                db.DanhMuc.Add(dm);
                db.SaveChanges();
            }
        }

        public bool Sua(DanhMuc dm)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var dmCu = db.DanhMuc.Find(dm.MaDanhMuc);
                if (dmCu == null) return false;

                dmCu.TenDanhMuc = dm.TenDanhMuc;
                dmCu.MoTa = dm.MoTa;
                db.SaveChanges();
                return true;
            }
        }

        public void Xoa(string maDanhMuc)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var dm = db.DanhMuc.Find(maDanhMuc);
                if (dm != null)
                {
                    db.DanhMuc.Remove(dm);
                    db.SaveChanges();
                }
            }
        }
    }
}
