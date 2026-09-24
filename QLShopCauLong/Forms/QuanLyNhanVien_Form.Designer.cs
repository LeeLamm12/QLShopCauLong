namespace QLShopCauLong.Forms
{
    partial class QuanLyNhanVien_Form
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
            this.lbl_TenNguoiDung = new System.Windows.Forms.Label();
            this.CirPic_Admin = new Guna.UI2.WinForms.Guna2CirclePictureBox();
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
            this.txt_NhanVien = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_DanhSachQLNV = new System.Windows.Forms.Label();
            this.lbl_QuanLyNhanVien = new System.Windows.Forms.Label();
            this.lbl_VaiTro = new System.Windows.Forms.Label();
            this.btn_ThemNhanVien = new Guna.UI2.WinForms.Guna2Button();
            this.dgv_NhanVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.col_MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ChucVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NgayVaoLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Sua = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_Xoa = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CirPic_Admin)).BeginInit();
            this.panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVien)).BeginInit();
            this.SuspendLayout();
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
            this.lbl_TenNguoiDung.TabIndex = 37;
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
            this.CirPic_Admin.TabIndex = 36;
            this.CirPic_Admin.TabStop = false;
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
            this.panel_Menu.TabIndex = 34;
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
            // txt_NhanVien
            // 
            this.txt_NhanVien.BackColor = System.Drawing.Color.Transparent;
            this.txt_NhanVien.BorderRadius = 8;
            this.txt_NhanVien.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_NhanVien.DefaultText = "";
            this.txt_NhanVien.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_NhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_NhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_NhanVien.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_NhanVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_NhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NhanVien.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_NhanVien.IconRight = global::QLShopCauLong.Properties.Resources.timkiem;
            this.txt_NhanVien.Location = new System.Drawing.Point(295, 145);
            this.txt_NhanVien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_NhanVien.Name = "txt_NhanVien";
            this.txt_NhanVien.PlaceholderText = "Tìm kiếm theo tên hoặc SĐT...";
            this.txt_NhanVien.SelectedText = "";
            this.txt_NhanVien.Size = new System.Drawing.Size(253, 48);
            this.txt_NhanVien.TabIndex = 41;
            this.txt_NhanVien.TextChanged += new System.EventHandler(this.txt_NhanVien_TextChanged);
            // 
            // lbl_DanhSachQLNV
            // 
            this.lbl_DanhSachQLNV.AutoSize = true;
            this.lbl_DanhSachQLNV.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DanhSachQLNV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DanhSachQLNV.ForeColor = System.Drawing.Color.Navy;
            this.lbl_DanhSachQLNV.Location = new System.Drawing.Point(294, 121);
            this.lbl_DanhSachQLNV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DanhSachQLNV.Name = "lbl_DanhSachQLNV";
            this.lbl_DanhSachQLNV.Size = new System.Drawing.Size(265, 19);
            this.lbl_DanhSachQLNV.TabIndex = 40;
            this.lbl_DanhSachQLNV.Text = "Danh sách và quản lý thông tin nhân viên";
            // 
            // lbl_QuanLyNhanVien
            // 
            this.lbl_QuanLyNhanVien.AutoSize = true;
            this.lbl_QuanLyNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.lbl_QuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuanLyNhanVien.ForeColor = System.Drawing.Color.Navy;
            this.lbl_QuanLyNhanVien.Location = new System.Drawing.Point(288, 86);
            this.lbl_QuanLyNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_QuanLyNhanVien.Name = "lbl_QuanLyNhanVien";
            this.lbl_QuanLyNhanVien.Size = new System.Drawing.Size(221, 32);
            this.lbl_QuanLyNhanVien.TabIndex = 39;
            this.lbl_QuanLyNhanVien.Text = "Quản lý nhân viên";
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
            this.lbl_VaiTro.TabIndex = 38;
            this.lbl_VaiTro.Text = "Quản trị hệ thống";
            // 
            // btn_ThemNhanVien
            // 
            this.btn_ThemNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.btn_ThemNhanVien.BorderRadius = 8;
            this.btn_ThemNhanVien.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemNhanVien.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ThemNhanVien.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ThemNhanVien.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ThemNhanVien.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_ThemNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThemNhanVien.ForeColor = System.Drawing.Color.White;
            this.btn_ThemNhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btn_ThemNhanVien.Location = new System.Drawing.Point(1066, 149);
            this.btn_ThemNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ThemNhanVien.Name = "btn_ThemNhanVien";
            this.btn_ThemNhanVien.Size = new System.Drawing.Size(223, 44);
            this.btn_ThemNhanVien.TabIndex = 42;
            this.btn_ThemNhanVien.Text = "+   Thêm nhân viên";
            this.btn_ThemNhanVien.Click += new System.EventHandler(this.btn_ThemNhanVien_Click);
            // 
            // dgv_NhanVien
            // 
            this.dgv_NhanVien.AllowUserToAddRows = false;
            this.dgv_NhanVien.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv_NhanVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_NhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_NhanVien.ColumnHeadersHeight = 40;
            this.dgv_NhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MaNhanVien,
            this.col_HoTen,
            this.col_ChucVu,
            this.col_SDT,
            this.col_Email,
            this.col_NgayVaoLam,
            this.col_Sua,
            this.col_Xoa});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_NhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_NhanVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_NhanVien.Location = new System.Drawing.Point(298, 214);
            this.dgv_NhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_NhanVien.Name = "dgv_NhanVien";
            this.dgv_NhanVien.RowHeadersVisible = false;
            this.dgv_NhanVien.RowHeadersWidth = 51;
            this.dgv_NhanVien.Size = new System.Drawing.Size(991, 373);
            this.dgv_NhanVien.TabIndex = 43;
            this.dgv_NhanVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_NhanVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_NhanVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_NhanVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv_NhanVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_NhanVien.ThemeStyle.HeaderStyle.Height = 40;
            this.dgv_NhanVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_NhanVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgv_NhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_QuanLyNhanVien_CellClick);
            // 
            // col_MaNhanVien
            // 
            this.col_MaNhanVien.DataPropertyName = "MaNhanVien";
            this.col_MaNhanVien.FillWeight = 107.9645F;
            this.col_MaNhanVien.HeaderText = "Mã nhân viên";
            this.col_MaNhanVien.MinimumWidth = 6;
            this.col_MaNhanVien.Name = "col_MaNhanVien";
            this.col_MaNhanVien.ReadOnly = true;
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
            // col_ChucVu
            // 
            this.col_ChucVu.DataPropertyName = "ChucVu";
            this.col_ChucVu.HeaderText = "Chức vụ";
            this.col_ChucVu.MinimumWidth = 6;
            this.col_ChucVu.Name = "col_ChucVu";
            this.col_ChucVu.ReadOnly = true;
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
            // col_NgayVaoLam
            // 
            this.col_NgayVaoLam.DataPropertyName = "NgayVaoLam";
            this.col_NgayVaoLam.FillWeight = 121.8274F;
            this.col_NgayVaoLam.HeaderText = "Ngày vào làm";
            this.col_NgayVaoLam.MinimumWidth = 6;
            this.col_NgayVaoLam.Name = "col_NgayVaoLam";
            this.col_NgayVaoLam.ReadOnly = true;
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
            // QuanLyNhanVien_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLShopCauLong.Properties.Resources.nenphu5;
            this.ClientSize = new System.Drawing.Size(1312, 629);
            this.Controls.Add(this.lbl_TenNguoiDung);
            this.Controls.Add(this.CirPic_Admin);
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.txt_NhanVien);
            this.Controls.Add(this.lbl_DanhSachQLNV);
            this.Controls.Add(this.lbl_QuanLyNhanVien);
            this.Controls.Add(this.lbl_VaiTro);
            this.Controls.Add(this.btn_ThemNhanVien);
            this.Controls.Add(this.dgv_NhanVien);
            this.Name = "QuanLyNhanVien_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang quản lý nhân viên";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyNhanVien_Form_FormClosing);
            this.Load += new System.EventHandler(this.QuanLyNhanVien_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CirPic_Admin)).EndInit();
            this.panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TenNguoiDung;
        private Guna.UI2.WinForms.Guna2CirclePictureBox CirPic_Admin;
        private Guna.UI2.WinForms.Guna2Panel panel_Menu;
        private Guna.UI2.WinForms.Guna2Button btn_DangXuat;
        private Guna.UI2.WinForms.Guna2Button btn_QuanLyTaiKhoan;
        private Guna.UI2.WinForms.Guna2Button btn_ThongKe;
        private Guna.UI2.WinForms.Guna2Button btn_NhaCungCap;
        private Guna.UI2.WinForms.Guna2Button btn_NhanVien;
        private Guna.UI2.WinForms.Guna2Button btn_KhachHang;
        private Guna.UI2.WinForms.Guna2Button btn_HoaDon;
        private Guna.UI2.WinForms.Guna2Button btn_SanPham;
        private Guna.UI2.WinForms.Guna2Button btn_TrangChu;
        private Guna.UI2.WinForms.Guna2TextBox txt_NhanVien;
        private System.Windows.Forms.Label lbl_DanhSachQLNV;
        private System.Windows.Forms.Label lbl_QuanLyNhanVien;
        private System.Windows.Forms.Label lbl_VaiTro;
        private Guna.UI2.WinForms.Guna2Button btn_ThemNhanVien;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_NhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ChucVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_NgayVaoLam;
        private System.Windows.Forms.DataGridViewImageColumn col_Sua;
        private System.Windows.Forms.DataGridViewImageColumn col_Xoa;
    }
}