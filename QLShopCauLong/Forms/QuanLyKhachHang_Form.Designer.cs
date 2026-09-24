namespace QLShopCauLong.Forms
{
    partial class QuanLyKhachHang_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_KhachHang = new Guna.UI2.WinForms.Guna2DataGridView();
            this.col_MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongSoHoaDonMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sua = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_Xoa = new System.Windows.Forms.DataGridViewImageColumn();
            this.btn_ThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btn_NhaCungCap = new Guna.UI2.WinForms.Guna2Button();
            this.btn_NhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btn_KhachHang = new Guna.UI2.WinForms.Guna2Button();
            this.btn_HoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.btn_SanPham = new Guna.UI2.WinForms.Guna2Button();
            this.btn_ThemKhachHang = new Guna.UI2.WinForms.Guna2Button();
            this.txt_KhachHang = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_DanhSachQLKH = new System.Windows.Forms.Label();
            this.lbl_QuanLyKhachHang = new System.Windows.Forms.Label();
            this.lbl_VaiTro = new System.Windows.Forms.Label();
            this.btn_DangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btn_QuanLyTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.lbl_TenNguoiDung = new System.Windows.Forms.Label();
            this.CirPic_Admin = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btn_TrangChu = new Guna.UI2.WinForms.Guna2Button();
            this.panel_Menu = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CirPic_Admin)).BeginInit();
            this.panel_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_KhachHang
            // 
            this.dgv_KhachHang.AllowUserToAddRows = false;
            this.dgv_KhachHang.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_KhachHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_KhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_KhachHang.ColumnHeadersHeight = 40;
            this.dgv_KhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MaKhachHang,
            this.col_HoTen,
            this.col_SDT,
            this.col_Email,
            this.col_DiaChi,
            this.TongSoHoaDonMua,
            this.col_Sua,
            this.col_Xoa});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_KhachHang.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_KhachHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_KhachHang.Location = new System.Drawing.Point(298, 214);
            this.dgv_KhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_KhachHang.Name = "dgv_KhachHang";
            this.dgv_KhachHang.RowHeadersVisible = false;
            this.dgv_KhachHang.RowHeadersWidth = 51;
            this.dgv_KhachHang.Size = new System.Drawing.Size(991, 373);
            this.dgv_KhachHang.TabIndex = 33;
            this.dgv_KhachHang.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_KhachHang.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_KhachHang.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_KhachHang.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_KhachHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QuanLyKhachHang_CellClick);
            // 
            // col_MaKhachHang
            // 
            this.col_MaKhachHang.DataPropertyName = "MaKhachHang";
            this.col_MaKhachHang.FillWeight = 107.9645F;
            this.col_MaKhachHang.HeaderText = "Mã khách hàng";
            this.col_MaKhachHang.MinimumWidth = 6;
            this.col_MaKhachHang.Name = "col_MaKhachHang";
            this.col_MaKhachHang.ReadOnly = true;
            // 
            // col_HoTen
            // 
            this.col_HoTen.DataPropertyName = "HoTen";
            this.col_HoTen.FillWeight = 157.2356F;
            this.col_HoTen.HeaderText = "Họ tên";
            this.col_HoTen.MinimumWidth = 6;
            this.col_HoTen.Name = "col_HoTen";
            this.col_HoTen.ReadOnly = true;
            // 
            // col_SDT
            // 
            this.col_SDT.DataPropertyName = "SoDienThoai";
            this.col_SDT.FillWeight = 107.9645F;
            this.col_SDT.HeaderText = "SĐT";
            this.col_SDT.MinimumWidth = 6;
            this.col_SDT.Name = "col_SDT";
            this.col_SDT.ReadOnly = true;
            // 
            // col_Email
            // 
            this.col_Email.DataPropertyName = "Email";
            this.col_Email.FillWeight = 119.7163F;
            this.col_Email.HeaderText = "Email";
            this.col_Email.MinimumWidth = 6;
            this.col_Email.Name = "col_Email";
            this.col_Email.ReadOnly = true;
            // 
            // col_DiaChi
            // 
            this.col_DiaChi.DataPropertyName = "DiaChi";
            this.col_DiaChi.FillWeight = 121.8274F;
            this.col_DiaChi.HeaderText = "Địa chỉ";
            this.col_DiaChi.MinimumWidth = 6;
            this.col_DiaChi.Name = "col_DiaChi";
            this.col_DiaChi.ReadOnly = true;
            // 
            // TongSoHoaDonMua
            // 
            this.TongSoHoaDonMua.DataPropertyName = "col_TongSoHoaDonMua";
            this.TongSoHoaDonMua.HeaderText = "Tổng số hóa đơn mua";
            this.TongSoHoaDonMua.MinimumWidth = 6;
            this.TongSoHoaDonMua.Name = "TongSoHoaDonMua";
            // 
            // col_Sua
            // 
            this.col_Sua.FillWeight = 40.5192F;
            this.col_Sua.HeaderText = "Sửa";
            this.col_Sua.Image = global::QLShopCauLong.Properties.Resources.edit;
            this.col_Sua.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.col_Sua.MinimumWidth = 6;
            this.col_Sua.Name = "col_Sua";
            this.col_Sua.ReadOnly = true;
            // 
            // col_Xoa
            // 
            this.col_Xoa.FillWeight = 36.80783F;
            this.col_Xoa.HeaderText = "Xóa";
            this.col_Xoa.Image = global::QLShopCauLong.Properties.Resources.bin;
            this.col_Xoa.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.col_Xoa.MinimumWidth = 6;
            this.col_Xoa.Name = "col_Xoa";
            this.col_Xoa.ReadOnly = true;
            // 
            // btn_ThongKe
            // 
            this.btn_ThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThongKe.FillColor = System.Drawing.Color.White;
            this.btn_ThongKe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThongKe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_ThongKe.Image = global::QLShopCauLong.Properties.Resources.baocao;
            this.btn_ThongKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_ThongKe.Location = new System.Drawing.Point(17, 286);
            this.btn_ThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ThongKe.Name = "btn_ThongKe";
            this.btn_ThongKe.Size = new System.Drawing.Size(208, 37);
            this.btn_ThongKe.TabIndex = 7;
            this.btn_ThongKe.Text = "Báo Cáo Thống Kê";
            this.btn_ThongKe.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_ThongKe.Click += new System.EventHandler(this.btn_ThongKe_Click);
            // 
            // btn_NhaCungCap
            // 
            this.btn_NhaCungCap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhaCungCap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhaCungCap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NhaCungCap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_NhaCungCap.FillColor = System.Drawing.Color.White;
            this.btn_NhaCungCap.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_NhaCungCap.Image = global::QLShopCauLong.Properties.Resources.nhacungcap;
            this.btn_NhaCungCap.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_NhaCungCap.Location = new System.Drawing.Point(17, 241);
            this.btn_NhaCungCap.Margin = new System.Windows.Forms.Padding(4);
            this.btn_NhaCungCap.Name = "btn_NhaCungCap";
            this.btn_NhaCungCap.Size = new System.Drawing.Size(208, 37);
            this.btn_NhaCungCap.TabIndex = 5;
            this.btn_NhaCungCap.Text = "Nhà Cung Cấp";
            this.btn_NhaCungCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_NhaCungCap.Click += new System.EventHandler(this.btn_NhaCungCap_Click);
            // 
            // btn_NhanVien
            // 
            this.btn_NhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_NhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_NhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_NhanVien.FillColor = System.Drawing.Color.White;
            this.btn_NhanVien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_NhanVien.Image = global::QLShopCauLong.Properties.Resources.nhanvien;
            this.btn_NhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_NhanVien.Location = new System.Drawing.Point(17, 197);
            this.btn_NhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btn_NhanVien.Name = "btn_NhanVien";
            this.btn_NhanVien.Size = new System.Drawing.Size(208, 37);
            this.btn_NhanVien.TabIndex = 4;
            this.btn_NhanVien.Text = "Nhân Viên";
            this.btn_NhanVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_NhanVien.Click += new System.EventHandler(this.btn_NhanVien_Click);
            // 
            // btn_KhachHang
            // 
            this.btn_KhachHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_KhachHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_KhachHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_KhachHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_KhachHang.FillColor = System.Drawing.Color.White;
            this.btn_KhachHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_KhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_KhachHang.Image = global::QLShopCauLong.Properties.Resources.khachhang;
            this.btn_KhachHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_KhachHang.Location = new System.Drawing.Point(17, 153);
            this.btn_KhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.btn_KhachHang.Name = "btn_KhachHang";
            this.btn_KhachHang.Size = new System.Drawing.Size(208, 37);
            this.btn_KhachHang.TabIndex = 3;
            this.btn_KhachHang.Text = "Khách Hàng";
            this.btn_KhachHang.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_KhachHang.Click += new System.EventHandler(this.btn_KhachHang_Click);
            // 
            // btn_HoaDon
            // 
            this.btn_HoaDon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_HoaDon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_HoaDon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_HoaDon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_HoaDon.FillColor = System.Drawing.Color.White;
            this.btn_HoaDon.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_HoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_HoaDon.Image = global::QLShopCauLong.Properties.Resources.bill;
            this.btn_HoaDon.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_HoaDon.Location = new System.Drawing.Point(17, 108);
            this.btn_HoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.btn_HoaDon.Name = "btn_HoaDon";
            this.btn_HoaDon.Size = new System.Drawing.Size(208, 37);
            this.btn_HoaDon.TabIndex = 2;
            this.btn_HoaDon.Text = "Hóa Đơn";
            this.btn_HoaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_HoaDon.Click += new System.EventHandler(this.btn_HoaDon_Click);
            // 
            // btn_SanPham
            // 
            this.btn_SanPham.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_SanPham.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_SanPham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_SanPham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_SanPham.FillColor = System.Drawing.Color.White;
            this.btn_SanPham.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_SanPham.Image = global::QLShopCauLong.Properties.Resources.sanpham;
            this.btn_SanPham.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_SanPham.Location = new System.Drawing.Point(17, 64);
            this.btn_SanPham.Margin = new System.Windows.Forms.Padding(4);
            this.btn_SanPham.Name = "btn_SanPham";
            this.btn_SanPham.Size = new System.Drawing.Size(208, 37);
            this.btn_SanPham.TabIndex = 1;
            this.btn_SanPham.Text = "Sản Phẩm";
            this.btn_SanPham.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_SanPham.Click += new System.EventHandler(this.btn_SanPham_Click);
            // 
            // btn_ThemKhachHang
            // 
            this.btn_ThemKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.btn_ThemKhachHang.BorderRadius = 8;
            this.btn_ThemKhachHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemKhachHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemKhachHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThemKhachHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThemKhachHang.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_ThemKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemKhachHang.ForeColor = System.Drawing.Color.White;
            this.btn_ThemKhachHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_ThemKhachHang.Location = new System.Drawing.Point(1066, 149);
            this.btn_ThemKhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ThemKhachHang.Name = "btn_ThemKhachHang";
            this.btn_ThemKhachHang.Size = new System.Drawing.Size(223, 44);
            this.btn_ThemKhachHang.TabIndex = 32;
            this.btn_ThemKhachHang.Text = "+   Thêm khách hàng";
            this.btn_ThemKhachHang.Click += new System.EventHandler(this.btn_ThemKhachHang_Click);
            // 
            // txt_KhachHang
            // 
            this.txt_KhachHang.BackColor = System.Drawing.Color.Transparent;
            this.txt_KhachHang.BorderRadius = 8;
            this.txt_KhachHang.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_KhachHang.DefaultText = "";
            this.txt_KhachHang.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_KhachHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_KhachHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_KhachHang.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_KhachHang.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_KhachHang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_KhachHang.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_KhachHang.IconRight = global::QLShopCauLong.Properties.Resources.timkiem;
            this.txt_KhachHang.Location = new System.Drawing.Point(295, 145);
            this.txt_KhachHang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_KhachHang.Name = "txt_KhachHang";
            this.txt_KhachHang.PlaceholderText = "Tìm kiếm theo tên hoặc SĐT...";
            this.txt_KhachHang.SelectedText = "";
            this.txt_KhachHang.Size = new System.Drawing.Size(253, 48);
            this.txt_KhachHang.TabIndex = 31;
            this.txt_KhachHang.TextChanged += new System.EventHandler(this.txt_KhachHang_TextChanged);
            // 
            // lbl_DanhSachQLKH
            // 
            this.lbl_DanhSachQLKH.AutoSize = true;
            this.lbl_DanhSachQLKH.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DanhSachQLKH.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DanhSachQLKH.ForeColor = System.Drawing.Color.Navy;
            this.lbl_DanhSachQLKH.Location = new System.Drawing.Point(294, 121);
            this.lbl_DanhSachQLKH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DanhSachQLKH.Name = "lbl_DanhSachQLKH";
            this.lbl_DanhSachQLKH.Size = new System.Drawing.Size(276, 19);
            this.lbl_DanhSachQLKH.TabIndex = 30;
            this.lbl_DanhSachQLKH.Text = "Danh sách và quản lý thông tin khách hàng";
            // 
            // lbl_QuanLyKhachHang
            // 
            this.lbl_QuanLyKhachHang.AutoSize = true;
            this.lbl_QuanLyKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QuanLyKhachHang.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuanLyKhachHang.ForeColor = System.Drawing.Color.Navy;
            this.lbl_QuanLyKhachHang.Location = new System.Drawing.Point(288, 86);
            this.lbl_QuanLyKhachHang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_QuanLyKhachHang.Name = "lbl_QuanLyKhachHang";
            this.lbl_QuanLyKhachHang.Size = new System.Drawing.Size(239, 32);
            this.lbl_QuanLyKhachHang.TabIndex = 29;
            this.lbl_QuanLyKhachHang.Text = "Quản lý khách hàng";
            // 
            // lbl_VaiTro
            // 
            this.lbl_VaiTro.AutoSize = true;
            this.lbl_VaiTro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VaiTro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VaiTro.ForeColor = System.Drawing.Color.Navy;
            this.lbl_VaiTro.Location = new System.Drawing.Point(1148, 65);
            this.lbl_VaiTro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_VaiTro.Name = "lbl_VaiTro";
            this.lbl_VaiTro.Size = new System.Drawing.Size(120, 19);
            this.lbl_VaiTro.TabIndex = 28;
            this.lbl_VaiTro.Text = "Quản trị hệ thống";
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.BackColor = System.Drawing.Color.Transparent;
            this.btn_DangXuat.BorderRadius = 8;
            this.btn_DangXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DangXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DangXuat.FillColor = System.Drawing.Color.Transparent;
            this.btn_DangXuat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_DangXuat.Image = global::QLShopCauLong.Properties.Resources.dangxuat1;
            this.btn_DangXuat.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_DangXuat.Location = new System.Drawing.Point(17, 418);
            this.btn_DangXuat.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(151, 34);
            this.btn_DangXuat.TabIndex = 11;
            this.btn_DangXuat.Text = "Đăng xuất";
            this.btn_DangXuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // btn_QuanLyTaiKhoan
            // 
            this.btn_QuanLyTaiKhoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_QuanLyTaiKhoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_QuanLyTaiKhoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_QuanLyTaiKhoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_QuanLyTaiKhoan.FillColor = System.Drawing.Color.White;
            this.btn_QuanLyTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_QuanLyTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_QuanLyTaiKhoan.Image = global::QLShopCauLong.Properties.Resources.quanlytk;
            this.btn_QuanLyTaiKhoan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_QuanLyTaiKhoan.Location = new System.Drawing.Point(17, 330);
            this.btn_QuanLyTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.btn_QuanLyTaiKhoan.Name = "btn_QuanLyTaiKhoan";
            this.btn_QuanLyTaiKhoan.Size = new System.Drawing.Size(208, 37);
            this.btn_QuanLyTaiKhoan.TabIndex = 8;
            this.btn_QuanLyTaiKhoan.Text = "Quản Lý Tài Khoản";
            this.btn_QuanLyTaiKhoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_QuanLyTaiKhoan.Click += new System.EventHandler(this.btn_QuanLyTaiKhoan_Click);
            // 
            // lbl_TenNguoiDung
            // 
            this.lbl_TenNguoiDung.AutoSize = true;
            this.lbl_TenNguoiDung.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TenNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNguoiDung.ForeColor = System.Drawing.Color.Navy;
            this.lbl_TenNguoiDung.Location = new System.Drawing.Point(1150, 41);
            this.lbl_TenNguoiDung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TenNguoiDung.Name = "lbl_TenNguoiDung";
            this.lbl_TenNguoiDung.Size = new System.Drawing.Size(64, 23);
            this.lbl_TenNguoiDung.TabIndex = 27;
            this.lbl_TenNguoiDung.Text = "Admin";
            // 
            // CirPic_Admin
            // 
            this.CirPic_Admin.BackColor = System.Drawing.Color.Transparent;
            this.CirPic_Admin.FillColor = System.Drawing.Color.Transparent;
            this.CirPic_Admin.Image = global::QLShopCauLong.Properties.Resources.tk;
            this.CirPic_Admin.ImageRotate = 0F;
            this.CirPic_Admin.Location = new System.Drawing.Point(1090, 41);
            this.CirPic_Admin.Margin = new System.Windows.Forms.Padding(4);
            this.CirPic_Admin.Name = "CirPic_Admin";
            this.CirPic_Admin.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.CirPic_Admin.Size = new System.Drawing.Size(52, 43);
            this.CirPic_Admin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CirPic_Admin.TabIndex = 26;
            this.CirPic_Admin.TabStop = false;
            // 
            // btn_TrangChu
            // 
            this.btn_TrangChu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_TrangChu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_TrangChu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_TrangChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_TrangChu.FillColor = System.Drawing.Color.White;
            this.btn_TrangChu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TrangChu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btn_TrangChu.Image = global::QLShopCauLong.Properties.Resources.home1;
            this.btn_TrangChu.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_TrangChu.Location = new System.Drawing.Point(17, 20);
            this.btn_TrangChu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_TrangChu.Name = "btn_TrangChu";
            this.btn_TrangChu.Size = new System.Drawing.Size(208, 37);
            this.btn_TrangChu.TabIndex = 0;
            this.btn_TrangChu.Text = "Trang Chủ";
            this.btn_TrangChu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_TrangChu.Click += new System.EventHandler(this.btn_TrangChu_Click);
            // 
            // panel_Menu
            // 
            this.panel_Menu.BackColor = System.Drawing.Color.Transparent;
            this.panel_Menu.BorderColor = System.Drawing.Color.LightGray;
            this.panel_Menu.BorderRadius = 20;
            this.panel_Menu.BorderThickness = 2;
            this.panel_Menu.Controls.Add(this.btn_DangXuat);
            this.panel_Menu.Controls.Add(this.btn_QuanLyTaiKhoan);
            this.panel_Menu.Controls.Add(this.btn_ThongKe);
            this.panel_Menu.Controls.Add(this.btn_NhaCungCap);
            this.panel_Menu.Controls.Add(this.btn_NhanVien);
            this.panel_Menu.Controls.Add(this.btn_KhachHang);
            this.panel_Menu.Controls.Add(this.btn_HoaDon);
            this.panel_Menu.Controls.Add(this.btn_SanPham);
            this.panel_Menu.Controls.Add(this.btn_TrangChu);
            this.panel_Menu.FillColor = System.Drawing.Color.White;
            this.panel_Menu.Location = new System.Drawing.Point(23, 106);
            this.panel_Menu.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(243, 481);
            this.panel_Menu.TabIndex = 24;
            // 
            // QuanLyKhachHang_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLShopCauLong.Properties.Resources.nenphu5;
            this.ClientSize = new System.Drawing.Size(1312, 629);
            this.Controls.Add(this.dgv_KhachHang);
            this.Controls.Add(this.btn_ThemKhachHang);
            this.Controls.Add(this.txt_KhachHang);
            this.Controls.Add(this.lbl_DanhSachQLKH);
            this.Controls.Add(this.lbl_QuanLyKhachHang);
            this.Controls.Add(this.lbl_VaiTro);
            this.Controls.Add(this.lbl_TenNguoiDung);
            this.Controls.Add(this.CirPic_Admin);
            this.Controls.Add(this.panel_Menu);
            this.Name = "QuanLyKhachHang_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang quản lý khách hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyKhachHang_Form_FormClosing);
            this.Load += new System.EventHandler(this.QuanLyKhachHang_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_KhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CirPic_Admin)).EndInit();
            this.panel_Menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView dgv_KhachHang;
        private Guna.UI2.WinForms.Guna2Button btn_ThongKe;
        private Guna.UI2.WinForms.Guna2Button btn_NhaCungCap;
        private Guna.UI2.WinForms.Guna2Button btn_NhanVien;
        private Guna.UI2.WinForms.Guna2Button btn_KhachHang;
        private Guna.UI2.WinForms.Guna2Button btn_HoaDon;
        private Guna.UI2.WinForms.Guna2Button btn_SanPham;
        private Guna.UI2.WinForms.Guna2Button btn_ThemKhachHang;
        private Guna.UI2.WinForms.Guna2TextBox txt_KhachHang;
        private System.Windows.Forms.Label lbl_DanhSachQLKH;
        private System.Windows.Forms.Label lbl_QuanLyKhachHang;
        private System.Windows.Forms.Label lbl_VaiTro;
        private Guna.UI2.WinForms.Guna2Button btn_DangXuat;
        private Guna.UI2.WinForms.Guna2Button btn_QuanLyTaiKhoan;
        private System.Windows.Forms.Label lbl_TenNguoiDung;
        private Guna.UI2.WinForms.Guna2CirclePictureBox CirPic_Admin;
        private Guna.UI2.WinForms.Guna2Button btn_TrangChu;
        private Guna.UI2.WinForms.Guna2Panel panel_Menu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongSoHoaDonMua;
        private System.Windows.Forms.DataGridViewImageColumn col_Sua;
        private System.Windows.Forms.DataGridViewImageColumn col_Xoa;
    }
}