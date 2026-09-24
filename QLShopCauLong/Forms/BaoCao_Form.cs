using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using QLShopCauLong.BLL;
using QLShopCauLong.BLL.DTO;



namespace QLShopCauLong.Forms
{
    // Alias để tránh xung đột với System.Drawing.Font
    using iFont = iTextSharp.text.Font;

    public partial class BaoCao_Form : Form
    {

        private readonly ThongKeBLL thongKeBLL = new ThongKeBLL();
        private bool _isLoading = true;

        private readonly DateTime tuNgayMacDinh = new DateTime(2000, 1, 1);
        private readonly DateTime denNgayMacDinh = DateTime.Now;

        public BaoCao_Form()
        {
            InitializeComponent();
        }

        private void BaoCao_Form_Load(object sender, EventArgs e)
        {
            lbl_TenNguoiDung.Text = SessionBLL.TenNhanVien ?? SessionBLL.TenDangNhap;
            lbl_VaiTro.Text = SessionBLL.TaiKhoanHienTai?.VaiTro ?? "Nhân viên";
            ApDungPhanQuyenSidebar();

            dgv_BaoCao.RowHeadersVisible = false;
            _isLoading = true;

            cbb_LoaiBaoCao.Items.Clear();
            cbb_LoaiBaoCao.Items.Add("Doanh thu");
            cbb_LoaiBaoCao.Items.Add("Sản phẩm bán chạy");
            cbb_LoaiBaoCao.Items.Add("Tồn kho");
            cbb_LoaiBaoCao.Items.Add("Nhập hàng");
            cbb_LoaiBaoCao.Items.Add("Phương thức TT");
            cbb_LoaiBaoCao.Items.Add("Nhân viên");
            cbb_LoaiBaoCao.SelectedIndex = 0;

            _isLoading = false;

            LoadBaoCao();
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

        private void cbb_LoaiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            LoadBaoCao();
        }

        private void LoadBaoCao()
        {
            try
            {
                string loaiBaoCao = cbb_LoaiBaoCao.SelectedItem?.ToString();

                dgv_BaoCao.AutoGenerateColumns = true;
                dgv_BaoCao.DataSource = null;

                switch (loaiBaoCao)
                {
                    case "Doanh thu":
                        LoadBaoCaoDoanhThu();
                        break;

                    case "Sản phẩm bán chạy":
                        LoadBaoCaoSanPhamBanChay();
                        break;

                    case "Tồn kho":
                        LoadBaoCaoTonKho();
                        break;

                    case "Nhập hàng":
                        LoadBaoCaoNhapHang();
                        break;

                    case "Phương thức TT":
                        LoadBaoCaoPhuongThucTT();
                        break;

                    case "Nhân viên":
                        LoadBaoCaoNhanVien();
                        break;
                }

                // Số dòng dữ liệu — tính chung cho mọi loại báo cáo, luôn chính xác
                txt_SoDongDuLieu.Text = dgv_BaoCao.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== DOANH THU =====
        private void LoadBaoCaoDoanhThu()
        {
            var list = thongKeBLL.DoanhThuTheoNgay(tuNgayMacDinh, denNgayMacDinh);

            var displayList = list.Select((x, index) => new
            {
                STT = index + 1,
                Ngay = x.ThoiGian,
                SoLuongHoaDon = x.SoLuongHoaDon,
                DoanhThu = x.DoanhThu
            }).ToList();

            dgv_BaoCao.DataSource = displayList;
            SuaTieuDeCot();

            var (tongDoanhThu, tongHoaDon) = thongKeBLL.TongKetDoanhThu(tuNgayMacDinh, denNgayMacDinh);
            txt_TongDoanhThu.Text = tongDoanhThu.ToString("#,##0") + " đ";
            txt_SoLuongHoaDon.Text = tongHoaDon.ToString();
        }

        // ===== SẢN PHẨM BÁN CHẠY =====
        private void LoadBaoCaoSanPhamBanChay()
        {
            var list = thongKeBLL.SanPhamBanChay(tuNgayMacDinh, denNgayMacDinh, 20);

            var displayList = list.Select((x, index) => new
            {
                STT = index + 1,
                MaSanPham = x.MaSanPham,
                TenSanPham = x.TenSanPham,
                ThuongHieu = x.ThuongHieu,
                SoLuongBan = x.TongSoLuongBan,
                DoanhThu = x.TongDoanhThu
            }).ToList();

            dgv_BaoCao.DataSource = displayList;
            SuaTieuDeCot();

            decimal tongDT = list.Sum(x => x.TongDoanhThu);
            int tongSL = list.Sum(x => x.TongSoLuongBan);
            txt_TongDoanhThu.Text = tongDT.ToString("#,##0") + " đ";
            txt_SoLuongHoaDon.Text = tongSL.ToString();
        }

        // ===== TỒN KHO =====
        private void LoadBaoCaoTonKho()
        {
            var list = thongKeBLL.ThongKeTonKho();

            var displayList = list.Select((x, index) => new
            {
                STT = index + 1,
                MaSanPham = x.MaSanPham,
                TenSanPham = x.TenSanPham,
                DanhMuc = x.TenDanhMuc,
                SoLuongTon = x.SoLuongTon
            }).ToList();

            dgv_BaoCao.DataSource = displayList;
            SuaTieuDeCot();

            int tongTon = list.Sum(x => x.SoLuongTon);
            txt_TongDoanhThu.Text = "—";
            txt_SoLuongHoaDon.Text = tongTon.ToString();
        }

        // ===== NHẬP HÀNG =====
        private void LoadBaoCaoNhapHang()
        {
            var list = thongKeBLL.ThongKeNhapTheoNCC(tuNgayMacDinh, denNgayMacDinh);

            var displayList = list.Select((x, index) => new
            {
                STT = index + 1,
                MaNCC = x.MaNCC,
                TenNCC = x.TenNCC,
                SoPhieuNhap = x.SoPhieuNhap,
                TongTienNhap = x.TongTienNhap
            }).ToList();

            dgv_BaoCao.DataSource = displayList;
            SuaTieuDeCot();

            decimal tongTien = list.Sum(x => x.TongTienNhap);
            int tongPhieu = list.Sum(x => x.SoPhieuNhap);
            txt_TongDoanhThu.Text = tongTien.ToString("#,##0") + " đ";
            txt_SoLuongHoaDon.Text = tongPhieu.ToString();
        }

        // ===== PHƯƠNG THỨC THANH TOÁN =====
        private void LoadBaoCaoPhuongThucTT()
        {
            var list = thongKeBLL.ThongKePhuongThucTT(tuNgayMacDinh, denNgayMacDinh);

            var displayList = list.Select((x, index) => new
            {
                STT = index + 1,
                PhuongThuc = x.PhuongThuc,
                SoLuong = x.SoLuong,
                TongTien = x.TongTien,
                TyLePhanTram = Math.Round(x.TyLePhanTram, 1) + " %"
            }).ToList();

            dgv_BaoCao.DataSource = displayList;
            SuaTieuDeCot();

            decimal tongTien = list.Sum(x => x.TongTien);
            int tongSL = list.Sum(x => x.SoLuong);
            txt_TongDoanhThu.Text = tongTien.ToString("#,##0") + " đ";
            txt_SoLuongHoaDon.Text = tongSL.ToString();
        }

        // ===== NHÂN VIÊN =====
        private void LoadBaoCaoNhanVien()
        {
            var list = thongKeBLL.DoanhThuTheoNhanVien(tuNgayMacDinh, denNgayMacDinh);

            var displayList = list.Select((x, index) => new
            {
                STT = index + 1,
                MaNhanVien = x.MaNhanVien,
                HoTen = x.HoTen,
                SoHoaDon = x.SoHoaDon,
                DoanhThu = x.DoanhThu
            }).ToList();

            dgv_BaoCao.DataSource = displayList;
            SuaTieuDeCot();

            decimal tongDT = list.Sum(x => x.DoanhThu);
            int tongHD = list.Sum(x => x.SoHoaDon);
            txt_TongDoanhThu.Text = tongDT.ToString("#,##0") + " đ";
            txt_SoLuongHoaDon.Text = tongHD.ToString();
        }

        private void SuaTieuDeCot()
        {
            var tieuDe = new Dictionary<string, string>
    {
        { "STT", "STT" },
        { "Ngay", "Ngày" },
        { "SoLuongHoaDon", "Số lượng hóa đơn" },
        { "DoanhThu", "Doanh thu" },
        { "MaSanPham", "Mã SP" },
        { "TenSanPham", "Tên sản phẩm" },
        { "ThuongHieu", "Thương hiệu" },
        { "SoLuongBan", "Số lượng bán" },
        { "DanhMuc", "Danh mục" },
        { "Size", "Size" },
        { "SoLuongTon", "Số lượng tồn" },
        { "MaNCC", "Mã NCC" },
        { "TenNCC", "Tên nhà cung cấp" },
        { "SoPhieuNhap", "Số phiếu nhập" },
        { "TongTienNhap", "Tổng tiền nhập" },
        { "PhuongThuc", "Phương thức TT" },
        { "SoLuong", "Số lượng" },
        { "TongTien", "Tổng tiền" },
        { "TyLePhanTram", "Tỷ lệ %" },
        { "MaNhanVien", "Mã NV" },
        { "HoTen", "Họ tên" },
        { "SoHoaDon", "Số hóa đơn" }
    };

            foreach (DataGridViewColumn col in dgv_BaoCao.Columns)
            {
                if (tieuDe.ContainsKey(col.Name))
                    col.HeaderText = tieuDe[col.Name];

                if (col.ValueType == typeof(decimal))
                    col.DefaultCellStyle.Format = "#,##0";

                // Cột STT nên hẹp và căn giữa cho gọn
                if (col.Name == "STT")
                {
                    col.Width = 50;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void btn_XuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string tieuDe = "Báo cáo " + cbb_LoaiBaoCao.SelectedItem?.ToString();
                string tenSheet = cbb_LoaiBaoCao.SelectedItem?.ToString()?.Replace(" ", "") ?? "BaoCao";

                ExcelExportHelper.ExportDataGridView(dgv_BaoCao, tenSheet, tieuDe);

                MessageBox.Show("Xuất Excel thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_XuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_BaoCao.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất báo cáo.");
                    return;
                }

                string loaiBaoCao = cbb_LoaiBaoCao.Text;

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.FileName = $"BaoCao_{loaiBaoCao}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // ── Load font hỗ trợ tiếng Việt ──
                        string fontPath = Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                        if (!File.Exists(fontPath))
                            fontPath = Path.Combine(
                                Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "tahoma.ttf");

                        BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        iFont fontTitle = new iFont(bf, 20, iFont.BOLD, new BaseColor(59, 130, 246));
                        iFont fontInfo = new iFont(bf, 11, iFont.NORMAL, new BaseColor(102, 102, 102));
                        iFont fontHeader = new iFont(bf, 11, iFont.BOLD, BaseColor.WHITE);
                        iFont fontCell = new iFont(bf, 10, iFont.NORMAL, new BaseColor(26, 26, 46));
                        iFont fontLabel = new iFont(bf, 10, iFont.NORMAL, new BaseColor(102, 102, 102));
                        iFont fontValue = new iFont(bf, 16, iFont.BOLD, new BaseColor(16, 185, 129));

                        Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        // ===== TIÊU ĐỀ =====
                        Paragraph title = new Paragraph($"Báo cáo {loaiBaoCao}", fontTitle);
                        title.SpacingAfter = 5;
                        doc.Add(title);

                        // ===== THÔNG TIN =====
                        Paragraph info = new Paragraph(
                            $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm} | Người xuất: {SessionBLL.TenNhanVien}",
                            fontInfo);
                        info.SpacingAfter = 15;
                        doc.Add(info);

                        // ===== BẢNG DỮ LIỆU =====
                        var visibleCols = dgv_BaoCao.Columns
                            .Cast<DataGridViewColumn>()
                            .Where(c => c.Visible)
                            .ToList();

                        PdfPTable table = new PdfPTable(visibleCols.Count);
                        table.WidthPercentage = 100;
                        table.SpacingAfter = 20;

                        // Header
                        BaseColor headerColor = new BaseColor(59, 130, 246);
                        foreach (var col in visibleCols)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, fontHeader));
                            cell.BackgroundColor = headerColor;
                            cell.Padding = 8;
                            cell.BorderColor = new BaseColor(221, 221, 221);
                            table.AddCell(cell);
                        }

                        // Rows (alternating color)
                        BaseColor evenColor = new BaseColor(245, 247, 250);
                        int rowIdx = 0;

                        foreach (DataGridViewRow row in dgv_BaoCao.Rows)
                        {
                            if (row.IsNewRow) continue;

                            foreach (var col in visibleCols)
                            {
                                string val = row.Cells[col.Index].Value?.ToString() ?? "";
                                PdfPCell cell = new PdfPCell(new Phrase(val, fontCell));
                                cell.Padding = 6;
                                cell.BorderColor = new BaseColor(221, 221, 221);

                                if (rowIdx % 2 == 1)
                                    cell.BackgroundColor = evenColor;

                                table.AddCell(cell);
                            }
                            rowIdx++;
                        }
                        doc.Add(table);

                        // ===== 3 STAT BOX =====
                        PdfPTable statsTable = new PdfPTable(3);
                        statsTable.WidthPercentage = 100;
                        statsTable.SetWidths(new float[] { 1f, 1f, 1f });

                        AddStatBox(statsTable, "Tổng doanh thu", txt_TongDoanhThu.Text, fontLabel, fontValue);
                        AddStatBox(statsTable, "Số dòng dữ liệu", txt_SoDongDuLieu.Text, fontLabel, fontValue);
                        AddStatBox(statsTable, "Số lượng hóa đơn", txt_SoLuongHoaDon.Text, fontLabel, fontValue);

                        doc.Add(statsTable);
                        doc.Close();

                        MessageBox.Show("Xuất báo cáo PDF thành công!");
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF: " + ex.Message);
            }
        }

        private void AddStatBox(PdfPTable table, string label, string value, iFont fontLabel, iFont fontValue)
        {
            PdfPCell cell = new PdfPCell();
            cell.BorderColor = new BaseColor(221, 221, 221);
            cell.BorderWidth = 1;
            cell.Padding = 15;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;

            Paragraph pLabel = new Paragraph(label, fontLabel);
            pLabel.Alignment = Element.ALIGN_CENTER;
            pLabel.SpacingAfter = 5;

            Paragraph pValue = new Paragraph(value, fontValue);
            pValue.Alignment = Element.ALIGN_CENTER;

            cell.AddElement(pLabel);
            cell.AddElement(pValue);
            table.AddCell(cell);
        }

        private void txt_TimKiemNangCao_TextChanged(object sender, EventArgs e)
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

        private void BaoCao_Form_FormClosing(object sender, FormClosingEventArgs e)
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
