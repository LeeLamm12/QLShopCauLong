using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLShopCauLong.BLL;

namespace QLShopCauLong
{
    public partial class SanPham_ThemSua : Form
    {
        private bool laThemMoi;
        private string maSPDangSua;

        public SanPham_ThemSua()
        {
            InitializeComponent();
            laThemMoi = true;
        }
        public SanPham_ThemSua(string maSP)
        {
            InitializeComponent();
            laThemMoi = false;
            maSPDangSua = maSP;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            // Chỉ parse dữ liệu từ form
            if (!decimal.TryParse(txt_DonGia.Text.Replace(",", "").Replace(".", ""), out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_DonGia.Focus();
                return;
            }

            if (!int.TryParse(num_SoLuong.Text, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string thuongHieuMoi = cbb_ThuongHieu.SelectedItem?.ToString()
                                   ?? cbb_ThuongHieu.Text.Trim();

            if (string.IsNullOrEmpty(thuongHieuMoi))
            {
                MessageBox.Show("Vui lòng chọn hoặc thêm thương hiệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbb_ThuongHieu.Focus();
                return;
            }

            // Tạo entity (khớp với BLL đang nhận SanPham)
            var sp = new SanPham
            {
                MaSanPham = txt_MaSanPham.Text.Trim(),
                TenSanPham = txt_TenSanPham.Text.Trim(),
                MaDanhMuc = cbb_DanhMuc.SelectedValue?.ToString(),
                ThuongHieu = thuongHieuMoi,
                DonGia = donGia
            };

            var dsSize = new List<ChiTietKho>
            {
                new ChiTietKho { Size = 0, SoLuongTon = soLuong }
            };

            // Gọi BLL — validate (bao gồm định dạng mã SPxxx, trùng Tên+Thương hiệu) đã nằm trong này rồi
            var (thanhCong, dsLoi) = laThemMoi
                ? new SanPhamBLL().Them(sp, dsSize)
                : new SanPhamBLL().Sua(sp, dsSize);

            if (!thanhCong)
            {
                MessageBox.Show(string.Join("\n", dsLoi), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thương hiệu mới nhập sẽ tự động xuất hiện ở mọi nơi lọc, vì các nơi đó
            // đều load Distinct() trực tiếp từ SanPhamBLL().LayDanhSach() — không cần đồng bộ thủ công.

            MessageBox.Show(laThemMoi ? "Thêm thành công!" : "Cập nhật thành công!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SanPham_ThemSua_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadThuongHieu();

            if (laThemMoi)
            {
                txt_MaSanPham.Text = new SanPhamBLL().SinhMaMoi();
                txt_MaSanPham.ReadOnly = true;
            }
            else
            {
                LoadDuLieuSua();
                txt_MaSanPham.ReadOnly = true;
            }
        }

        private void LoadDanhMuc()
        {
            var dsDanhMuc = new DanhMucBLL().LayDanhSach();
            cbb_DanhMuc.DataSource = dsDanhMuc;
            cbb_DanhMuc.DisplayMember = "TenDanhMuc";
            cbb_DanhMuc.ValueMember = "MaDanhMuc";
        }

        // Guna2ComboBox không hỗ trợ gõ tự do dù DropDownStyle = DropDown,
        // nên để DropDownList và dùng nút "+ Mới" (btn_ThemThuongHieuMoi) để thêm thương hiệu mới.
        private void LoadThuongHieu()
        {
            cbb_ThuongHieu.DataSource = null;
            cbb_ThuongHieu.Items.Clear();

            var dsTH = new SanPhamBLL().LayDanhSach()
                .Select(sp => sp.ThuongHieu)
                .Where(th => !string.IsNullOrEmpty(th))
                .Distinct()
                .OrderBy(th => th)
                .ToList();

            cbb_ThuongHieu.Items.AddRange(dsTH.ToArray());
            cbb_ThuongHieu.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void LoadDuLieuSua()
        {
            var sp = new SanPhamBLL().LayDanhSach()
                          .FirstOrDefault(x => x.MaSanPham == maSPDangSua);
            if (sp == null) return;

            txt_MaSanPham.Text = sp.MaSanPham;
            txt_TenSanPham.Text = sp.TenSanPham;

            // Vì cbb_ThuongHieu giờ là DropDownList, đảm bảo thương hiệu của sản phẩm
            // đang sửa có trong danh sách item (phòng trường hợp dữ liệu cũ có khoảng trắng lệch)
            string th = (sp.ThuongHieu ?? "").Trim();
            if (!string.IsNullOrEmpty(th) && !cbb_ThuongHieu.Items.Contains(th))
                cbb_ThuongHieu.Items.Add(th);
            cbb_ThuongHieu.SelectedItem = th;

            txt_DonGia.Text = sp.DonGia.ToString();
            cbb_DanhMuc.SelectedValue = sp.MaDanhMuc;

            int tongSoLuong = sp.ChiTietKho?.Sum(ct => ct.SoLuongTon) ?? 0;
            num_SoLuong.Text = tongSoLuong.ToString();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_ChonAnhVot_Click(object sender, EventArgs e)
        {

        }

        private void btn_ThemThuongHieuMoi_Click(object sender, EventArgs e)
        {
            string thNhap = HienThiHopThoaiNhapText("Thêm thương hiệu mới", "Tên thương hiệu:");
            if (string.IsNullOrWhiteSpace(thNhap)) return;

            // Chuẩn hóa để tránh trùng do khác hoa/thường ("Yonex" vs "yonex")
            string thChuanHoa = new SanPhamBLL().ChuanHoaThuongHieu(thNhap);

            if (!cbb_ThuongHieu.Items.Contains(thChuanHoa))
                cbb_ThuongHieu.Items.Add(thChuanHoa);

            cbb_ThuongHieu.SelectedItem = thChuanHoa;
        }

        // Hộp thoại nhập text đơn giản, tự tạo bằng code, không cần thêm form mới trong project
        private string HienThiHopThoaiNhapText(string tieuDe, string nhan)
        {
            using (Form f = new Form())
            {
                f.Text = tieuDe;
                f.StartPosition = FormStartPosition.CenterParent;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.MinimizeBox = false;
                f.MaximizeBox = false;
                f.ClientSize = new Size(320, 120);

                Label lbl = new Label { Left = 15, Top = 15, Text = nhan, AutoSize = true };
                TextBox txt = new TextBox { Left = 15, Top = 40, Width = 290 };
                Button btnOk = new Button { Text = "OK", Left = 140, Width = 75, Top = 75, DialogResult = DialogResult.OK };
                Button btnCancel = new Button { Text = "Hủy", Left = 225, Width = 75, Top = 75, DialogResult = DialogResult.Cancel };

                f.Controls.Add(lbl);
                f.Controls.Add(txt);
                f.Controls.Add(btnOk);
                f.Controls.Add(btnCancel);
                f.AcceptButton = btnOk;
                f.CancelButton = btnCancel;

                return f.ShowDialog(this) == DialogResult.OK ? txt.Text.Trim() : null;
            }
        }
    }
}