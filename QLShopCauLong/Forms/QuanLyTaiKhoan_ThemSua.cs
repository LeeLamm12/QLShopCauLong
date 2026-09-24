using System;
using System.Linq;
using System.Windows.Forms;
using QLShopCauLong.BLL;

namespace QLShopCauLong.Forms
{
    public partial class QuanLyTaiKhoan_ThemSua : Form
    {
        private readonly TaiKhoan _taiKhoanDangSua; // null = thêm mới, khác null = sửa
        public QuanLyTaiKhoan_ThemSua()
        {
            InitializeComponent();
            _taiKhoanDangSua = null;
        }

        // Constructor: SỬA
        public QuanLyTaiKhoan_ThemSua(TaiKhoan tk)
        {
            InitializeComponent();
            _taiKhoanDangSua = tk;
        }

        private void QuanLyTaiKhoan_ThemSua_Load(object sender, EventArgs e)
        {
            LoadComboNhanVien();
            LoadComboVaiTro();

            if (_taiKhoanDangSua != null)
            {
                this.Text = "Sửa tài khoản";
                txt_TenDangNhap.Text = _taiKhoanDangSua.TenDangNhap;
                txt_TenDangNhap.Enabled = false;

                cbb_ChonNhanVien.SelectedValue = _taiKhoanDangSua.MaNhanVien;
                cbb_ChonNhanVien.Enabled = false; // không cho đổi nhân viên khi sửa, vì DAL không hỗ trợ cập nhật trường này

                cbb_VaiTro.SelectedItem = _taiKhoanDangSua.VaiTro;
                txt_MatKhau.Text = "";
            }
            else
            {
                this.Text = "Thêm tài khoản";
            }
        }

        private void LoadComboNhanVien()
        {
            var nvBLL = new NhanVienBLL();
            var dsNV = nvBLL.LayDanhSach().ToList();

            if (_taiKhoanDangSua == null) // Thêm mới: chỉ NV chưa có tài khoản
            {
                dsNV = dsNV.Where(nv => !nvBLL.DaCoTaiKhoan(nv.MaNhanVien)).ToList();
            }
            else // Sửa: đảm bảo NV hiện tại của tài khoản này vẫn có mặt trong danh sách
            {
                dsNV = dsNV.Where(nv => nv.MaNhanVien == _taiKhoanDangSua.MaNhanVien).ToList();
            }

            cbb_ChonNhanVien.DisplayMember = "HoTen";
            cbb_ChonNhanVien.ValueMember = "MaNhanVien";
            cbb_ChonNhanVien.DataSource = dsNV;
        }

        private void LoadComboVaiTro()
        {
            cbb_VaiTro.Items.Clear();

            var dsVaiTro = new TaiKhoanBLL().LayDanhSach()
                .Select(tk => tk.VaiTro)
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .Distinct()
                .OrderBy(v => v)
                .ToList();

            foreach (var vt in dsVaiTro)
                cbb_VaiTro.Items.Add(vt);

            // Chọn mặc định "Nhân viên" nếu có, không thì chọn item đầu tiên
            int idx = cbb_VaiTro.Items.IndexOf("Nhân viên");
            cbb_VaiTro.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                bool laThemMoi = (_taiKhoanDangSua == null);

                var tk = laThemMoi ? new TaiKhoan() : _taiKhoanDangSua;

                tk.TenDangNhap = txt_TenDangNhap.Text.Trim();
                tk.MaNhanVien = cbb_ChonNhanVien.SelectedValue?.ToString();
                tk.VaiTro = cbb_VaiTro.SelectedItem?.ToString();

                if (laThemMoi)
                {
                    tk.MatKhau = txt_MatKhau.Text; // BLL.Them sẽ tự mã hóa
                    tk.TrangThai = true;
                }
                else
                {
                    // Sửa: nếu để trống mật khẩu -> giữ nguyên mật khẩu cũ (đã mã hóa)
                    if (!string.IsNullOrWhiteSpace(txt_MatKhau.Text))
                        tk.MatKhau = txt_MatKhau.Text; // BLL.Sua tự mã hóa nếu chưa phải hash 64 ký tự
                    // nếu để trống, tk.MatKhau vẫn giữ giá trị hash cũ vì tk = _taiKhoanDangSua
                }

                (bool ThanhCong, System.Collections.Generic.List<string> Loi) ketQua;

                if (laThemMoi)
                    ketQua = new TaiKhoanBLL().Them(tk);
                else
                    ketQua = new TaiKhoanBLL().Sua(tk);

                if (ketQua.ThanhCong)
                {
                    MessageBox.Show(laThemMoi ? "Thêm tài khoản thành công." : "Cập nhật tài khoản thành công.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(string.Join("\n", ketQua.Loi), "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
