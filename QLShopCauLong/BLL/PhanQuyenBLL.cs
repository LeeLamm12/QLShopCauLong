using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopCauLong.BLL
{
    public enum ChucNang
    {
        Dashboard,
        SanPham,
        HoaDon,
        KhachHang,
        NhanVien,
        NhaCungCap,
        KhoHang,
        BaoCao,
        QuanLyTaiKhoan
    }

    public class PhanQuyenBLL
    {
        /// <summary>
        /// Kiểm tra tài khoản hiện tại có quyền truy cập chức năng không
        /// Bạn gái gọi trước khi mở Form: if (!phanQuyen.CoQuyen(ChucNang.NhanVien)) { MessageBox... return; }
        /// </summary>
        public bool CoQuyenTruyCap(ChucNang chucNang)
        {
            if (SessionBLL.TaiKhoanHienTai == null) return false;

            string vaiTro = SessionBLL.TaiKhoanHienTai.VaiTro;

            // Admin full quyền
            if (vaiTro == "Quản trị viên") return true;

            // Nhân viên chỉ được truy cập một số chức năng
            if (vaiTro == "Nhân viên")
            {
                switch (chucNang)
                {
                    case ChucNang.Dashboard:
                    case ChucNang.HoaDon:
                    case ChucNang.SanPham:
                    case ChucNang.KhachHang:
                        return true;
                    default:
                        return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Trả về danh sách chức năng được phép (để bạn gái ẩn/hiện menu)
        /// </summary>
        public List<ChucNang> LayChucNangDuocPhep()
        {
            var all = Enum.GetValues(typeof(ChucNang)).Cast<ChucNang>().ToList();
            return all.Where(c => CoQuyenTruyCap(c)).ToList();
        }

        /// <summary>
        /// Kiểm tra có phải Admin không (dùng cho nút Reset MK, Khóa TK...)
        /// </summary>
        public bool LaAdmin => SessionBLL.IsAdmin;
    }
}
