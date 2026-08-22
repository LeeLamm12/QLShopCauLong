using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class NhaCungCapDAL
    {
        public List<NhaCungCap> LayDanhSach()
        {
            using (var db = new QLShopCauLongEntities())
                return db.NhaCungCap.OrderBy(n => n.MaNCC).ToList();
        }

        public NhaCungCap LayTheoMa(string maNCC)
        {
            using (var db = new QLShopCauLongEntities())
                return db.NhaCungCap.Find(maNCC);
        }

        public bool KiemTraTonTai(string maNCC)
        {
            using (var db = new QLShopCauLongEntities())
                return db.NhaCungCap.Any(n => n.MaNCC == maNCC);
        }

        public bool DaCoPhieuNhap(string maNCC)
        {
            using (var db = new QLShopCauLongEntities())
                return db.PhieuNhap.Any(pn => pn.MaNCC == maNCC);
        }

        public void Them(NhaCungCap ncc)
        {
            using (var db = new QLShopCauLongEntities())
            {
                db.NhaCungCap.Add(ncc);
                db.SaveChanges();
            }
        }

        public bool Sua(NhaCungCap ncc)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var cu = db.NhaCungCap.Find(ncc.MaNCC);
                if (cu == null) return false;

                cu.TenNCC = ncc.TenNCC;
                cu.SoDienThoai = ncc.SoDienThoai;
                cu.Email = ncc.Email;
                cu.DiaChi = ncc.DiaChi;

                db.SaveChanges();
                return true;
            }
        }

        public void Xoa(string maNCC)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var ncc = db.NhaCungCap.Find(maNCC);
                if (ncc != null)
                {
                    db.NhaCungCap.Remove(ncc);
                    db.SaveChanges();
                }
            }
        }
    }
}
