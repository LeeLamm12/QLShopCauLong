namespace QLShopCauLong
{
    partial class SanPham_Form
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
            this.panel_Menu = new Guna.UI2.WinForms.Guna2Panel();
            this.btn_DangXuat = new Guna.UI2.WinForms.Guna2Button();
            this.btn_QuanLyTaiKhoan = new Guna.UI2.WinForms.Guna2Button();
            this.btn_ThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.btn_NhaCungCap = new Guna.UI2.WinForms.Guna2Button();
            this.btn_NhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.btn_KhachHang = new Guna.UI2.WinForms.Guna2Button();
            this.btn_HoaDon = new Guna.UI2.WinForms.Guna2Button();
            this.btn_SanPham = new Guna.UI2.WinForms.Guna2Button();
            this.btn_TrangChu = new Guna.UI2.WinForms.Guna2Button();
            this.CirPic_Admin = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lbl_TenNguoiDung = new System.Windows.Forms.Label();
            this.lbl_VaiTro = new System.Windows.Forms.Label();
            this.lbl_QuanLySanPham = new System.Windows.Forms.Label();
            this.lbl_DanhSachQLSP = new System.Windows.Forms.Label();
            this.txt_TimKiemSanPham = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_ThemSanPham = new Guna.UI2.WinForms.Guna2Button();
            this.cbb_LocDanhMuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbb_LocThuongHieu = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgv_SanPham = new Guna.UI2.WinForms.Guna2DataGridView();
            this.col_MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ThuongHieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_DonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TongTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sua = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_Xoa = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CirPic_Admin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SanPham)).BeginInit();
            this.SuspendLayout();
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
            this.panel_Menu.Location = new System.Drawing.Point(16, 80);
            this.panel_Menu.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(243, 481);
            this.panel_Menu.TabIndex = 0;
            this.panel_Menu.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
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
            // CirPic_Admin
            // 
            this.CirPic_Admin.BackColor = System.Drawing.Color.Transparent;
            this.CirPic_Admin.FillColor = System.Drawing.Color.Transparent;
            this.CirPic_Admin.Image = global::QLShopCauLong.Properties.Resources.tk;
            this.CirPic_Admin.ImageRotate = 0F;
            this.CirPic_Admin.Location = new System.Drawing.Point(1083, 15);
            this.CirPic_Admin.Margin = new System.Windows.Forms.Padding(4);
            this.CirPic_Admin.Name = "CirPic_Admin";
            this.CirPic_Admin.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.CirPic_Admin.Size = new System.Drawing.Size(52, 43);
            this.CirPic_Admin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CirPic_Admin.TabIndex = 2;
            this.CirPic_Admin.TabStop = false;
            // 
            // lbl_TenNguoiDung
            // 
            this.lbl_TenNguoiDung.AutoSize = true;
            this.lbl_TenNguoiDung.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TenNguoiDung.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNguoiDung.ForeColor = System.Drawing.Color.Navy;
            this.lbl_TenNguoiDung.Location = new System.Drawing.Point(1143, 15);
            this.lbl_TenNguoiDung.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TenNguoiDung.Name = "lbl_TenNguoiDung";
            this.lbl_TenNguoiDung.Size = new System.Drawing.Size(64, 23);
            this.lbl_TenNguoiDung.TabIndex = 3;
            this.lbl_TenNguoiDung.Text = "Admin";
            // 
            // lbl_VaiTro
            // 
            this.lbl_VaiTro.AutoSize = true;
            this.lbl_VaiTro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VaiTro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VaiTro.ForeColor = System.Drawing.Color.Navy;
            this.lbl_VaiTro.Location = new System.Drawing.Point(1141, 39);
            this.lbl_VaiTro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_VaiTro.Name = "lbl_VaiTro";
            this.lbl_VaiTro.Size = new System.Drawing.Size(120, 19);
            this.lbl_VaiTro.TabIndex = 4;
            this.lbl_VaiTro.Text = "Quản trị hệ thống";
            // 
            // lbl_QuanLySanPham
            // 
            this.lbl_QuanLySanPham.AutoSize = true;
            this.lbl_QuanLySanPham.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QuanLySanPham.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuanLySanPham.ForeColor = System.Drawing.Color.Navy;
            this.lbl_QuanLySanPham.Location = new System.Drawing.Point(281, 60);
            this.lbl_QuanLySanPham.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_QuanLySanPham.Name = "lbl_QuanLySanPham";
            this.lbl_QuanLySanPham.Size = new System.Drawing.Size(219, 32);
            this.lbl_QuanLySanPham.TabIndex = 5;
            this.lbl_QuanLySanPham.Text = "Quản lý sản phẩm";
            // 
            // lbl_DanhSachQLSP
            // 
            this.lbl_DanhSachQLSP.AutoSize = true;
            this.lbl_DanhSachQLSP.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DanhSachQLSP.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DanhSachQLSP.ForeColor = System.Drawing.Color.Navy;
            this.lbl_DanhSachQLSP.Location = new System.Drawing.Point(287, 95);
            this.lbl_DanhSachQLSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DanhSachQLSP.Name = "lbl_DanhSachQLSP";
            this.lbl_DanhSachQLSP.Size = new System.Drawing.Size(340, 19);
            this.lbl_DanhSachQLSP.TabIndex = 6;
            this.lbl_DanhSachQLSP.Text = "Danh sách và quản lý tất cả sản phẩm trong hệ thống";
            // 
            // txt_TimKiemSanPham
            // 
            this.txt_TimKiemSanPham.BackColor = System.Drawing.Color.Transparent;
            this.txt_TimKiemSanPham.BorderRadius = 8;
            this.txt_TimKiemSanPham.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TimKiemSanPham.DefaultText = "";
            this.txt_TimKiemSanPham.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TimKiemSanPham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TimKiemSanPham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TimKiemSanPham.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TimKiemSanPham.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TimKiemSanPham.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TimKiemSanPham.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TimKiemSanPham.IconRight = global::QLShopCauLong.Properties.Resources.timkiem;
            this.txt_TimKiemSanPham.Location = new System.Drawing.Point(288, 119);
            this.txt_TimKiemSanPham.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_TimKiemSanPham.Name = "txt_TimKiemSanPham";
            this.txt_TimKiemSanPham.PlaceholderText = "Tìm kiếm sản phẩm...";
            this.txt_TimKiemSanPham.SelectedText = "";
            this.txt_TimKiemSanPham.Size = new System.Drawing.Size(253, 48);
            this.txt_TimKiemSanPham.TabIndex = 7;
            this.txt_TimKiemSanPham.TextChanged += new System.EventHandler(this.txt_timkiemsanpham_TextChanged);
            // 
            // btn_ThemSanPham
            // 
            this.btn_ThemSanPham.BackColor = System.Drawing.Color.Transparent;
            this.btn_ThemSanPham.BorderRadius = 8;
            this.btn_ThemSanPham.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemSanPham.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemSanPham.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThemSanPham.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThemSanPham.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_ThemSanPham.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemSanPham.ForeColor = System.Drawing.Color.White;
            this.btn_ThemSanPham.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_ThemSanPham.Location = new System.Drawing.Point(1091, 123);
            this.btn_ThemSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ThemSanPham.Name = "btn_ThemSanPham";
            this.btn_ThemSanPham.Size = new System.Drawing.Size(191, 44);
            this.btn_ThemSanPham.TabIndex = 8;
            this.btn_ThemSanPham.Text = "+   Thêm sản phẩm";
            this.btn_ThemSanPham.Click += new System.EventHandler(this.btn_ThemSanPham_Click);
            // 
            // cbb_LocDanhMuc
            // 
            this.cbb_LocDanhMuc.BackColor = System.Drawing.Color.Transparent;
            this.cbb_LocDanhMuc.BorderRadius = 8;
            this.cbb_LocDanhMuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_LocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_LocDanhMuc.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_LocDanhMuc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_LocDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_LocDanhMuc.ForeColor = System.Drawing.Color.Black;
            this.cbb_LocDanhMuc.ItemHeight = 30;
            this.cbb_LocDanhMuc.Items.AddRange(new object[] {
            "Tất cả danh mục"});
            this.cbb_LocDanhMuc.Location = new System.Drawing.Point(567, 123);
            this.cbb_LocDanhMuc.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_LocDanhMuc.Name = "cbb_LocDanhMuc";
            this.cbb_LocDanhMuc.Size = new System.Drawing.Size(233, 36);
            this.cbb_LocDanhMuc.StartIndex = 0;
            this.cbb_LocDanhMuc.TabIndex = 9;
            this.cbb_LocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cbb_LocDanhMuc_SelectedIndexChanged);
            // 
            // cbb_LocThuongHieu
            // 
            this.cbb_LocThuongHieu.BackColor = System.Drawing.Color.Transparent;
            this.cbb_LocThuongHieu.BorderRadius = 8;
            this.cbb_LocThuongHieu.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_LocThuongHieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_LocThuongHieu.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_LocThuongHieu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_LocThuongHieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_LocThuongHieu.ForeColor = System.Drawing.Color.Black;
            this.cbb_LocThuongHieu.ItemHeight = 30;
            this.cbb_LocThuongHieu.Items.AddRange(new object[] {
            "Tất cả thương hiệu"});
            this.cbb_LocThuongHieu.Location = new System.Drawing.Point(828, 123);
            this.cbb_LocThuongHieu.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_LocThuongHieu.Name = "cbb_LocThuongHieu";
            this.cbb_LocThuongHieu.Size = new System.Drawing.Size(233, 36);
            this.cbb_LocThuongHieu.StartIndex = 0;
            this.cbb_LocThuongHieu.TabIndex = 10;
            this.cbb_LocThuongHieu.SelectedIndexChanged += new System.EventHandler(this.cbb_LocThuongHieu_SelectedIndexChanged);
            // 
            // dgv_SanPham
            // 
            this.dgv_SanPham.AllowUserToAddRows = false;
            this.dgv_SanPham.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_SanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_SanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_SanPham.ColumnHeadersHeight = 40;
            this.dgv_SanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MaSanPham,
            this.col_TenSanPham,
            this.col_DanhMuc,
            this.col_ThuongHieu,
            this.col_DonGia,
            this.col_TongTonKho,
            this.col_Sua,
            this.col_Xoa});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_SanPham.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_SanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_SanPham.Location = new System.Drawing.Point(291, 188);
            this.dgv_SanPham.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_SanPham.Name = "dgv_SanPham";
            this.dgv_SanPham.RowHeadersVisible = false;
            this.dgv_SanPham.RowHeadersWidth = 51;
            this.dgv_SanPham.Size = new System.Drawing.Size(991, 373);
            this.dgv_SanPham.TabIndex = 11;
            this.dgv_SanPham.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_SanPham.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_SanPham.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_SanPham.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_SanPham.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_SanPham.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_SanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SanPham_CellClick);
            // 
            // col_MaSanPham
            // 
            this.col_MaSanPham.DataPropertyName = "MaSanPham";
            this.col_MaSanPham.FillWeight = 107.9645F;
            this.col_MaSanPham.HeaderText = "Mã sản phẩm";
            this.col_MaSanPham.MinimumWidth = 6;
            this.col_MaSanPham.Name = "col_MaSanPham";
            this.col_MaSanPham.ReadOnly = true;
            // 
            // col_TenSanPham
            // 
            this.col_TenSanPham.DataPropertyName = "TenSanPham";
            this.col_TenSanPham.FillWeight = 157.2356F;
            this.col_TenSanPham.HeaderText = "Tên sản phẩm";
            this.col_TenSanPham.MinimumWidth = 6;
            this.col_TenSanPham.Name = "col_TenSanPham";
            this.col_TenSanPham.ReadOnly = true;
            // 
            // col_DanhMuc
            // 
            this.col_DanhMuc.DataPropertyName = "TenDanhMuc";
            this.col_DanhMuc.FillWeight = 107.9645F;
            this.col_DanhMuc.HeaderText = "Danh mục";
            this.col_DanhMuc.MinimumWidth = 6;
            this.col_DanhMuc.Name = "col_DanhMuc";
            this.col_DanhMuc.ReadOnly = true;
            // 
            // col_ThuongHieu
            // 
            this.col_ThuongHieu.DataPropertyName = "ThuongHieu";
            this.col_ThuongHieu.FillWeight = 119.7163F;
            this.col_ThuongHieu.HeaderText = "Thương hiệu";
            this.col_ThuongHieu.MinimumWidth = 6;
            this.col_ThuongHieu.Name = "col_ThuongHieu";
            this.col_ThuongHieu.ReadOnly = true;
            // 
            // col_DonGia
            // 
            this.col_DonGia.DataPropertyName = "DonGia";
            this.col_DonGia.FillWeight = 121.8274F;
            this.col_DonGia.HeaderText = "Đơn giá";
            this.col_DonGia.MinimumWidth = 6;
            this.col_DonGia.Name = "col_DonGia";
            this.col_DonGia.ReadOnly = true;
            // 
            // col_TongTonKho
            // 
            this.col_TongTonKho.DataPropertyName = "TongTonKho";
            this.col_TongTonKho.FillWeight = 107.9645F;
            this.col_TongTonKho.HeaderText = "Tổng tồn kho";
            this.col_TongTonKho.MinimumWidth = 6;
            this.col_TongTonKho.Name = "col_TongTonKho";
            this.col_TongTonKho.ReadOnly = true;
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
            // SanPham_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::QLShopCauLong.Properties.Resources.nenphu5;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1312, 629);
            this.Controls.Add(this.dgv_SanPham);
            this.Controls.Add(this.cbb_LocThuongHieu);
            this.Controls.Add(this.cbb_LocDanhMuc);
            this.Controls.Add(this.btn_ThemSanPham);
            this.Controls.Add(this.txt_TimKiemSanPham);
            this.Controls.Add(this.lbl_DanhSachQLSP);
            this.Controls.Add(this.lbl_QuanLySanPham);
            this.Controls.Add(this.lbl_VaiTro);
            this.Controls.Add(this.lbl_TenNguoiDung);
            this.Controls.Add(this.CirPic_Admin);
            this.Controls.Add(this.panel_Menu);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SanPham_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang sản phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SanPham_Form_FormClosing);
            this.Load += new System.EventHandler(this.SanPham_Form_Load);
            this.panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CirPic_Admin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_Menu;
        private Guna.UI2.WinForms.Guna2Button btn_TrangChu;
        private Guna.UI2.WinForms.Guna2Button btn_SanPham;
        private Guna.UI2.WinForms.Guna2Button btn_HoaDon;
        private Guna.UI2.WinForms.Guna2Button btn_KhachHang;
        private Guna.UI2.WinForms.Guna2Button btn_NhanVien;
        private Guna.UI2.WinForms.Guna2Button btn_NhaCungCap;
        private Guna.UI2.WinForms.Guna2Button btn_ThongKe;
        private Guna.UI2.WinForms.Guna2Button btn_QuanLyTaiKhoan;
        private Guna.UI2.WinForms.Guna2CirclePictureBox CirPic_Admin;
        private System.Windows.Forms.Label lbl_TenNguoiDung;
        private System.Windows.Forms.Label lbl_VaiTro;
        private System.Windows.Forms.Label lbl_QuanLySanPham;
        private System.Windows.Forms.Label lbl_DanhSachQLSP;
        private Guna.UI2.WinForms.Guna2TextBox txt_TimKiemSanPham;
        private Guna.UI2.WinForms.Guna2Button btn_ThemSanPham;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_LocDanhMuc;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_LocThuongHieu;
        private Guna.UI2.WinForms.Guna2Button btn_DangXuat;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_SanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ThuongHieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_DonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TongTonKho;
        private System.Windows.Forms.DataGridViewImageColumn col_Sua;
        private System.Windows.Forms.DataGridViewImageColumn col_Xoa;
    }
}