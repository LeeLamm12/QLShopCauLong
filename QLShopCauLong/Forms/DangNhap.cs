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
    public partial class DangNhap : Form
    {
        private int _soLanThatBai = 0;   // số lần sai liên tiếp trong 1 chu kỳ
        private int _soLanBiKhoa = 0;    // số lần đã bị khóa 5s
        private int _giayConLai = 0;
        private readonly System.Windows.Forms.Timer _timerKhoa = new System.Windows.Forms.Timer();

        public DangNhap()
        {
            InitializeComponent();

            _timerKhoa.Interval = 1000;
            _timerKhoa.Tick += TimerKhoa_Tick;

            lbl_ThongBao.Visible = false; // label cần thêm trong Designer
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txt_TenDangNhap.Text.Trim();
            string matKhau = txt_MatKhau.Text;

            if (string.IsNullOrEmpty(tenDN) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (thanhCong, tk, thongBao) = new TaiKhoanBLL().DangNhap(tenDN, matKhau);

            if (!thanhCong || tk == null)
            {
                _soLanThatBai++;

                if (_soLanThatBai >= 3)
                {
                    _soLanBiKhoa++;
                    _soLanThatBai = 0; // reset đếm để bắt đầu chu kỳ mới sau khi khóa

                    if (_soLanBiKhoa >= 2)
                    {
                        // Đã bị khóa lần thứ 2 (tổng cộng 6 lần đăng nhập sai) -> cảnh báo và thoát
                        MessageBox.Show(
                            "Bạn đã đăng nhập thất bại liên tục nhiều lần.\n" +
                            "Hệ thống sẽ báo cáo hành vi này cho quản trị viên.\n" +
                            "Ứng dụng sẽ đóng.",
                            "Cảnh báo bảo mật",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        Application.Exit();
                        return;
                    }

                    KhoaDangNhap(5);
                    return;
                }

                MessageBox.Show(thongBao, "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đăng nhập thành công -> reset toàn bộ bộ đếm
            _soLanThatBai = 0;
            _soLanBiKhoa = 0;

            SessionBLL.TaiKhoanHienTai = tk;

            if (SessionBLL.IsAdmin)  // VaiTro == "Quản trị viên"
            {
                var adminForm = new Admin_Form();
                this.Hide();
                adminForm.FormClosed += (s, args) => this.Close();
                adminForm.Show();
            }
            else
            {
                var userForm = new User_Form();
                this.Hide();
                userForm.FormClosed += (s, args) => this.Close();
                userForm.Show();
            }
        }

        private void KhoaDangNhap(int soGiay)
        {
            _giayConLai = soGiay;

            btn_DangNhap.Enabled = false;
            txt_TenDangNhap.Enabled = false;
            txt_MatKhau.Enabled = false;

            lbl_ThongBao.ForeColor = Color.Red;
            lbl_ThongBao.Text = $"Bạn đã nhập sai 3 lần. Vui lòng chờ {_giayConLai}s...\n" +
                                 "Nếu bạn quên mật khẩu, hãy liên hệ admin.";
            lbl_ThongBao.Visible = true;

            _timerKhoa.Start();
        }

        private void TimerKhoa_Tick(object sender, EventArgs e)
        {
            _giayConLai--;

            if (_giayConLai <= 0)
            {
                _timerKhoa.Stop();

                btn_DangNhap.Enabled = true;
                txt_TenDangNhap.Enabled = true;
                txt_MatKhau.Enabled = true;

                lbl_ThongBao.Text = "";
                lbl_ThongBao.Visible = false;
            }
            else
            {
                lbl_ThongBao.Text = $"Bạn đã nhập sai 3 lần. Vui lòng chờ {_giayConLai}s...\n" +
                                     "Nếu bạn quên mật khẩu, hãy liên hệ admin.";
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
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