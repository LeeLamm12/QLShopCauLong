using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLShopCauLong.BLL;

namespace QLShopCauLong.Forms
{
    public partial class QuanLyTaiKhoan_Form : Form
    {
        private bool _isLoading = true;
        private List<TaiKhoan> _dsTaiKhoanGoc = new List<TaiKhoan>();

        public QuanLyTaiKhoan_Form()
        {
            InitializeComponent();
        }

        private void QuanLyTaiKhoan_Form_Load(object sender, EventArgs e)
        {
            lbl_TenNguoiDung.Text = SessionBLL.TenNhanVien ?? SessionBLL.TenDangNhap;
            lbl_VaiTro.Text = SessionBLL.TaiKhoanHienTai?.VaiTro ?? "Nhân viên";
            ApDungPhanQuyenSidebar();

            dgv_TaiKhoan.RowHeadersVisible = false;
            _isLoading = true;

            LoadDanhSach();

            _isLoading = false;
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

        private void LoadDanhSach()
        {
            try
            {
                _dsTaiKhoanGoc = new TaiKhoanBLL().LayDanhSach();
                HienThiGrid(_dsTaiKhoanGoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách tài khoản: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiGrid(List<TaiKhoan> list)
        {
            var displayList = list.Select((tk, index) => new
            {
                STT = index + 1,
                tk.TenDangNhap,
                HoTenNhanVien = tk.NhanVien != null ? tk.NhanVien.HoTen : "",
                tk.MaNhanVien,
                tk.VaiTro,
                TrangThai = (tk.TrangThai ?? true) ? "Hoạt động" : "Đã khóa"
            }).ToList();

            dgv_TaiKhoan.AutoGenerateColumns = false;
            dgv_TaiKhoan.DataSource = displayList;

            // Gán icon cho 3 cột hành động — làm SAU khi DataSource đã bind xong
            foreach (DataGridViewRow row in dgv_TaiKhoan.Rows)
            {
                string tenDangNhap = row.Cells["col_TenDangNhap"].Value?.ToString();
                var tk = list.FirstOrDefault(x => x.TenDangNhap == tenDangNhap);
                bool dangHoatDong = (tk?.TrangThai ?? true);

                row.Cells["col_Sua"].Value = Properties.Resources.icon_sua;
                row.Cells["col_Xoa"].Value = Properties.Resources.icon_xoa;
                row.Cells["col_Khoa"].Value = dangHoatDong
                    ? Properties.Resources.icon_khoa
                    : Properties.Resources.icon_mokhoa;
            }
        }


        private void btn_ThemTaiKhoan_Click(object sender, EventArgs e)
        {
            var f = new QuanLyTaiKhoan_ThemSua();
            if (f.ShowDialog() == DialogResult.OK)
                LoadDanhSach();
        }

        private void dgv_TaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0) return;

            string tenDangNhap = dgv_TaiKhoan.Rows[e.RowIndex].Cells["col_TenDangNhap"].Value?.ToString();
            if (string.IsNullOrEmpty(tenDangNhap)) return;

            string tenCot = dgv_TaiKhoan.Columns[e.ColumnIndex].Name;

            if (tenCot == "col_Sua")
            {
                var tk = new TaiKhoanBLL().LayTheoTenDangNhap(tenDangNhap);
                if (tk == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var f = new QuanLyTaiKhoan_ThemSua(tk);
                if (f.ShowDialog() == DialogResult.OK)
                    LoadDanhSach();
            }
            else if (tenCot == "col_Xoa")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa tài khoản '{tenDangNhap}'?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    var (thanhCong, thongBao) = new TaiKhoanBLL().Xoa(tenDangNhap);
                    MessageBox.Show(thongBao, thanhCong ? "Thành công" : "Lỗi",
                        MessageBoxButtons.OK, thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (thanhCong)
                        LoadDanhSach();
                }
            }
            else if (tenCot == "col_Khoa")
            {
                var tk = _dsTaiKhoanGoc.FirstOrDefault(x => x.TenDangNhap == tenDangNhap);
                bool dangHoatDong = (tk?.TrangThai ?? true);

                (bool ThanhCong, string ThongBao) ketQua;

                if (dangHoatDong)
                {
                    var confirm = MessageBox.Show(
                        $"Bạn có chắc muốn khóa tài khoản '{tenDangNhap}'?",
                        "Xác nhận khóa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm != DialogResult.Yes) return;

                    ketQua = new TaiKhoanBLL().KhoaTaiKhoan(tenDangNhap);
                }
                else
                {
                    ketQua = new TaiKhoanBLL().MoKhoaTaiKhoan(tenDangNhap);
                }

                MessageBox.Show(ketQua.ThongBao, ketQua.ThanhCong ? "Thành công" : "Lỗi",
                    MessageBoxButtons.OK, ketQua.ThanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (ketQua.ThanhCong)
                    LoadDanhSach();
            }
        }

        private void txt_TimKiemTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            string tuKhoa = txt_TimKiemTaiKhoan.Text.Trim().ToLower();

            var ketQua = string.IsNullOrEmpty(tuKhoa)
                ? _dsTaiKhoanGoc
                : _dsTaiKhoanGoc.Where(tk =>
                        (tk.TenDangNhap ?? "").ToLower().Contains(tuKhoa)
                     || (tk.NhanVien?.HoTen ?? "").ToLower().Contains(tuKhoa)
                     || (tk.MaNhanVien ?? "").ToLower().Contains(tuKhoa))
                    .ToList();

            HienThiGrid(ketQua);
        }

        private void dgv_TaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void QuanLyTaiKhoan_Form_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btn_Backup_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Chọn thư mục lưu file backup";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    var (thanhCong, thongBao) = new BackupRestoreBLL().Backup(fbd.SelectedPath);
                    MessageBox.Show(thongBao, thanhCong ? "Thành công" : "Lỗi",
                        MessageBoxButtons.OK,
                        thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {
            var xacNhan = MessageBox.Show(
        "Phục hồi sẽ GHI ĐÈ toàn bộ dữ liệu hiện tại bằng dữ liệu trong file backup. Bạn có chắc chắn muốn tiếp tục?",
        "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (xacNhan != DialogResult.Yes) return;

            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Backup files (*.bak)|*.bak";
                ofd.Title = "Chọn file backup cần phục hồi";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var (thanhCong, thongBao) = new BackupRestoreBLL().Restore(ofd.FileName);
                    MessageBox.Show(thongBao, thanhCong ? "Thành công" : "Lỗi",
                        MessageBoxButtons.OK,
                        thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                    if (thanhCong)
                        Application.Restart();
                }
            }
        }
    }
}
