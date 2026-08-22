using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class SanPhamBLL
    {
        private readonly SanPhamDAL dal = new SanPhamDAL();

        public List<SanPham> LayDanhSach() => dal.LayDanhSach();

        public List<SanPham> TimKiem(string tuKhoa, string maDanhMuc = null, string thuongHieu = null)
            => dal.TimKiem(tuKhoa, maDanhMuc, thuongHieu);

        public bool KiemTraTrungMa(string maSanPham) => dal.KiemTraTonTai(maSanPham);

        public List<string> Validate(SanPham sp, bool laThemMoi)
        {
            var loi = new List<string>();

            if (ValidationHelper.IsNullOrEmpty(sp.MaSanPham))
                loi.Add("Mã sản phẩm không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(sp.TenSanPham))
                loi.Add("Tên sản phẩm không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(sp.MaDanhMuc))
                loi.Add("Vui lòng chọn danh mục.");
            if (!ValidationHelper.IsPositiveDecimal(sp.DonGia))
                loi.Add("Đơn giá phải lớn hơn 0.");
            if (laThemMoi && KiemTraTrungMa(sp.MaSanPham))
                loi.Add($"Mã sản phẩm '{sp.MaSanPham}' đã tồn tại.");

            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(SanPham sp, List<ChiTietKho> dsSize)
        {
            var loi = Validate(sp, laThemMoi: true);

            if (dsSize == null || dsSize.Count == 0)
                loi.Add("Phải nhập ít nhất 1 size cho sản phẩm.");
            else if (dsSize.Select(s => s.Size).Distinct().Count() != dsSize.Count)
                loi.Add("Có size bị trùng, mỗi size chỉ nhập 1 dòng.");

            if (loi.Count > 0) return (false, loi);

            dal.Them(sp, dsSize);
            return (true, loi);
        }

        public (bool ThanhCong, List<string> Loi) Sua(SanPham sp, List<ChiTietKho> dsSize)
        {
            var loi = Validate(sp, laThemMoi: false);
            if (loi.Count > 0) return (false, loi);

            bool ok = dal.Sua(sp, dsSize);
            if (!ok) loi.Add("Sản phẩm không tồn tại.");

            return (ok, loi);
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maSanPham)
        {
            if (dal.DaXuatHienTrongHoaDon(maSanPham))
                return (false, "Không thể xóa: sản phẩm đã có trong hóa đơn.");

            if (!dal.KiemTraTonTai(maSanPham))
                return (false, "Sản phẩm không tồn tại.");

            dal.Xoa(maSanPham);
            return (true, "Xóa thành công.");
        }
    }
}
