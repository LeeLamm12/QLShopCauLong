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
    public partial class NhaCungCap_ThemSua : Form
    {
        private string maNCCSua = null;

        public NhaCungCap_ThemSua()
        {
            InitializeComponent();
            this.Text = "Thêm nhà cung cấp";
            txt_MaNCC.ReadOnly = true;
            txt_MaNCC.Text = SinhMaNCC();
        }

        // Constructor SỬA
        public NhaCungCap_ThemSua(string maNCC)
        {
            InitializeComponent();
            this.Text = "Sửa nhà cung cấp";
            this.maNCCSua = maNCC;
            txt_MaNCC.ReadOnly = true;
            LoadDuLieu();
        }

        private string SinhMaNCC()
        {
            var ds = new NhaCungCapBLL().LayDanhSach();
            int max = 0;

            foreach (var n in ds)
            {
                if (n.MaNCC != null && n.MaNCC.StartsWith("NCC") && n.MaNCC.Length > 3)
                {
                    if (int.TryParse(n.MaNCC.Substring(3), out int so))
                    {
                        if (so > max) max = so;
                    }
                }
            }

            return "NCC" + (max + 1).ToString("D3");
        }

        private void LoadDuLieu()
        {
            var ncc = new NhaCungCapBLL().LayTheoMa(maNCCSua);
            if (ncc == null)
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            txt_MaNCC.Text = ncc.MaNCC;
            txt_TenNCC.Text = ncc.TenNCC;
            txt_SDT.Text = ncc.SoDienThoai;
            txt_Email.Text = ncc.Email;
            txt_DiaChi.Text = ncc.DiaChi;
        }

        private void NhaCungCap_ThemSua_Load(object sender, EventArgs e)
        {

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            var ncc = new NhaCungCap
            {
                MaNCC = txt_MaNCC.Text.Trim(),
                TenNCC = txt_TenNCC.Text.Trim(),
                SoDienThoai = txt_SDT.Text.Trim(),
                Email = txt_Email.Text.Trim(),
                DiaChi = txt_DiaChi.Text.Trim()
            };

            (bool thanhCong, var loi) = string.IsNullOrEmpty(maNCCSua)
                ? new NhaCungCapBLL().Them(ncc)
                : new NhaCungCapBLL().Sua(ncc);

            if (thanhCong)
            {
                MessageBox.Show(string.IsNullOrEmpty(maNCCSua) ? "Thêm thành công!" : "Sửa thành công!",
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
