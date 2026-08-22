using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class BaoCaoBLL
    {
        private readonly BaoCaoDAL dal = new BaoCaoDAL();

        public DataTable BaoCaoDoanhThu(DateTime tuNgay, DateTime denNgay)
            => dal.BaoCaoDoanhThu(tuNgay, denNgay);

        public DataTable BaoCaoTonKho(string maDanhMuc = null)
            => dal.BaoCaoTonKho(maDanhMuc);

        public DataTable BaoCaoNhapHang(DateTime tuNgay, DateTime denNgay)
            => dal.BaoCaoNhapHang(tuNgay, denNgay);

        public DataTable BaoCaoHoaDon(DateTime tuNgay, DateTime denNgay, string maNhanVien = null)
            => dal.BaoCaoHoaDon(tuNgay, denNgay, maNhanVien);
    }
}
