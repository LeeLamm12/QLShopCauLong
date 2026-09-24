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
using QLShopCauLong.DAL;
using QLShopCauLong.Forms;

namespace QLShopCauLong
{
    public partial class SanPham_Form : Form
    {
        public SanPham_Form()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SanPham_Form_Load(object sender, EventArgs e)
        {
            lbl_TenNguoiDung.Text = SessionBLL.TenNhanVien ?? SessionBLL.TenDangNhap;
            lbl_VaiTro.Text = SessionBLL.TaiKhoanHienTai?.VaiTro ?? "Nhân viên";
            ApDungPhanQuyenSidebar();
            LoadDanhSachSanPham();
            LoadComboboxLoc();
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
        private void HienThiGrid(List<SanPham> list)
        {
            var displayList = list.Select(sp => new
            {
                sp.MaSanPham,
                sp.TenSanPham,
                TenDanhMuc = sp.DanhMuc != null ? sp.DanhMuc.TenDanhMuc : "",
                sp.ThuongHieu,
                sp.DonGia,
                TongTonKho = sp.ChiTietKho != null
                    ? sp.ChiTietKho.Sum(ct => (int?)ct.SoLuongTon) ?? 0
                    : 0
            }).ToList();

            dgv_SanPham.AutoGenerateColumns = false;
            dgv_SanPham.DataSource = displayList;
        }

        private void LoadDanhSachSanPham()
        {
            try
            {
                var list = new SanPhamBLL().LayDanhSach();
                HienThiGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboboxLoc()
        {
            // --- Danh mục ---
            try
            {
                var dsDM = new DanhMucBLL().LayDanhSach().ToList();
                dsDM.Insert(0, new DanhMuc { MaDanhMuc = "", TenDanhMuc = "Tất cả danh mục" });

                cbb_LocDanhMuc.DataSource = dsDM;
                cbb_LocDanhMuc.DisplayMember = "TenDanhMuc";
                cbb_LocDanhMuc.ValueMember = "MaDanhMuc";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh mục: " + ex.Message);
            }

            // --- Thương hiệu ---
            cbb_LocThuongHieu.Items.Clear();
            cbb_LocThuongHieu.Items.Add("Tất cả thương hiệu");
            try
            {
                var dsTH = new SanPhamBLL().LayDanhSach()
                    .Where(sp => !string.IsNullOrEmpty(sp.ThuongHieu))
                    .Select(sp => sp.ThuongHieu)
                    .Distinct()
                    .OrderBy(th => th)
                    .ToList();
                cbb_LocThuongHieu.Items.AddRange(dsTH.ToArray());
            }
            catch { }
            cbb_LocThuongHieu.SelectedIndex = 0;
        }

        private void LocSanPham()
        {
            try
            {
                string tuKhoa = txt_TimKiemSanPham.Text.Trim();

                // Lấy mã danh mục, nếu rỗng → null (tất cả)
                string maDM = cbb_LocDanhMuc.SelectedValue?.ToString();
                if (string.IsNullOrEmpty(maDM)) maDM = null;

                // Lấy thương hiệu, nếu dòng đầu tiên (index 0) → null (tất cả)
                string thuongHieu = cbb_LocThuongHieu.SelectedIndex > 0 ? cbb_LocThuongHieu.Text : null;

                var list = new SanPhamBLL().TimKiem(tuKhoa, maDM, thuongHieu);
                HienThiGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc dữ liệu: " + ex.Message);
            }
        }

        private void dgv_SanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maSP = dgv_SanPham.Rows[e.RowIndex].Cells["col_MaSanPham"].Value.ToString();
            string tenColumn = dgv_SanPham.Columns[e.ColumnIndex].Name;

            if (tenColumn == "col_Xoa")
            {
                var confirm = MessageBox.Show(
                    $"Bạn có chắc muốn xóa sản phẩm {maSP}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    var (thanhCong, thongBao) = new SanPhamBLL().Xoa(maSP);
                    MessageBox.Show(thongBao);

                    if (thanhCong)
                        LoadDanhSachSanPham();
                }
            }
            else if (tenColumn == "col_Sua")
            {
                var frm = new SanPham_ThemSua(maSP);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDanhSachSanPham();
                }
            }
        }

        private void txt_timkiemsanpham_TextChanged(object sender, EventArgs e)
        {
            LocSanPham();
        }

        private void btn_ThemSanPham_Click(object sender, EventArgs e)
        {
            var frm = new SanPham_ThemSua();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDanhSachSanPham(); // load lại danh sách sau khi thêm
            }
        }

        private void cbb_LocDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocSanPham();
        }

        private void cbb_LocThuongHieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocSanPham();
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

        private void SanPham_Form_FormClosing(object sender, FormClosingEventArgs e)
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
