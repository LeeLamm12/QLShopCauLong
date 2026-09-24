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
    public partial class QuanLyKhachHang_Form : Form
    {
        public QuanLyKhachHang_Form()
        {
            InitializeComponent();
        }

        private void QuanLyKhachHang_Form_Load(object sender, EventArgs e)
        {
            lbl_TenNguoiDung.Text = SessionBLL.TenNhanVien ?? SessionBLL.TenDangNhap;
            lbl_VaiTro.Text = SessionBLL.TaiKhoanHienTai?.VaiTro ?? "Nhân viên";
            ApDungPhanQuyenSidebar();
            LoadDanhSachKhachHang();
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
        private void HienThiGrid(List<KhachHang> list)
        {
            // Lấy toàn bộ hóa đơn 1 lần, đếm theo mã khách hàng — tránh query lặp lại cho từng dòng
            var dsHoaDon = new HoaDonBLL().LayDanhSach();

            var displayList = list.Select(kh => new
            {
                kh.MaKhachHang,
                kh.HoTen,
                kh.SoDienThoai,
                kh.Email,
                kh.DiaChi,
                TongSoHoaDonMua = dsHoaDon.Count(hd => hd.MaKhachHang == kh.MaKhachHang)
            }).ToList();

            dgv_KhachHang.AutoGenerateColumns = false;

            col_MaKhachHang.DataPropertyName = "MaKhachHang";
            col_HoTen.DataPropertyName = "HoTen";
            col_SDT.DataPropertyName = "SoDienThoai";
            col_Email.DataPropertyName = "Email";
            col_DiaChi.DataPropertyName = "DiaChi";
            TongSoHoaDonMua.DataPropertyName = "TongSoHoaDonMua";

            dgv_KhachHang.DataSource = displayList;
        }

        private void LoadDanhSachKhachHang()
        {
            try
            {
                var list = new KhachHangBLL().LayDanhSach();
                HienThiGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TÌM KIẾM ==========
        private void LocKhachHang()
        {
            try
            {
                string tuKhoa = txt_KhachHang.Text.Trim();
                var list = new KhachHangBLL().TimKiem(tuKhoa);
                HienThiGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgv_QuanLyKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maKH = dgv_KhachHang.Rows[e.RowIndex].Cells["col_MaKhachHang"].Value?.ToString();
            if (string.IsNullOrEmpty(maKH)) return;

            string tenColumn = dgv_KhachHang.Columns[e.ColumnIndex].Name;

            if (tenColumn == "col_Xoa")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa khách hàng {maKH}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    var (thanhCong, thongBao) = new KhachHangBLL().Xoa(maKH);
                    MessageBox.Show(thongBao, thanhCong ? "Thành công" : "Lỗi",
                        MessageBoxButtons.OK, thanhCong ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                    if (thanhCong)
                        LoadDanhSachKhachHang();
                }
            }
            else if (tenColumn == "col_Sua")
            {
                var frm = new QuanLyKhachHang_ThemSua(maKH);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachKhachHang();
                }
            }
        }

        private void btn_ThemKhachHang_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyKhachHang_ThemSua();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachKhachHang();
            }
        }

        private void txt_KhachHang_TextChanged(object sender, EventArgs e)
        {
            LocKhachHang();
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

        private void QuanLyKhachHang_Form_FormClosing(object sender, FormClosingEventArgs e)
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
