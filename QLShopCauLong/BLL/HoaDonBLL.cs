using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class HoaDonBLL
    {
        private readonly HoaDonDAL dal = new HoaDonDAL();

        public List<HoaDon> LayDanhSach() => dal.LayDanhSach();
        public List<HoaDon> TimKiem(string tuKhoa, DateTime? tuNgay, DateTime? denNgay)
            => dal.TimKiem(tuKhoa, tuNgay, denNgay);
        public HoaDon LayTheoMa(string ma) => dal.LayTheoMa(ma);

        public List<string> Validate(HoaDon hd, List<ChiTietHoaDon> chiTiet)
        {
            var loi = new List<string>();
            if (ValidationHelper.IsNullOrEmpty(hd.MaHoaDon))
                loi.Add("Mã hóa đơn không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(hd.MaKhachHang))
                loi.Add("Vui lòng chọn khách hàng.");
            if (ValidationHelper.IsNullOrEmpty(hd.MaNhanVien))
                loi.Add("Vui lòng chọn nhân viên.");
            if (dal.KiemTraTonTai(hd.MaHoaDon))
                loi.Add($"Mã hóa đơn '{hd.MaHoaDon}' đã tồn tại.");

            if (chiTiet == null || chiTiet.Count == 0)
                loi.Add("Hóa đơn phải có ít nhất 1 sản phẩm.");
            else
            {
                foreach (var ct in chiTiet)
                {
                    if (ct.SoLuong <= 0)
                        loi.Add($"Sản phẩm {ct.MaSanPham}: số lượng phải > 0.");
                    if (ct.DonGia <= 0)
                        loi.Add($"Sản phẩm {ct.MaSanPham}: đơn giá phải > 0.");
                }
            }

            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(HoaDon hd, List<ChiTietHoaDon> chiTiet)
        {
            var loi = Validate(hd, chiTiet);
            if (loi.Count > 0) return (false, loi);

            // Tính tổng tiền
            hd.TongTien = chiTiet.Sum(ct => ct.SoLuong * ct.DonGia);
            if (hd.NgayLap == DateTime.MinValue)
                hd.NgayLap = DateTime.Now;

            try
            {
                dal.Them(hd, chiTiet);
                return (true, loi);
            }
            catch (Exception ex)
            {
                loi.Add("Lỗi khi lưu: " + ex.Message);
                return (false, loi);
            }
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maHD)
        {
            if (!dal.KiemTraTonTai(maHD))
                return (false, "Hóa đơn không tồn tại.");

            try
            {
                dal.Xoa(maHD);
                return (true, "Xóa hóa đơn thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        public List<HoaDon> TimKiemNangCao(string tuKhoa, DateTime? tuNgay, DateTime? denNgay,
                                   string maNhanVien, string phuongThucTT)
    => dal.TimKiemNangCao(tuKhoa, tuNgay, denNgay, maNhanVien, phuongThucTT);
    }
}
