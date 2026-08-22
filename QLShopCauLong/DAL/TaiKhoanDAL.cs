using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class TaiKhoanDAL
    {
        public TaiKhoan LayTheoTenDangNhap(string tenDangNhap)
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.TaiKhoan
                         .Include("NhanVien")
                         .FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap);
            }
        }

        public List<TaiKhoan> LayDanhSach()
        {
            using (var db = new QLShopCauLongEntities())
            {
                return db.TaiKhoan.Include("NhanVien").ToList();
            }
        }

        public bool KiemTraTonTai(string tenDangNhap)
        {
            using (var db = new QLShopCauLongEntities())
                return db.TaiKhoan.Any(tk => tk.TenDangNhap == tenDangNhap);
        }

        public void Them(TaiKhoan tk)
        {
            using (var db = new QLShopCauLongEntities())
            {
                db.TaiKhoan.Add(tk);
                db.SaveChanges();
            }
        }

        public bool Sua(TaiKhoan tk)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var cu = db.TaiKhoan.Find(tk.TenDangNhap);
                if (cu == null) return false;

                cu.MatKhau = tk.MatKhau;
                cu.VaiTro = tk.VaiTro;
                cu.TrangThai = tk.TrangThai;
                db.SaveChanges();
                return true;
            }
        }

        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var tk = db.TaiKhoan.Find(tenDangNhap);
                if (tk == null) return false;
                tk.MatKhau = matKhauMoi;
                db.SaveChanges();
                return true;
            }
        }

        public void Xoa(string tenDangNhap)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var tk = db.TaiKhoan.Find(tenDangNhap);
                if (tk != null)
                {
                    db.TaiKhoan.Remove(tk);
                    db.SaveChanges();
                }
            }
        }

        public bool KhoaTaiKhoan(string tenDangNhap)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var tk = db.TaiKhoan.Find(tenDangNhap);
                if (tk == null) return false;
                tk.TrangThai = false;
                db.SaveChanges();
                return true;
            }
        }

        public bool MoKhoaTaiKhoan(string tenDangNhap)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var tk = db.TaiKhoan.Find(tenDangNhap);
                if (tk == null) return false;
                tk.TrangThai = true;
                db.SaveChanges();
                return true;
            }
        }
    }
}
