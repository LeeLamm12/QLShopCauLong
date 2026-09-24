using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLShopCauLong
{
    public partial class UcNhanVienRevenue : UserControl
    {
        public UcNhanVienRevenue()
        {
            InitializeComponent();
        }

        private void UcNhanVienRevenue_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        public void SetData(string tenNV, decimal doanhThu, decimal maxDoanhThu)
        {
            lblTenNV.Text = tenNV;
            lblSoTien.Text = doanhThu.ToString("#,##0") + " đ";

            guna2ProgressBar1.Maximum = 100;
            int phanTram = maxDoanhThu == 0 ? 0 : (int)(doanhThu / maxDoanhThu * 100);
            guna2ProgressBar1.Value = phanTram;
        }

        private void lblSoTien_Click(object sender, EventArgs e)
        {

        }
    }
}
