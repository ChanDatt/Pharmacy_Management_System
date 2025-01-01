using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QLNT
{
    public class ExportFile
    {
        public void exportExcel(DataGridView dataGridView, string folderPath, string fileName)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Load the header
                for (int col = 0; col < dataGridView.Columns.Count; col++)
                {
                    worksheet.Cells[1, col + 1].Value = dataGridView.Columns[col].HeaderText;
                }

                // Load the data
                for (int row = 0; row < dataGridView.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView.Columns.Count; col++)
                    {
                        if (dataGridView.Rows[row].Cells[col].Value != null) // Check for null values
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dataGridView.Rows[row].Cells[col].Value;
                        }
                    }
                }

                // Set borders for all cells
                var usedRange = worksheet.Cells[worksheet.Dimension.Address];
                usedRange.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                usedRange.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                usedRange.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                usedRange.Style.Border.Right.Style = ExcelBorderStyle.Thin;

                // Save the Excel file
                FileInfo fileInfo = new FileInfo(Path.Combine(folderPath, fileName + ".xlsx"));
                package.SaveAs(fileInfo);
            }
        }
    }
}

