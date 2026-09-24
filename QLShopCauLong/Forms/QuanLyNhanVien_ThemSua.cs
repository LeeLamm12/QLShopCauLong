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
    public partial class QuanLyNhanVien_ThemSua : Form
    {
        private string maNVSua = null;
        public QuanLyNhanVien_ThemSua()
        {
            InitializeComponent();
            this.Text = "Thêm nhân viên";
            txt_MaNhanVien.ReadOnly = true;
            txt_MaNhanVien.Text = SinhMaNV();
            SetupComboBoxes();
        }

        // Constructor SỬA
        public QuanLyNhanVien_ThemSua(string maNV)
        {
            InitializeComponent();
            this.Text = "Sửa nhân viên";
            this.maNVSua = maNV;
            txt_MaNhanVien.ReadOnly = true;
            SetupComboBoxes();
            LoadDuLieu();
        }

        private void SetupComboBoxes()
        {
            // --- Giới tính: lấy DISTINCT từ dữ liệu thật trong DB ---
            cbb_GioiTinh.Items.Clear();
            try
            {
                var dsGioiTinh = new NhanVienBLL().LayDanhSach()
                    .Select(nv => nv.GioiTinh)
                    .Where(g => !string.IsNullOrEmpty(g))
                    .Select(g => g.Trim())
                    .Distinct()
                    .OrderBy(g => g)
                    .ToList();

                foreach (var gt in dsGioiTinh)
                    cbb_GioiTinh.Items.Add(gt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load giới tính: " + ex.Message);
            }

            if (cbb_GioiTinh.Items.Count > 0)
                cbb_GioiTinh.SelectedIndex = 0;

            // --- Chức vụ: lấy DISTINCT từ dữ liệu thật trong DB ---
            cbb_ChucVu.Items.Clear();
            try
            {
                var dsChucVu = new NhanVienBLL().LayDanhSach()
                    .Select(nv => nv.ChucVu)
                    .Where(c => !string.IsNullOrEmpty(c))
                    .Select(c => c.Trim())
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();

                foreach (var cv in dsChucVu)
                    cbb_ChucVu.Items.Add(cv);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load chức vụ: " + ex.Message);
            }

            if (cbb_ChucVu.Items.Count > 0)
                cbb_ChucVu.SelectedIndex = 0;
        }

        private string SinhMaNV()
        {
            var ds = new NhanVienBLL().LayDanhSach();
            int max = 0;

            foreach (var n in ds)
            {
                if (n.MaNhanVien != null && n.MaNhanVien.StartsWith("NV") && n.MaNhanVien.Length > 2)
                {
                    if (int.TryParse(n.MaNhanVien.Substring(2), out int so))
                    {
                        if (so > max) max = so;
                    }
                }
            }

            return "NV" + (max + 1).ToString("D3");
        }

        private void LoadDuLieu()
        {
            var nv = new NhanVienBLL().LayTheoMa(maNVSua);
            if (nv == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            txt_MaNhanVien.Text = nv.MaNhanVien;
            txt_HoTen.Text = nv.HoTen;
            txt_SDT.Text = nv.SoDienThoai;
            txt_Email.Text = nv.Email;
            txt_DiaChi.Text = nv.DiaChi;
            cbb_GioiTinh.Text = nv.GioiTinh;
            if (nv.NgaySinh.HasValue)
                DTimePic_NgaySinh.Value = nv.NgaySinh.Value;
            cbb_ChucVu.Text = nv.ChucVu;
            if (nv.NgayVaoLam.HasValue)
                DTimePic_NgayVaoLam.Value = nv.NgayVaoLam.Value;
            num_Luong.Value = nv.Luong ?? 0;
        }

        private void QuanLyNhanVien_ThemSua_Load(object sender, EventArgs e)
        {

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            var nv = new NhanVien
            {
                MaNhanVien = txt_MaNhanVien.Text.Trim(),
                HoTen = txt_HoTen.Text.Trim(),
                GioiTinh = cbb_GioiTinh.Text,
                NgaySinh = DTimePic_NgaySinh.Value,
                SoDienThoai = txt_SDT.Text.Trim(),
                Email = txt_Email.Text.Trim(),
                DiaChi = txt_DiaChi.Text.Trim(),
                ChucVu = cbb_ChucVu.Text,
                NgayVaoLam = DTimePic_NgayVaoLam.Value,
                Luong = (decimal?)num_Luong.Value
            };

            (bool thanhCong, var loi) = string.IsNullOrEmpty(maNVSua)
                ? new NhanVienBLL().Them(nv)
                : new NhanVienBLL().Sua(nv);

            if (thanhCong)
            {
                MessageBox.Show(string.IsNullOrEmpty(maNVSua) ? "Thêm thành công!" : "Sửa thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(string.Join("\n", loi), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
