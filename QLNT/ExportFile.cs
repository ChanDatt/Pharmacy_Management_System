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
                            var cellValue = dataGridView.Rows[row].Cells[col].Value;

                            // Check if the value is a DateTime
                            if (cellValue is DateTime dateTimeValue)
                            {
                                worksheet.Cells[row + 2, col + 1].Value = dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss"); // Convert to string format
                            }
                            else
                            {
                                worksheet.Cells[row + 2, col + 1].Value = cellValue; // Copy other values as is
                            }
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

