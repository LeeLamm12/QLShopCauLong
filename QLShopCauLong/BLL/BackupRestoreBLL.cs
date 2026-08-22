using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLShopCauLong.DAL;

namespace QLShopCauLong.BLL
{
    public class BackupRestoreBLL
    {
        private readonly BackupRestoreDAL dal = new BackupRestoreDAL();

        public (bool ThanhCong, string ThongBao) Backup(string folderPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(folderPath))
                    return (false, "Vui lòng chọn thư mục lưu file.");

                if (!Directory.Exists(folderPath))
                    return (false, "Thư mục không tồn tại.");

                string fileName = $"QLShopCauLong_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string fullPath = Path.Combine(folderPath, fileName);

                dal.Backup(fullPath);
                return (true, $"Backup thành công!\nFile: {fileName}");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi backup: " + ex.Message);
            }
        }

        public (bool ThanhCong, string ThongBao) Restore(string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    return (false, "Vui lòng chọn file backup.");

                if (!File.Exists(filePath))
                    return (false, "File backup không tồn tại.");

                if (!filePath.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                    return (false, "Vui lòng chọn file .bak hợp lệ.");

                dal.Restore(filePath);
                return (true, "Restore thành công! Vui lòng khởi động lại ứng dụng.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi restore: " + ex.Message);
            }
        }
    }
}
