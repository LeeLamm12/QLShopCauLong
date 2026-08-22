using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class DanhMucBLL
    {
        private readonly DanhMucDAL dal = new DanhMucDAL();

        public List<DanhMuc> LayDanhSach() => dal.LayDanhSach();
        public List<DanhMuc> TimKiem(string tuKhoa) => dal.TimKiem(tuKhoa);
        public bool KiemTraTrungMa(string maDanhMuc) => dal.KiemTraTonTai(maDanhMuc);

        public List<string> Validate(DanhMuc dm, bool laThemMoi)
        {
            var loi = new List<string>();
            if (ValidationHelper.IsNullOrEmpty(dm.MaDanhMuc))
                loi.Add("Mã danh mục không được để trống.");
            if (ValidationHelper.IsNullOrEmpty(dm.TenDanhMuc))
                loi.Add("Tên danh mục không được để trống.");
            if (laThemMoi && KiemTraTrungMa(dm.MaDanhMuc))
                loi.Add($"Mã danh mục '{dm.MaDanhMuc}' đã tồn tại.");
            return loi;
        }

        public (bool ThanhCong, List<string> Loi) Them(DanhMuc dm)
        {
            var loi = Validate(dm, laThemMoi: true);
            if (loi.Count > 0) return (false, loi);

            dal.Them(dm);
            return (true, loi);
        }

        public (bool ThanhCong, List<string> Loi) Sua(DanhMuc dm)
        {
            var loi = Validate(dm, laThemMoi: false);
            if (loi.Count > 0) return (false, loi);

            bool ok = dal.Sua(dm);
            if (!ok) loi.Add("Danh mục không tồn tại.");

            return (ok, loi);
        }

        public (bool ThanhCong, string ThongBao) Xoa(string maDanhMuc)
        {
            if (dal.DangDuocSanPhamSuDung(maDanhMuc))
                return (false, "Không thể xóa: đang có sản phẩm thuộc danh mục này.");

            if (!dal.KiemTraTonTai(maDanhMuc))
                return (false, "Danh mục không tồn tại.");

            dal.Xoa(maDanhMuc);
            return (true, "Xóa thành công.");
        }
    }
}
