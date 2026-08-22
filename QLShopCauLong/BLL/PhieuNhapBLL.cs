using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class PhieuNhapBLL
    {
        private readonly PhieuNhapDAL dal = new PhieuNhapDAL();

        public List<PhieuNhap> LayDanhSach() => dal.LayDanhSach();
        public List<PhieuNhap> TimKiem(string tuKhoa, DateTime? tuNgay, DateTime? denNgay)
            => dal.TimKiem(tuKhoa, tuNgay, denNgay);
        public PhieuNhap LayTheoMa(string ma) => dal.LayTheoMa(ma);

        public List<string> Validate(PhieuNhap pn, List<ChiTietPhieuNhap> chiTiet)
        {
            var loi = new List<string>();
            if (ValidationHelper.IsNullOrEmpty(pn.MaPhieuNhap))
                loi.Add("Mã phiếu nhập không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(pn.MaNCC))
                loi.Add("Vui lòng chọn nhà cung cấp.");
            if (ValidationHelper.IsNullOrEmpty(pn.MaNhanVien))
                loi.Add("Vui lòng chọn nhân viên.");
            if (dal.KiemTraTonTai(pn.MaPhieuNhap))
                loi.Add($"Mã phiếu nhập '{pn.MaPhieuNhap}' đã tồn tại.");

            if (chiTiet == null || chiTiet.Count == 0)
                loi.Add("Phiếu nhập phải có ít nhất 1 sản phẩm.");
            else
            {
                foreach (var ct in chiTiet)
                {
                    if (ct.SoLuong <= 0)
                        loi.Add($"Sản phẩm {ct.MaSanPham}: số lượng phải > 0.");
                    if (ct.GiaNhap <= 0)
                        loi.Add($"Sản phẩm {ct.MaSanPham}: giá nhập phải > 0.");
                }
            }
            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(PhieuNhap pn, List<ChiTietPhieuNhap> chiTiet)
        {
            var loi = Validate(pn, chiTiet);
            if (loi.Count > 0) return (false, loi);

            pn.TongTien = chiTiet.Sum(ct => ct.SoLuong * ct.GiaNhap);
            if (pn.NgayNhap == DateTime.MinValue)
                pn.NgayNhap = DateTime.Now;

            try
            {
                dal.Them(pn, chiTiet);
                return (true, loi);
            }
            catch (Exception ex)
            {
                loi.Add("Lỗi khi lưu: " + ex.Message);
                return (false, loi);
            }
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maPN)
        {
            if (!dal.KiemTraTonTai(maPN))
                return (false, "Phiếu nhập không tồn tại.");

            try
            {
                dal.Xoa(maPN);
                return (true, "Xóa phiếu nhập thành công.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        public List<PhieuNhap> TimKiemNangCao(string tuKhoa, DateTime? tuNgay, DateTime? denNgay,
                                      string maNCC, string maNhanVien)
    => dal.TimKiemNangCao(tuKhoa, tuNgay, denNgay, maNCC, maNhanVien);
    }
}
