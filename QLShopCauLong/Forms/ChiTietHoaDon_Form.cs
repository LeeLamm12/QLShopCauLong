using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iFont = iTextSharp.text.Font;

namespace QLShopCauLong.Forms
{
    public partial class ChiTietHoaDon_Form : Form
    {
        private readonly HoaDon _hoaDon;

        // Dùng để lưu lại dữ liệu chi tiết hóa đơn, tránh phải đọc ngược
        // từ DataGridView (vốn là nguyên nhân gây lỗi "Column named ... cannot be found")
        private class ChiTietRowVM
        {
            public int STT { get; set; }
            public string SanPham { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
            public decimal ThanhTien { get; set; }
        }

        private List<ChiTietRowVM> _chiTietList = new List<ChiTietRowVM>();

        public ChiTietHoaDon_Form(HoaDon hoaDon)
        {
            InitializeComponent();
            _hoaDon = hoaDon;
        }

        private void ChiTietHoaDon_Form_Load(object sender, EventArgs e)
        {
            HienThiThongTin();
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HienThiThongTin()
        {
            if (_hoaDon == null) return;

            txt_MaHoaDon.Text = _hoaDon.MaHoaDon;
            txt_NgayLap.Text = _hoaDon.NgayLap.HasValue
                ? _hoaDon.NgayLap.Value.ToString("dd/MM/yyyy HH:mm")
                : "";
            txt_KhachHang.Text = _hoaDon.KhachHang?.HoTen ?? "Khách vãng lai";
            txt_SDTKhachHang.Text = _hoaDon.KhachHang?.SoDienThoai ?? "";
            txt_NhanVienLap.Text = _hoaDon.NhanVien?.HoTen ?? "";
            txt_PhuongThucThanhToan.Text = _hoaDon.PhuongThucThanhToan ?? "";
            txt_TongTien.Text = (_hoaDon.TongTien ?? 0).ToString("#,##0") + " đ";

            _chiTietList = _hoaDon.ChiTietHoaDon.Select((ct, index) => new ChiTietRowVM
            {
                STT = index + 1,
                SanPham = ct.SanPham?.TenSanPham ?? "",
                DonGia = ct.DonGia,
                SoLuong = ct.SoLuong,
                ThanhTien = ct.SoLuong * ct.DonGia
            }).ToList();

            // Dùng đúng cột đã thiết kế sẵn trong Designer, không cho tự sinh cột nữa
            dgv_ChiTietHoaDon.AutoGenerateColumns = false;

            col_STT.DataPropertyName = "STT";
            col_STT.HeaderText = "STT";

            col_SanPham.DataPropertyName = "SanPham";
            col_SanPham.HeaderText = "Sản phẩm";

            col_DonGia.DataPropertyName = "DonGia";
            col_DonGia.HeaderText = "Đơn giá";
            col_DonGia.DefaultCellStyle.Format = "#,##0";

            col_SoLuong.DataPropertyName = "SoLuong";
            col_SoLuong.HeaderText = "Số lượng";

            col_ThanhTien.DataPropertyName = "ThanhTien";
            col_ThanhTien.HeaderText = "Thành tiền";
            col_ThanhTien.DefaultCellStyle.Format = "#,##0";

            dgv_ChiTietHoaDon.DataSource = _chiTietList;
        }

        // ==================== IN HÓA ĐƠN PDF ====================
        private void btn_InHoaDon_Click(object sender, EventArgs e)
        {
            XuatPdfHoaDon();
        }

        // Public để HoaDon_Form gọi trực tiếp, không cần Show() form này ra
        public bool XuatPdfHoaDon()
        {
            // Đảm bảo _chiTietList đã có dữ liệu (phòng trường hợp gọi mà chưa qua Form_Load)
            if (_chiTietList == null || _chiTietList.Count == 0)
                HienThiThongTin();

            try
            {
                string fontPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                if (!File.Exists(fontPath))
                    fontPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "tahoma.ttf");

                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                iFont fontShop = new iFont(bf, 20, iFont.BOLD, new BaseColor(59, 130, 246));
                iFont fontTitle = new iFont(bf, 14, iFont.BOLD, new BaseColor(26, 26, 46));
                iFont fontHeader = new iFont(bf, 10, iFont.BOLD, BaseColor.WHITE);
                iFont fontCell = new iFont(bf, 9, iFont.NORMAL, new BaseColor(50, 50, 50));
                iFont fontTotal = new iFont(bf, 12, iFont.BOLD, new BaseColor(220, 38, 38));
                iFont fontFooter = new iFont(bf, 9, iFont.ITALIC, new BaseColor(120, 120, 120));

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF files (*.pdf)|*.pdf";
                    sfd.FileName = $"HoaDon_{txt_MaHoaDon.Text}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return false; // user bấm Cancel ở hộp chọn nơi lưu

                    Document doc = new Document(PageSize.A5, 20, 20, 20, 20);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    Paragraph pShop = new Paragraph("BODUA SHOP", fontShop) { Alignment = Element.ALIGN_CENTER };
                    doc.Add(pShop);

                    Paragraph pAddr = new Paragraph("HÓA ĐƠN BÁN HÀNG", fontTitle)
                    { Alignment = Element.ALIGN_CENTER, SpacingAfter = 8 };
                    doc.Add(pAddr);

                    AddLine(doc);

                    PdfPTable infoTbl = new PdfPTable(2) { WidthPercentage = 100 };
                    infoTbl.SetWidths(new float[] { 1.2f, 2f });
                    infoTbl.SpacingBefore = 8;
                    infoTbl.SpacingAfter = 8;

                    AddInfoRow(infoTbl, "Mã HĐ:", txt_MaHoaDon.Text, bf);
                    AddInfoRow(infoTbl, "Ngày lập:", txt_NgayLap.Text, bf);
                    AddInfoRow(infoTbl, "Khách hàng:", txt_KhachHang.Text, bf);
                    AddInfoRow(infoTbl, "SĐT:", txt_SDTKhachHang.Text, bf);
                    AddInfoRow(infoTbl, "Nhân viên:", txt_NhanVienLap.Text, bf);
                    AddInfoRow(infoTbl, "PTTT:", txt_PhuongThucThanhToan.Text, bf);

                    doc.Add(infoTbl);
                    AddLine(doc);

                    PdfPTable tbl = new PdfPTable(5) { WidthPercentage = 100 };
                    tbl.SetWidths(new float[] { 0.5f, 2.2f, 0.7f, 1.3f, 1.3f });
                    tbl.SpacingBefore = 8;
                    tbl.SpacingAfter = 8;

                    string[] cols = { "STT", "Sản phẩm", "SL", "Đơn giá", "Thành tiền" };
                    foreach (var c in cols)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(c, fontHeader))
                        {
                            BackgroundColor = new BaseColor(59, 130, 246),
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5
                        };
                        tbl.AddCell(cell);
                    }

                    foreach (var ct in _chiTietList)
                    {
                        tbl.AddCell(MakeCell(ct.STT.ToString(), fontCell, Element.ALIGN_CENTER));
                        tbl.AddCell(MakeCell(ct.SanPham, fontCell, Element.ALIGN_LEFT));
                        tbl.AddCell(MakeCell(ct.SoLuong.ToString(), fontCell, Element.ALIGN_CENTER));
                        tbl.AddCell(MakeCell(ct.DonGia.ToString("#,##0"), fontCell, Element.ALIGN_RIGHT));
                        tbl.AddCell(MakeCell(ct.ThanhTien.ToString("#,##0"), fontCell, Element.ALIGN_RIGHT));
                    }
                    doc.Add(tbl);

                    AddLine(doc);

                    Paragraph pTotal = new Paragraph($"TỔNG TIỀN: {txt_TongTien.Text}", fontTotal)
                    { Alignment = Element.ALIGN_RIGHT, SpacingBefore = 5, SpacingAfter = 15 };
                    doc.Add(pTotal);

                    Paragraph pFooter = new Paragraph("Cảm ơn quý khách đã mua hàng!\nHẹn gặp lại quý khách!", fontFooter)
                    { Alignment = Element.ALIGN_CENTER };
                    doc.Add(pFooter);

                    doc.Close();

                    MessageBox.Show("In hóa đơn thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(sfd.FileName);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ==================== HELPERS ====================
        private void AddInfoRow(PdfPTable table, string label, string value, BaseFont bf)
        {
            iFont fLabel = new iFont(bf, 10, iFont.BOLD, new BaseColor(80, 80, 80));
            iFont fValue = new iFont(bf, 10, iFont.NORMAL, new BaseColor(50, 50, 50));

            PdfPCell c1 = new PdfPCell(new Phrase(label, fLabel));
            c1.Border = iTextSharp.text.Rectangle.NO_BORDER;
            c1.Padding = 2;

            PdfPCell c2 = new PdfPCell(new Phrase(value, fValue));
            c2.Border = iTextSharp.text.Rectangle.NO_BORDER;
            c2.Padding = 2;

            table.AddCell(c1);
            table.AddCell(c2);
        }

        private PdfPCell MakeCell(string text, iFont font, int align)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.HorizontalAlignment = align;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 4;
            cell.BorderColor = new BaseColor(220, 220, 220);
            return cell;
        }

        private void AddLine(Document doc)
        {
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(
                0.5f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -2)));
            p.SpacingBefore = 4;
            p.SpacingAfter = 4;
            doc.Add(p);
        }
    }
}