using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class NhanVienDAL
    {
        public List<NhanVien> LayDanhSach()
        {
            using (var db = new QLShopCauLongEntities())
                return db.NhanVien.OrderBy(nv => nv.MaNhanVien).ToList();
        }

        public NhanVien LayTheoMa(string maNV)
        {
            using (var db = new QLShopCauLongEntities())
                return db.NhanVien.Find(maNV);
        }

        public bool KiemTraTonTai(string maNV)
        {
            using (var db = new QLShopCauLongEntities())
                return db.NhanVien.Any(nv => nv.MaNhanVien == maNV);
        }

        public bool DaCoTaiKhoan(string maNV)
        {
            using (var db = new QLShopCauLongEntities())
                return db.TaiKhoan.Any(tk => tk.MaNhanVien == maNV);
        }

        public void Them(NhanVien nv)
        {
            using (var db = new QLShopCauLongEntities())
            {
                db.NhanVien.Add(nv);
                db.SaveChanges();
            }
        }

        public bool Sua(NhanVien nv)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var cu = db.NhanVien.Find(nv.MaNhanVien);
                if (cu == null) return false;

                cu.HoTen = nv.HoTen;
                cu.GioiTinh = nv.GioiTinh;
                cu.NgaySinh = nv.NgaySinh;
                cu.SoDienThoai = nv.SoDienThoai;
                cu.Email = nv.Email;
                cu.DiaChi = nv.DiaChi;
                cu.ChucVu = nv.ChucVu;
                cu.Luong = nv.Luong;
                cu.NgayVaoLam = nv.NgayVaoLam;

                db.SaveChanges();
                return true;
            }
        }

        public void Xoa(string maNV)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var nv = db.NhanVien.Find(maNV);
                if (nv != null)
                {
                    db.NhanVien.Remove(nv);
                    db.SaveChanges();
                }
            }
        }

        public bool KiemTraTrungSDT(string sdt, string maNVLoaiTru = null)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.NhanVien.Where(nv => nv.SoDienThoai == sdt);
                if (!string.IsNullOrEmpty(maNVLoaiTru))
                    query = query.Where(nv => nv.MaNhanVien != maNVLoaiTru);
                return query.Any();
            }
        }

        public bool KiemTraTrungEmail(string email, string maNVLoaiTru = null)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var query = db.NhanVien.Where(nv => nv.Email == email);
                if (!string.IsNullOrEmpty(maNVLoaiTru))
                    query = query.Where(nv => nv.MaNhanVien != maNVLoaiTru);
                return query.Any();
            }
        }
    }
}
