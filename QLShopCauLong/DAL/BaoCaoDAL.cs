using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLShopCauLong.DAL
{
    public class BaoCaoDAL
    {
        /// <summary>
        /// Báo cáo doanh thu chi tiết theo ngày — trả DataTable để bind RDLC
        /// </summary>
        public DataTable BaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var dt = new DataTable();
                dt.Columns.Add("Ngay", typeof(string));
                dt.Columns.Add("SoHoaDon", typeof(int));
                dt.Columns.Add("DoanhThu", typeof(decimal));

                var data = db.HoaDon
                    .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay)
                    .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                    .Select(g => new
                    {
                        Ngay = g.Key.Value,
                        SoHoaDon = g.Count(),
                        DoanhThu = g.Sum(hd => hd.TongTien) ?? 0
                    })
                    .OrderBy(x => x.Ngay)
                    .ToList();

                foreach (var item in data)
                {
                    dt.Rows.Add(item.Ngay.ToString("dd/MM/yyyy"), item.SoHoaDon, item.DoanhThu);
                }

                return dt;
            }
        }

        /// <summary>
        /// Báo cáo tồn kho chi tiết — trả DataTable
        /// </summary>
        public DataTable BaoCaoTonKho(string maDanhMuc = null)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var dt = new DataTable();
                dt.Columns.Add("MaSanPham", typeof(string));
                dt.Columns.Add("TenSanPham", typeof(string));
                dt.Columns.Add("TenDanhMuc", typeof(string));
                dt.Columns.Add("Size", typeof(int));
                dt.Columns.Add("SoLuongTon", typeof(int));

                var query = db.ChiTietKho.AsQueryable();
                if (!string.IsNullOrWhiteSpace(maDanhMuc))
                    query = query.Where(k => k.SanPham.MaDanhMuc == maDanhMuc);

                var data = query
                    .Select(k => new
                    {
                        k.MaSanPham,
                        k.SanPham.TenSanPham,
                        k.SanPham.DanhMuc.TenDanhMuc,
                        k.Size,
                        k.SoLuongTon
                    })
                    .OrderBy(x => x.MaSanPham)
                    .ToList();

                foreach (var item in data)
                {
                    dt.Rows.Add(item.MaSanPham, item.TenSanPham, item.TenDanhMuc, item.Size, item.SoLuongTon);
                }

                return dt;
            }
        }

        /// <summary>
        /// Báo cáo nhập hàng theo NCC — trả DataTable
        /// </summary>
        public DataTable BaoCaoNhapHang(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var dt = new DataTable();
                dt.Columns.Add("MaNCC", typeof(string));
                dt.Columns.Add("TenNCC", typeof(string));
                dt.Columns.Add("SoPhieuNhap", typeof(int));
                dt.Columns.Add("TongTienNhap", typeof(decimal));

                var data = db.PhieuNhap
                    .Where(pn => pn.NgayNhap >= tuNgay && pn.NgayNhap <= denNgay)
                    .GroupBy(pn => pn.MaNCC)
                    .Select(g => new
                    {
                        MaNCC = g.Key,
                        TenNCC = g.FirstOrDefault().NhaCungCap.TenNCC,
                        SoPhieuNhap = g.Count(),
                        TongTienNhap = g.Sum(pn => pn.TongTien) ?? 0
                    })
                    .OrderByDescending(x => x.TongTienNhap)
                    .ToList();

                foreach (var item in data)
                {
                    dt.Rows.Add(item.MaNCC, item.TenNCC, item.SoPhieuNhap, item.TongTienNhap);
                }

                return dt;
            }
        }

        /// <summary>
        /// Báo cáo hóa đơn chi tiết (master) — trả DataTable
        /// </summary>
        public DataTable BaoCaoHoaDon(DateTime tuNgay, DateTime denNgay, string maNhanVien = null)
        {
            using (var db = new QLShopCauLongEntities())
            {
                var dt = new DataTable();
                dt.Columns.Add("MaHoaDon", typeof(string));
                dt.Columns.Add("NgayLap", typeof(string));
                dt.Columns.Add("TenKhachHang", typeof(string));
                dt.Columns.Add("TenNhanVien", typeof(string));
                dt.Columns.Add("PhuongThucThanhToan", typeof(string));
                dt.Columns.Add("TongTien", typeof(decimal));

                var query = db.HoaDon
                    .Where(hd => hd.NgayLap >= tuNgay && hd.NgayLap <= denNgay)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(maNhanVien))
                    query = query.Where(hd => hd.MaNhanVien == maNhanVien);

                var data = query
                    .Select(hd => new
                    {
                        hd.MaHoaDon,
                        NgayLap = hd.NgayLap,
                        hd.KhachHang.HoTen,
                        NhanVien = hd.NhanVien.HoTen,
                        hd.PhuongThucThanhToan,
                        hd.TongTien
                    })
                    .OrderByDescending(x => x.NgayLap)
                    .ToList();

                foreach (var item in data)
                {
                    dt.Rows.Add(
                        item.MaHoaDon,
                        item.NgayLap?.ToString("dd/MM/yyyy HH:mm"),
                        item.HoTen,
                        item.NhanVien,
                        item.PhuongThucThanhToan,
                        item.TongTien
                    );
                }

                return dt;
            }
        }
    }
}
