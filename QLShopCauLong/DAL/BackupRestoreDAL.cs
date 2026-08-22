using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLShopCauLong.DAL
{
    public class BackupRestoreDAL
    {
        private string GetConnectionString()
        {
            string connStr = ConfigurationManager.ConnectionStrings["QLShopCauLongEntities"].ConnectionString;

            // EF connection string có dạng: metadata=...;provider=...;provider connection string="..."
            // Cần lấy phần provider connection string ra
            var match = Regex.Match(connStr, @"provider connection string=""([^""]+)""");
            if (match.Success)
                return match.Groups[1].Value;

            // Nếu không phải EF string thì trả về nguyên bản
            return connStr;
        }

        private string GetDatabaseName()
        {
            var builder = new SqlConnectionStringBuilder(GetConnectionString());
            return builder.InitialCatalog;
        }

        public void Backup(string filePath)
        {
            string dbName = GetDatabaseName();
            string connStr = GetConnectionString();

            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                // Bỏ COMPRESSION vì SQL Express không hỗ trợ
                string sql = $"BACKUP DATABASE [{dbName}] TO DISK = @filePath WITH FORMAT;";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@filePath", filePath);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Restore(string filePath)
        {
            string dbName = GetDatabaseName();
            string connStr = GetConnectionString();

            var builder = new SqlConnectionStringBuilder(connStr);
            builder.InitialCatalog = "master";

            using (var conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();

                string setSingle = $"ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                using (var cmd1 = new SqlCommand(setSingle, conn))
                    cmd1.ExecuteNonQuery();

                try
                {
                    string sql = $"RESTORE DATABASE [{dbName}] FROM DISK = @filePath WITH REPLACE;";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@filePath", filePath);
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    string setMulti = $"ALTER DATABASE [{dbName}] SET MULTI_USER;";
                    using (var cmd2 = new SqlCommand(setMulti, conn))
                        cmd2.ExecuteNonQuery();
                }
            }
        }
    }
}
