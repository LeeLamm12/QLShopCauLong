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
    public partial class Admin_Form : Form
    {
        public Admin_Form()
        {
            InitializeComponent();
        }

        private void Admin_Form_Load(object sender, EventArgs e)
        {
            // Admin thì hiện hết, nhưng vẫn gọi để đồng nhất
            ApDungPhanQuyenSidebar();

            lbl_TenNguoiDung.Text = SessionBLL.TenNhanVien ?? SessionBLL.TenDangNhap;
            lbl_VaiTro.Text = "Quản trị hệ thống";

            LoadDashboardCards();
            LoadDoanhThuChart();
            LoadDoanhThuNhanVien();
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
            // btn_DangXuat luôn hiện
        }

        private void SetQuyen(Control btn, ChucNang cn, PhanQuyenBLL pq)
        {
            if (btn == null) return;
            btn.Visible = pq.CoQuyenTruyCap(cn);
        }

        private void LoadDashboardCards()
        {
            try
            {
                var data = new ThongKeBLL().LaySoLieuDashboard();
                txt_TongDoanhThu.Text = data.TongDoanhThu.ToString("N0") + " đ";
                txt_TongSoHoaDon.Text = data.TongHoaDon.ToString("N0");
                txt_TongSoSanPham.Text = data.TongSanPham.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu tổng quan: " + ex.Message);
            }
        }

        /* ========== CHART: 7 NGÀY GẦN NHẤT ========== */
        private void LoadDoanhThuChart()
        {
            int soNgay = 7;
            DateTime den = DateTime.Now.Date.AddDays(1).AddSeconds(-1); // hết ngày hôm nay 23:59:59
            DateTime tu = DateTime.Now.Date.AddDays(-soNgay + 1);        // đầu ngày, cách đây soNgay-1 ngày

            var raw = new ThongKeBLL().DoanhThuTheoNgay(tu, den);

            // Build dictionary: dd/MM/yyyy -> DoanhThu
            var dict = raw.ToDictionary(
                d => d.ThoiGian,           // "dd/MM/yyyy"
                d => (double)d.DoanhThu);

            var labels = new List<string>();
            var values = new List<double>();

            for (int i = 0; i < soNgay; i++)
            {
                DateTime ngay = tu.AddDays(i);
                string key = ngay.ToString("dd/MM/yyyy");
                labels.Add(ngay.ToString("dd/MM"));
                values.Add(dict.ContainsKey(key) ? dict[key] : 0);
            }

            formsPlot_DoanhThu.Plot.Clear();

            double[] xs = Enumerable.Range(0, soNgay).Select(i => (double)i).ToArray();
            double[] ys = values.ToArray();

            // Dùng Bar chart — không bị lỗi khi ít điểm
            var bars = formsPlot_DoanhThu.Plot.Add.Bars(xs, ys);
            bars.Color = ScottPlot.Color.FromHex("#05c7f8");

            // Trục X
            formsPlot_DoanhThu.Plot.Axes.Bottom.SetTicks(xs, labels.ToArray());

            // Lock trục Y từ 0
            formsPlot_DoanhThu.Plot.Axes.Left.Min = 0;

            // Style dark
            formsPlot_DoanhThu.Plot.FigureBackground.Color = ScottPlot.Color.FromHex("#011f51");
            formsPlot_DoanhThu.Plot.DataBackground.Color = ScottPlot.Color.FromHex("#011f51");

            formsPlot_DoanhThu.Plot.Axes.Color(ScottPlot.Color.FromHex("#f0f1f5"));
            formsPlot_DoanhThu.Plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#0c2f65");

            formsPlot_DoanhThu.Refresh();
        }

        /* ========== TOP NHÂN VIÊN ========== */
        private void LoadDoanhThuNhanVien()
        {
            FlowPanel_NhanVien.Controls.Clear();

            // Lấy toàn bộ lịch sử (null = không giới hạn ngày)
            var data = new ThongKeBLL().DoanhThuTheoNhanVien(null, null);

            if (data.Count == 0) return;

            decimal max = data.Max(d => d.DoanhThu);

            foreach (var item in data.Take(5))
            {
                var uc = new UcNhanVienRevenue();
                uc.SetData(item.HoTen, item.DoanhThu, max);
                uc.Width = FlowPanel_NhanVien.Width - 25;
                uc.Margin = new Padding(5);
                FlowPanel_NhanVien.Controls.Add(uc);
            }
        }

        private void panel_Admin_TongDoanhThu_Paint(object sender, PaintEventArgs e)
        {

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

        private void Admin_Form_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FlowPanel_NhanVien_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
