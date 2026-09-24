namespace QLShopCauLong.Forms
{
    partial class QuanLyTaiKhoan_ThemSua
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
            this.cbb_VaiTro = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lbl_TenDangNhap = new System.Windows.Forms.Label();
            this.btn_Huy = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Luu = new Guna.UI2.WinForms.Guna2Button();
            this.txt_MatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_MatKhau = new System.Windows.Forms.Label();
            this.lbl_ChonNhanVien = new System.Windows.Forms.Label();
            this.lbl_VaiTro = new System.Windows.Forms.Label();
            this.txt_TenDangNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_MatKhauMacDinh = new System.Windows.Forms.Label();
            this.cbb_ChonNhanVien = new Guna.UI2.WinForms.Guna2ComboBox();
            this.SuspendLayout();
            // 
            // cbb_VaiTro
            // 
            this.cbb_VaiTro.BackColor = System.Drawing.Color.Transparent;
            this.cbb_VaiTro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_VaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_VaiTro.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_VaiTro.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_VaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_VaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_VaiTro.ItemHeight = 30;
            this.cbb_VaiTro.Items.AddRange(new object[] {
            "Quản trị viên"});
            this.cbb_VaiTro.Location = new System.Drawing.Point(393, 240);
            this.cbb_VaiTro.Name = "cbb_VaiTro";
            this.cbb_VaiTro.Size = new System.Drawing.Size(294, 36);
            this.cbb_VaiTro.StartIndex = 0;
            this.cbb_VaiTro.TabIndex = 89;
            // 
            // lbl_TenDangNhap
            // 
            this.lbl_TenDangNhap.AutoSize = true;
            this.lbl_TenDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TenDangNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_TenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_TenDangNhap.Location = new System.Drawing.Point(388, 63);
            this.lbl_TenDangNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TenDangNhap.Name = "lbl_TenDangNhap";
            this.lbl_TenDangNhap.Size = new System.Drawing.Size(152, 28);
            this.lbl_TenDangNhap.TabIndex = 84;
            this.lbl_TenDangNhap.Text = "Tên đăng nhập";
            // 
            // btn_Huy
            // 
            this.btn_Huy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Huy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Huy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Huy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Huy.FillColor = System.Drawing.Color.Red;
            this.btn_Huy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Huy.ForeColor = System.Drawing.Color.White;
            this.btn_Huy.Location = new System.Drawing.Point(422, 370);
            this.btn_Huy.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(123, 46);
            this.btn_Huy.TabIndex = 81;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.Click += new System.EventHandler(this.btn_Huy_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Luu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Luu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Luu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Luu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Luu.ForeColor = System.Drawing.Color.White;
            this.btn_Luu.Location = new System.Drawing.Point(571, 370);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(117, 46);
            this.btn_Luu.TabIndex = 80;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhau.DefaultText = "";
            this.txt_MatKhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MatKhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MatKhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MatKhau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_MatKhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MatKhau.Location = new System.Drawing.Point(32, 232);
            this.txt_MatKhau.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PlaceholderText = "";
            this.txt_MatKhau.SelectedText = "";
            this.txt_MatKhau.Size = new System.Drawing.Size(286, 44);
            this.txt_MatKhau.TabIndex = 75;
            // 
            // lbl_MatKhau
            // 
            this.lbl_MatKhau.AutoSize = true;
            this.lbl_MatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MatKhau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_MatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_MatKhau.Location = new System.Drawing.Point(30, 197);
            this.lbl_MatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MatKhau.Name = "lbl_MatKhau";
            this.lbl_MatKhau.Size = new System.Drawing.Size(102, 28);
            this.lbl_MatKhau.TabIndex = 74;
            this.lbl_MatKhau.Text = "Mật khẩu";
            // 
            // lbl_ChonNhanVien
            // 
            this.lbl_ChonNhanVien.AutoSize = true;
            this.lbl_ChonNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChonNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_ChonNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_ChonNhanVien.Location = new System.Drawing.Point(27, 63);
            this.lbl_ChonNhanVien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ChonNhanVien.Name = "lbl_ChonNhanVien";
            this.lbl_ChonNhanVien.Size = new System.Drawing.Size(159, 28);
            this.lbl_ChonNhanVien.TabIndex = 72;
            this.lbl_ChonNhanVien.Text = "Chọn nhân viên";
            // 
            // lbl_VaiTro
            // 
            this.lbl_VaiTro.AutoSize = true;
            this.lbl_VaiTro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VaiTro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_VaiTro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_VaiTro.Location = new System.Drawing.Point(388, 205);
            this.lbl_VaiTro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_VaiTro.Name = "lbl_VaiTro";
            this.lbl_VaiTro.Size = new System.Drawing.Size(74, 28);
            this.lbl_VaiTro.TabIndex = 76;
            this.lbl_VaiTro.Text = "Vai trò";
            // 
            // txt_TenDangNhap
            // 
            this.txt_TenDangNhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TenDangNhap.DefaultText = "";
            this.txt_TenDangNhap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TenDangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TenDangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenDangNhap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenDangNhap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenDangNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_TenDangNhap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenDangNhap.Location = new System.Drawing.Point(393, 98);
            this.txt_TenDangNhap.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.txt_TenDangNhap.Name = "txt_TenDangNhap";
            this.txt_TenDangNhap.PlaceholderText = "";
            this.txt_TenDangNhap.SelectedText = "";
            this.txt_TenDangNhap.Size = new System.Drawing.Size(294, 44);
            this.txt_TenDangNhap.TabIndex = 83;
            // 
            // lbl_MatKhauMacDinh
            // 
            this.lbl_MatKhauMacDinh.AutoSize = true;
            this.lbl_MatKhauMacDinh.BackColor = System.Drawing.Color.Transparent;
            this.lbl_MatKhauMacDinh.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_MatKhauMacDinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.lbl_MatKhauMacDinh.Location = new System.Drawing.Point(30, 283);
            this.lbl_MatKhauMacDinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MatKhauMacDinh.Name = "lbl_MatKhauMacDinh";
            this.lbl_MatKhauMacDinh.Size = new System.Drawing.Size(277, 17);
            this.lbl_MatKhauMacDinh.TabIndex = 90;
            this.lbl_MatKhauMacDinh.Text = "Mật khẩu mặc định sẽ được mã hóa khi lưu";
            // 
            // cbb_ChonNhanVien
            // 
            this.cbb_ChonNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.cbb_ChonNhanVien.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbb_ChonNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_ChonNhanVien.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_ChonNhanVien.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbb_ChonNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbb_ChonNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbb_ChonNhanVien.ItemHeight = 30;
            this.cbb_ChonNhanVien.Location = new System.Drawing.Point(32, 94);
            this.cbb_ChonNhanVien.Name = "cbb_ChonNhanVien";
            this.cbb_ChonNhanVien.Size = new System.Drawing.Size(294, 36);
            this.cbb_ChonNhanVien.TabIndex = 91;
            // 
            // QuanLyTaiKhoan_ThemSua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLShopCauLong.Properties.Resources.nenphu5;
            this.ClientSize = new System.Drawing.Size(701, 429);
            this.Controls.Add(this.cbb_ChonNhanVien);
            this.Controls.Add(this.lbl_MatKhauMacDinh);
            this.Controls.Add(this.cbb_VaiTro);
            this.Controls.Add(this.lbl_TenDangNhap);
            this.Controls.Add(this.txt_TenDangNhap);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.lbl_VaiTro);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.lbl_MatKhau);
            this.Controls.Add(this.lbl_ChonNhanVien);
            this.Name = "QuanLyTaiKhoan_ThemSua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang thêm sửa quản lý tài khoản";
            this.Load += new System.EventHandler(this.QuanLyTaiKhoan_ThemSua_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cbb_VaiTro;
        private System.Windows.Forms.Label lbl_TenDangNhap;
        private Guna.UI2.WinForms.Guna2Button btn_Huy;
        private Guna.UI2.WinForms.Guna2Button btn_Luu;
        private Guna.UI2.WinForms.Guna2TextBox txt_MatKhau;
        private System.Windows.Forms.Label lbl_MatKhau;
        private System.Windows.Forms.Label lbl_ChonNhanVien;
        private System.Windows.Forms.Label lbl_VaiTro;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenDangNhap;
        private System.Windows.Forms.Label lbl_MatKhauMacDinh;
        private Guna.UI2.WinForms.Guna2ComboBox cbb_ChonNhanVien;
    }
}