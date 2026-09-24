using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLShopCauLong.BLL;

namespace QLShopCauLong.Forms
{

    public partial class User_Form : Form
    {
        private List<ChiTietHoaDon> gioHang = new List<ChiTietHoaDon>();
        private SanPham sanPhamDangChon;
        private List<SanPham> dsSanPham;

        public User_Form()
        {
            InitializeComponent();
        }

        private void User_Form_Load(object sender, EventArgs e)
        {
            ApDungPhanQuyenSidebar();

            lbl_XinChao.Text = "Xin chào, " + SessionBLL.TenNhanVien;
            lbl_TenNguoiDung.Text = SessionBLL.TenNhanVien;
            lbl_VaiTro.Text = SessionBLL.TaiKhoanHienTai?.VaiTro ?? "Nhân viên"; // thêm dòng này

            LoadKhachHang();
            LoadSanPhamVaoComboBox();
            LoadStatCard();
        }

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
        }

        private void SetQuyen(Control btn, ChucNang cn, PhanQuyenBLL pq)
        {
            if (btn == null) return;
            btn.Visible = pq.CoQuyenTruyCap(cn);
        }

        private void LoadSanPhamVaoComboBox()
        {
            dsSanPham = new SanPhamBLL().LayDanhSach();
            cbb_SanPham.DataSource = null;
            cbb_SanPham.DataSource = dsSanPham;
            cbb_SanPham.DisplayMember = "TenSanPham";
            cbb_SanPham.ValueMember = "MaSanPham";
            cbb_SanPham.SelectedIndex = -1;
        }

        private void LoadStatCard()
        {
            try
            {
                var (soHoaDon, doanhThu) = new ThongKeBLL()
                    .ThongKeCaTruc(SessionBLL.MaNhanVien, DateTime.Now);

                txt_SoHoaDonDaLap.Text = soHoaDon.ToString();
                txt_DoanhThuCaTruc.Text = doanhThu.ToString("#,##0") + " đ";

                var dsHD = new HoaDonBLL().LayDanhSach()
                    .Where(hd => hd.MaNhanVien == SessionBLL.MaNhanVien
                              && hd.NgayLap.HasValue
                              && hd.NgayLap.Value.Date == DateTime.Now.Date)
                    .ToList();

                int soLuongDaBan = dsHD.Sum(hd => hd.ChiTietHoaDon.Sum(ct => ct.SoLuong));
                txt_SoLuongSPDaBan.Text = soLuongDaBan.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thống kê: " + ex.Message);
            }
        }

        private void LoadKhachHang()
        {
            var ds = new KhachHangBLL().LayDanhSach();
            cbb_KhachHang.DataSource = null;
            cbb_KhachHang.DataSource = ds;
            cbb_KhachHang.DisplayMember = "HoTen";
            cbb_KhachHang.ValueMember = "MaKhachHang";
            cbb_KhachHang.SelectedIndex = -1;
        }

        private void btn_ThemKhachHang_Click(object sender, EventArgs e)
        {
            var frm = new QuanLyKhachHang_ThemSua();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadKhachHang();
                if (cbb_KhachHang.Items.Count > 0)
                    cbb_KhachHang.SelectedIndex = cbb_KhachHang.Items.Count - 1;
            }
        }

        private void btn_ThemVaoGIoHang_Click(object sender, EventArgs e)
        {
            if (sanPhamDangChon == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước.");
                return;
            }

            int soLuong = (int)num_SoLuong.Value;
            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0.");
                return;
            }

            int soLuongTon = 0;
            if (sanPhamDangChon.ChiTietKho != null)
            {
                soLuongTon = sanPhamDangChon.ChiTietKho.Sum(k => k.SoLuongTon);
            }

            if (soLuongTon <= 0)
            {
                MessageBox.Show("Sản phẩm đã hết hàng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dongDaCo = gioHang.FirstOrDefault(x => x.MaSanPham == sanPhamDangChon.MaSanPham);
            int daCo = dongDaCo?.SoLuong ?? 0;

            if (daCo + soLuong > soLuongTon)
            {
                MessageBox.Show($"Không đủ tồn kho. Chỉ còn {soLuongTon} sản phẩm.");
                return;
            }

            if (dongDaCo != null)
            {
                dongDaCo.SoLuong += soLuong;
            }
            else
            {
                gioHang.Add(new ChiTietHoaDon
                {
                    MaSanPham = sanPhamDangChon.MaSanPham,
                    Size = 0,
                    SoLuong = soLuong,
                    DonGia = sanPhamDangChon.DonGia
                });
            }

            RefreshGioHang();

            cbb_SanPham.SelectedIndex = -1;
            cbb_SanPham.Text = "";
            txt_DonGia.Text = "0 đ";
            num_SoLuong.Value = 1;
            sanPhamDangChon = null;
        }

        private void RefreshGioHang()
        {
            dgv_GioHang.Rows.Clear();

            foreach (var ct in gioHang)
            {
                var sp = dsSanPham.FirstOrDefault(x => x.MaSanPham == ct.MaSanPham);
                string tenSP = sp != null ? $"{sp.TenSanPham} x{ct.SoLuong}" : ct.MaSanPham;
                string thanhTien = (ct.SoLuong * ct.DonGia).ToString("#,##0") + " đ";

                int idx = dgv_GioHang.Rows.Add(tenSP, thanhTien);
                dgv_GioHang.Rows[idx].Tag = ct.MaSanPham;
            }
        }

        private void dgv_GioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgv_GioHang.Columns[e.ColumnIndex].Name != "colXoaGio") return;

            string maSP = dgv_GioHang.Rows[e.RowIndex].Tag?.ToString();
            if (string.IsNullOrEmpty(maSP)) return;

            gioHang.RemoveAll(x => x.MaSanPham == maSP);
            RefreshGioHang();
        }

        private void btn_XoaTatCa_Click(object sender, EventArgs e)
        {
            gioHang.Clear();
            RefreshGioHang();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            gioHang.Clear();
            RefreshGioHang();
            cbb_SanPham.SelectedIndex = -1;
            cbb_SanPham.Text = "";
            txt_DonGia.Text = "0 đ";
            num_SoLuong.Value = 1;
            cbb_KhachHang.SelectedIndex = -1;
            sanPhamDangChon = null;
        }

        private string SinhMaHoaDon()
        {
            var ds = new HoaDonBLL().LayDanhSach();
            int max = 0;

            foreach (var hd in ds)
            {
                if (hd.MaHoaDon != null && hd.MaHoaDon.StartsWith("HD") && hd.MaHoaDon.Length > 2)
                {
                    if (int.TryParse(hd.MaHoaDon.Substring(2), out int so))
                    {
                        if (so > max) max = so;
                    }
                }
            }

            return "HD" + (max + 1).ToString("D3");
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if (gioHang.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }

            if (string.IsNullOrEmpty(SessionBLL.MaNhanVien))
            {
                MessageBox.Show("Lỗi: Không xác định được nhân viên. Vui lòng đăng nhập lại.");
                return;
            }

            string maKH = cbb_KhachHang.SelectedValue?.ToString();
            if (string.IsNullOrEmpty(maKH)) maKH = "KH000";

            string maHD = SinhMaHoaDon();

            var hoaDon = new HoaDon
            {
                MaHoaDon = maHD,
                MaKhachHang = maKH,
                MaNhanVien = SessionBLL.MaNhanVien,
                NgayLap = DateTime.Now,
                PhuongThucThanhToan = "Tiền mặt"
            };

            var (thanhCong, loi) = new HoaDonBLL().Them(hoaDon, gioHang);

            if (thanhCong)
            {
                MessageBox.Show("Lập hóa đơn thành công!\nMã: " + maHD,
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                gioHang.Clear();
                RefreshGioHang();
                LoadStatCard();
                dsSanPham = new SanPhamBLL().LayDanhSach();
                LoadSanPhamVaoComboBox();
            }
            else
            {
                MessageBox.Show(string.Join("\n", loi), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbb_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_SanPham.SelectedIndex < 0 || cbb_SanPham.SelectedValue == null)
            {
                sanPhamDangChon = null;
                txt_DonGia.Text = "0 đ";
                return;
            }

            string maSP = cbb_SanPham.SelectedValue.ToString();
            sanPhamDangChon = dsSanPham.FirstOrDefault(x => x.MaSanPham == maSP);

            if (sanPhamDangChon != null)
            {
                txt_DonGia.Text = sanPhamDangChon.DonGia.ToString("#,##0") + " đ";
                num_SoLuong.Value = 1;
            }
        }

        private void cbb_SanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string tuKhoa = cbb_SanPham.Text.Trim();
            if (string.IsNullOrEmpty(tuKhoa)) return;

            var ketQua = dsSanPham.FirstOrDefault(
                x => x.TenSanPham.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0);

            if (ketQua != null)
            {
                cbb_SanPham.SelectedValue = ketQua.MaSanPham;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                sanPhamDangChon = null;
                txt_DonGia.Text = "0 đ";
            }
        }

        private void btn_TrangChu_Click(object sender, EventArgs e) { }

        private void btn_SanPham_Click(object sender, EventArgs e) => MoForm(new SanPham_Form());
        private void btn_HoaDon_Click(object sender, EventArgs e) => MoForm(new HoaDon_Form());
        private void btn_KhachHang_Click(object sender, EventArgs e) => MoForm(new QuanLyKhachHang_Form());

        private void MoForm(Form frm)
        {
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
            this.Hide();
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            SessionBLL.XacNhanVaDangXuat(this);
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
        }

        private void User_Form_FormClosing(object sender, FormClosingEventArgs e)
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