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
    public partial class QuanLyNhanVien_Form : Form
    {
        public QuanLyNhanVien_Form()
        {
            InitializeComponent();
        }

        private void QuanLyNhanVien_Form_Load(object sender, EventArgs e)
        {
            lbl_TenNguoiDung.Text = SessionBLL.TenNhanVien ?? SessionBLL.TenDangNhap;
            lbl_VaiTro.Text = SessionBLL.TaiKhoanHienTai?.VaiTro ?? "Nhân viên";
            ApDungPhanQuyenSidebar();
            LoadDanhSachNhanVien();
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
        private void HienThiGrid(List<NhanVien> list)
        {
            var displayList = list.Select(nv => new
            {
                nv.MaNhanVien,
                nv.HoTen,
                nv.ChucVu,
                nv.SoDienThoai,
                nv.Email,
                NgayVaoLam = nv.NgayVaoLam.HasValue ? nv.NgayVaoLam.Value.ToString("dd/MM/yyyy") : ""
            }).ToList();

            dgv_NhanVien.AutoGenerateColumns = false;
            dgv_NhanVien.DataSource = displayList;
        }

        private void LoadDanhSachNhanVien()
        {
            try
            {
                var list = new NhanVienBLL().LayDanhSach();
                HienThiGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TÌM KIẾM (client-side vì BLL không có TimKiem) ==========
        private void LocNhanVien()
        {
            try
            {
                string tuKhoa = txt_NhanVien.Text.Trim().ToLower();
                var ds = new NhanVienBLL().LayDanhSach();

                var list = ds.Where(n =>
                    string.IsNullOrEmpty(tuKhoa) ||
                    (n.HoTen != null && n.HoTen.ToLower().Contains(tuKhoa)) ||
                    (n.SoDienThoai != null && n.SoDienThoai.Contains(tuKhoa))
                ).ToList();

                HienThiGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void txt_NhanVien_TextChanged(object sender, EventArgs e)
        {
            LocNhanVien();
        }

        private void btn_ThemNhanVien_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyNhanVien_ThemSua();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachNhanVien();
            }
        }

        private void dgv_QuanLyNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maNV = dgv_NhanVien.Rows[e.RowIndex].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(maNV)) return;

            string tenColumn = dgv_NhanVien.Columns[e.ColumnIndex].Name;

            if (tenColumn == "col_Xoa")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa nhân viên {maNV}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    var (thanhCong, thongBao) = new NhanVienBLL().Xoa(maNV);
                    MessageBox.Show(thongBao, thanhCong ? "Thành công" : "Lỗi",
                        MessageBoxButtons.OK, thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (thanhCong)
                        LoadDanhSachNhanVien();
                }
            }
            else if (tenColumn == "col_Sua")
            {
                var frm = new QuanLyNhanVien_ThemSua(maNV);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachNhanVien();
                }
            }
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

        private void QuanLyNhanVien_Form_FormClosing(object sender, FormClosingEventArgs e)
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
