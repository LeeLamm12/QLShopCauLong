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
    public partial class QuanLyKhachHang_ThemSua : Form
    {
        private string maKHSua = null;

        public QuanLyKhachHang_ThemSua()
        {
            InitializeComponent();
            this.Text = "Thêm khách hàng";
            txt_MaKhachHang.ReadOnly = true;
            txt_MaKhachHang.Text = SinhMaKhachHang();
        }

        // Constructor SỬA
        public QuanLyKhachHang_ThemSua(string maKH)
        {
            InitializeComponent();
            this.Text = "Sửa khách hàng";
            this.maKHSua = maKH;
            txt_MaKhachHang.ReadOnly = true;
            LoadDuLieu();
        }

        private string SinhMaKhachHang()
        {
            int stt = 1;
            string maKH;
            var bll = new KhachHangBLL();
            do
            {
                maKH = "KH" + stt.ToString("D3");
                stt++;
            } while (bll.KiemTraTrungMa(maKH));

            return maKH;
        }

        private void LoadDuLieu()
        {
            var kh = new KhachHangBLL().LayDanhSach().FirstOrDefault(x => x.MaKhachHang == maKHSua);
            if (kh == null)
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            txt_MaKhachHang.Text = kh.MaKhachHang;
            txt_HoTen.Text = kh.HoTen;
            txt_SDT.Text = kh.SoDienThoai;
            txt_Email.Text = kh.Email;
            txt_DiaChi.Text = kh.DiaChi;
        }

        private void QuanLyKhachHang_ThemSua_Load(object sender, EventArgs e)
        {

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            var kh = new KhachHang
            {
                MaKhachHang = txt_MaKhachHang.Text.Trim(),
                HoTen = txt_HoTen.Text.Trim(),
                SoDienThoai = txt_SDT.Text.Trim(),
                Email = txt_Email.Text.Trim(),
                DiaChi = txt_DiaChi.Text.Trim()
            };

            (bool thanhCong, var loi) = string.IsNullOrEmpty(maKHSua)
                ? new KhachHangBLL().Them(kh)
                : new KhachHangBLL().Sua(kh);

            if (thanhCong)
            {
                MessageBox.Show(string.IsNullOrEmpty(maKHSua) ? "Thêm thành công!" : "Sửa thành công!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(string.Join("\n", loi), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
