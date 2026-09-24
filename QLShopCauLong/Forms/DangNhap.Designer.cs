namespace QLShopCauLong.Forms
{
    partial class DangNhap
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
            this.panel_DangNhap = new Guna.UI2.WinForms.Guna2Panel();
            this.lbl_ThongBao = new System.Windows.Forms.Label();
            this.lbl_DangNhap = new System.Windows.Forms.Label();
            this.btn_DangNhap = new Guna.UI2.WinForms.Guna2GradientButton();
            this.txt_MatKhau = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_TenDangNhap = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel_DangNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_DangNhap
            // 
            this.panel_DangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_DangNhap.BorderColor = System.Drawing.Color.Black;
            this.panel_DangNhap.Controls.Add(this.lbl_ThongBao);
            this.panel_DangNhap.Controls.Add(this.lbl_DangNhap);
            this.panel_DangNhap.Controls.Add(this.btn_DangNhap);
            this.panel_DangNhap.Controls.Add(this.txt_MatKhau);
            this.panel_DangNhap.Controls.Add(this.txt_TenDangNhap);
            this.panel_DangNhap.FillColor = System.Drawing.Color.White;
            this.panel_DangNhap.Location = new System.Drawing.Point(820, 202);
            this.panel_DangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.panel_DangNhap.Name = "panel_DangNhap";
            this.panel_DangNhap.ShadowDecoration.BorderRadius = 20;
            this.panel_DangNhap.ShadowDecoration.Color = System.Drawing.Color.DeepSkyBlue;
            this.panel_DangNhap.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(20);
            this.panel_DangNhap.Size = new System.Drawing.Size(420, 397);
            this.panel_DangNhap.TabIndex = 1;
            // 
            // lbl_ThongBao
            // 
            this.lbl_ThongBao.AutoSize = true;
            this.lbl_ThongBao.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_ThongBao.Location = new System.Drawing.Point(23, 328);
            this.lbl_ThongBao.Name = "lbl_ThongBao";
            this.lbl_ThongBao.Size = new System.Drawing.Size(0, 23);
            this.lbl_ThongBao.TabIndex = 4;
            this.lbl_ThongBao.Visible = false;
            // 
            // lbl_DangNhap
            // 
            this.lbl_DangNhap.AutoSize = true;
            this.lbl_DangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lbl_DangNhap.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_DangNhap.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_DangNhap.Location = new System.Drawing.Point(137, 32);
            this.lbl_DangNhap.Name = "lbl_DangNhap";
            this.lbl_DangNhap.Size = new System.Drawing.Size(153, 31);
            this.lbl_DangNhap.TabIndex = 3;
            this.lbl_DangNhap.Text = "ĐĂNG NHẬP";
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_DangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DangNhap.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_DangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_DangNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.ForeColor = System.Drawing.Color.White;
            this.btn_DangNhap.Location = new System.Drawing.Point(108, 266);
            this.btn_DangNhap.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(195, 55);
            this.btn_DangNhap.TabIndex = 1;
            this.btn_DangNhap.Text = "ĐĂNG NHẬP";
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.BackColor = System.Drawing.Color.DodgerBlue;
            this.txt_MatKhau.BorderColor = System.Drawing.Color.White;
            this.txt_MatKhau.BorderThickness = 0;
            this.txt_MatKhau.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_MatKhau.DefaultText = "";
            this.txt_MatKhau.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_MatKhau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_MatKhau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MatKhau.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_MatKhau.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_MatKhau.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MatKhau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MatKhau.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txt_MatKhau.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_MatKhau.IconLeft = global::QLShopCauLong.Properties.Resources.locked;
            this.txt_MatKhau.Location = new System.Drawing.Point(27, 180);
            this.txt_MatKhau.Margin = new System.Windows.Forms.Padding(5);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.PlaceholderForeColor = System.Drawing.Color.LightSlateGray;
            this.txt_MatKhau.PlaceholderText = "Mật khẩu";
            this.txt_MatKhau.SelectedText = "";
            this.txt_MatKhau.Size = new System.Drawing.Size(365, 57);
            this.txt_MatKhau.TabIndex = 1;
            // 
            // txt_TenDangNhap
            // 
            this.txt_TenDangNhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.txt_TenDangNhap.BorderColor = System.Drawing.Color.White;
            this.txt_TenDangNhap.BorderThickness = 0;
            this.txt_TenDangNhap.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TenDangNhap.DefaultText = "";
            this.txt_TenDangNhap.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TenDangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TenDangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenDangNhap.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenDangNhap.FillColor = System.Drawing.Color.WhiteSmoke;
            this.txt_TenDangNhap.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenDangNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenDangNhap.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txt_TenDangNhap.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenDangNhap.IconLeft = global::QLShopCauLong.Properties.Resources.user1;
            this.txt_TenDangNhap.Location = new System.Drawing.Point(27, 96);
            this.txt_TenDangNhap.Margin = new System.Windows.Forms.Padding(5);
            this.txt_TenDangNhap.Name = "txt_TenDangNhap";
            this.txt_TenDangNhap.PlaceholderForeColor = System.Drawing.Color.LightSlateGray;
            this.txt_TenDangNhap.PlaceholderText = "Tên đăng nhập";
            this.txt_TenDangNhap.SelectedText = "";
            this.txt_TenDangNhap.Size = new System.Drawing.Size(365, 57);
            this.txt_TenDangNhap.TabIndex = 0;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QLShopCauLong.Properties.Resources.nen2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1312, 629);
            this.Controls.Add(this.panel_DangNhap);
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DangNhap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DangNhap_FormClosing);
            this.Load += new System.EventHandler(this.DangNhap_Load);
            this.panel_DangNhap.ResumeLayout(false);
            this.panel_DangNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel_DangNhap;
        private Guna.UI2.WinForms.Guna2GradientButton btn_DangNhap;
        private Guna.UI2.WinForms.Guna2TextBox txt_MatKhau;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenDangNhap;
        private System.Windows.Forms.Label lbl_DangNhap;
        private System.Windows.Forms.Label lbl_ThongBao;
    }
}