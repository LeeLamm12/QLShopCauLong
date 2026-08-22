using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;  // ← ALIAS QUAN TRỌNG

namespace QLShopCauLong.BLL
{
    public static class ExcelExportHelper
    {
        public static void ExportDataGridView(DataGridView dgv, string sheetName, string title = "")
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            var excel = new Excel.Application();
            excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = (Excel.Worksheet)excel.ActiveSheet;
            ws.Name = sheetName;

            int startRow = 1;
            if (!string.IsNullOrEmpty(title))
            {
                ws.Cells[startRow, 1] = title;
                ws.Range[ws.Cells[startRow, 1], ws.Cells[startRow, dgv.Columns.Count]].Merge();
                ws.Cells[startRow, 1].Font.Size = 14;
                ws.Cells[startRow, 1].Font.Bold = true;
                startRow = 3;
            }

            // Header
            int colIndex = 1;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    ws.Cells[startRow, colIndex] = dgv.Columns[i].HeaderText;
                    ws.Cells[startRow, colIndex].Font.Bold = true;
                    ws.Cells[startRow, colIndex].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    colIndex++;
                }
            }

            // Data
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                colIndex = 1;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv.Columns[j].Visible)
                    {
                        ws.Cells[startRow + 1 + i, colIndex] = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                        colIndex++;
                    }
                }
            }

            ws.Columns.AutoFit();
            excel.Visible = true;
        }

        public static void ExportDataTable(DataTable dt, string sheetName, string title = "")
        {
            var excel = new Excel.Application();
            excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = (Excel.Worksheet)excel.ActiveSheet;
            ws.Name = sheetName;

            int startRow = 1;
            if (!string.IsNullOrEmpty(title))
            {
                ws.Cells[startRow, 1] = title;
                ws.Range[ws.Cells[startRow, 1], ws.Cells[startRow, dt.Columns.Count]].Merge();
                ws.Cells[startRow, 1].Font.Size = 14;
                ws.Cells[startRow, 1].Font.Bold = true;
                startRow = 3;
            }

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.Cells[startRow, i + 1] = dt.Columns[i].ColumnName;
                ws.Cells[startRow, i + 1].Font.Bold = true;
                ws.Cells[startRow, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
                for (int j = 0; j < dt.Columns.Count; j++)
                    ws.Cells[startRow + 1 + i, j + 1] = dt.Rows[i][j]?.ToString() ?? "";

            ws.Columns.AutoFit();
            excel.Visible = true;
        }
    }
}
