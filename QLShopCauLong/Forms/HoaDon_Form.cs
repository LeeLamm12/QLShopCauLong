using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLShopCauLong.BLL;

namespace QLShopCauLong.Forms
{
    public partial class HoaDon_Form : Form
    {
        private bool _isLoading = true;

        public HoaDon_Form()
        {
            InitializeComponent();
        }

        private void HoaDon_Form_Load(object sender, EventArgs e)
        {
            lbl_TenNguoiDung.Text = SessionBLL.TenNhanVien ?? SessionBLL.TenDangNhap;
            lbl_VaiTro.Text = SessionBLL.TaiKhoanHienTai?.VaiTro ?? "Nhân viên";
            ApDungPhanQuyenSidebar();

            _isLoading = true;

            LoadComboboxLoc();

            _isLoading = false;

            LoadDanhSachHoaDon();
        }

        /* ========== SIDEBAR + PHÂN QUYỀN ========== */
        private void ApDungPhanQuyenSidebar()
        {
            var pq = new PhanQuyenBLL();

            SetQuyen(btn_TrangChu, ChucNang.Dashboard, pq);
            SetQuyen(btn_SanPham, ChucNang.SanPham, pq);
            SetQuyen(btn_HoaDon, ChucNang.HoaDon, pq);
            SetQuyen(btn_KhachHang, ChucNang.KhachHang, pq);
            SetQuyen(btn_NhanVien, ChucNang.NhanVien, pq);
            SetQuyen(btn_NhaCungCap, ChucNang.NhaCungCap, pq);
            SetQuyen(btn_ThongKe, ChucNang.BaoCao, pq);
            SetQuyen(btn_QuanLyTaiKhoan, ChucNang.QuanLyTaiKhoan, pq);
            // btn_DangXuat luôn hiện
        }

        private void SetQuyen(Control btn, ChucNang cn, PhanQuyenBLL pq)
        {
            if (btn == null) return;
            btn.Visible = pq.CoQuyenTruyCap(cn);
        }

        // ========== HIỂN THỊ GRID ==========
        private void HienThiGrid(List<HoaDon> list)
        {
            var displayList = list.Select(hd => new
            {
                hd.MaHoaDon,
                TenKhachHang = hd.KhachHang != null ? hd.KhachHang.HoTen : "",
                TenNhanVien = hd.NhanVien != null ? hd.NhanVien.HoTen : "",
                NgayLap = hd.NgayLap.HasValue ? hd.NgayLap.Value.ToString("dd/MM/yyyy HH:mm") : "",
                TongTien = hd.TongTien ?? 0,
                hd.PhuongThucThanhToan
            }).ToList();

            dgv_HoaDon.AutoGenerateColumns = false;
            dgv_HoaDon.DataSource = displayList;
        }

        private void LoadDanhSachHoaDon()
        {
            try
            {
                var list = new HoaDonBLL().LayDanhSach();
                HienThiGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboboxLoc()
        {
            // --- Nhân viên lập ---
            try
            {
                var dsNV = new NhanVienBLL().LayDanhSach().ToList();
                dsNV.Insert(0, new NhanVien { MaNhanVien = "", HoTen = "Tất cả nhân viên" });

                cbb_NhanVienLap.DisplayMember = "HoTen";
                cbb_NhanVienLap.ValueMember = "MaNhanVien";
                cbb_NhanVienLap.DataSource = dsNV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhân viên: " + ex.Message);
            }

            // --- Phương thức thanh toán: lấy trực tiếp từ dữ liệu thật ---
            cbb_PhuongThucThanhToan.Items.Clear();
            cbb_PhuongThucThanhToan.Items.Add("Tất cả PTTT");

            try
            {
                var dsPTTT = new HoaDonBLL().LayDanhSach()
                    .Select(hd => hd.PhuongThucThanhToan)
                    .Where(p => !string.IsNullOrEmpty(p))
                    .Select(p => p.Trim())
                    .Distinct()
                    .OrderBy(p => p)
                    .ToList();

                foreach (var pttt in dsPTTT)
                    cbb_PhuongThucThanhToan.Items.Add(pttt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load phương thức thanh toán: " + ex.Message);
            }

            cbb_PhuongThucThanhToan.SelectedIndex = 0;
        }

        private void LocHoaDon()
        {
            if (_isLoading) return;

            try
            {
                string tuKhoa = txt_TimKiemNangCao.Text.Trim();

                string maNV = cbb_NhanVienLap.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maNV)) maNV = null;

                string pttt = cbb_PhuongThucThanhToan.SelectedIndex > 0
                    ? cbb_PhuongThucThanhToan.Text.Trim()
                    : null;

                List<HoaDon> list;
                if (!string.IsNullOrEmpty(maNV) || !string.IsNullOrEmpty(pttt))
                {
                    list = new HoaDonBLL().TimKiemNangCao(tuKhoa, maNV, pttt);
                }
                else
                {
                    list = new HoaDonBLL().TimKiem(tuKhoa);
                }

                HienThiGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc dữ liệu: " + ex.Message);
            }
        }

        private void dgv_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maHD = dgv_HoaDon.Rows[e.RowIndex].Cells["col_MaHoaDon"].Value?.ToString();
            if (string.IsNullOrEmpty(maHD)) return;

            string tenColumn = dgv_HoaDon.Columns[e.ColumnIndex].Name;

            if (tenColumn == "col_ChiTiet") // cột "Xem"
            {
                var hd = new HoaDonBLL().LayTheoMa(maHD);
                if (hd != null)
                {
                    var f = new ChiTietHoaDon_Form(hd);
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tenColumn == "col_In") // cột "In"
            {
                var result = MessageBox.Show(
                    $"Bạn có muốn in hóa đơn {maHD} không?",
                    "Xác nhận in hóa đơn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;

                var hd = new HoaDonBLL().LayTheoMa(maHD);
                if (hd != null)
                {
                    using (var f = new ChiTietHoaDon_Form(hd))
                    {
                        f.XuatPdfHoaDon(); // in thẳng, không hiện form chi tiết
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cbb_NhanVienLap_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocHoaDon();
        }

        private void DTimePic_TuNgay_ValueChanged(object sender, EventArgs e)
        {
        }

        private void DTimePic_DenNgay_ValueChanged(object sender, EventArgs e)
        {
        }

        private void cbb_PhuongThucThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocHoaDon();
        }

        private void txt_TimKiemNangCao_TextChanged(object sender, EventArgs e)
        {
            LocHoaDon();
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            if (SessionBLL.IsAdmin)
                MoForm(new Admin_Form());
            else
                MoForm(new User_Form());
        }

        private void btn_SanPham_Click(object sender, EventArgs e)
        {
            MoForm(new SanPham_Form());
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            MoForm(new HoaDon_Form());
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            MoForm(new QuanLyKhachHang_Form());
        }

        private void btn_NhanVien_Click(object sender, EventArgs e)
        {
            MoForm(new QuanLyNhanVien_Form());
        }

        private void btn_NhaCungCap_Click(object sender, EventArgs e)
        {
            MoForm(new NhaCungCap_Form());
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            MoForm(new BaoCao_Form());
        }

        private void btn_QuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            MoForm(new QuanLyTaiKhoan_Form());
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            SessionBLL.XacNhanVaDangXuat(this);
        }

        private void MoForm(Form frm)
        {
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
            this.Hide();
        }

        private void lbl_PhuongThucThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void HoaDon_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AppState.DangThoat) return;

            if (e.CloseReason == CloseReason.UserClosing)
            {
                var kq = MessageBox.Show("Bạn có chắc muốn đóng ứng dụng?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (kq == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    AppState.DangThoat = true;
                    Application.Exit();
                }
            }
        }
    }
}
