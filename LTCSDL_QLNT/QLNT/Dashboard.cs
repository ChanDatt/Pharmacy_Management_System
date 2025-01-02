using Guna.UI2.WinForms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;

namespace QLNT
{
    public partial class Dashboard : Form
    {
        private SQLConnectionClass sqlConnection;
        public Dashboard()
        {
            InitializeComponent();
            sqlConnection = new SQLConnectionClass(); // Initialize SQLConnectionClass
            ShowInfo();
            loadColumnChart();
            loadPieChart();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void ShowInfo()
        {
            int totalStaffs = 0;
            string getBestSeller = string.Empty;
            decimal getRevenue = 0;
            decimal getProfit = 0;

            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand("TakeDataToDashBoard", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalStaffs = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            getBestSeller = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            getRevenue = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2);
                            getProfit = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            lb_Staff.Text = totalStaffs.ToString();
            lb_BSeller.Text = getBestSeller;
            lb_Revenue.Text = getRevenue.ToString("C");
            lb_Profit.Text = getProfit.ToString("C");
        }


        private void loadColumnChart()
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("GetWeeklyRevenue", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    chart1.Series.Clear();
                    Series series = new Series("WeeklyRevenue");
                    series.ChartType = SeriesChartType.Column;
                    series.Color = ColorTranslator.FromHtml("#6C8976");

                    while (reader.Read())
                    {
                        // Thêm dữ liệu vào biểu đồ
                        string saleDate = reader.GetString(0);
                        decimal revenue = reader.GetDecimal(1);
                        series.Points.AddXY(saleDate, revenue); 
                    }
                    chart1.Series.Add(series);
                    chart1.ChartAreas[0].AxisX.Title = "Date";
                    chart1.ChartAreas[0].AxisY.Title = "Revenue";

                    chart1.Titles.Add("WEEKLY REVENUE");
                    chart1.Titles[0].Font = new System.Drawing.Font("Times New Roman", 30, FontStyle.Bold);

                    chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);
                    chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold);

                    SetChartAppearance("#6C8976", "#6C8976", "#596869");
                } catch (Exception ex) {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void SetChartAppearance(string axisXTitleColorHex, string axisYTitleColorHex, string chartTitleColorHex)
        {
            // Chuyển đổi mã màu hex thành đối tượng Color
            Color axisXTitleColor = ColorTranslator.FromHtml(axisXTitleColorHex);
            Color axisYTitleColor = ColorTranslator.FromHtml(axisYTitleColorHex);
            Color chartTitleColor = ColorTranslator.FromHtml(chartTitleColorHex);

            // Thiết lập màu cho tiêu đề trục
            chart1.ChartAreas[0].AxisX.TitleForeColor = axisXTitleColor;
            chart1.ChartAreas[0].AxisY.TitleForeColor = axisYTitleColor;

            chart1.Titles[0].ForeColor = chartTitleColor;

        }

        private void loadPieChart()
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("GetMonthlyRevenue", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    chart2.Series.Clear();
                    Series series = new Series("MonthlyRevenue");
                    series.ChartType = SeriesChartType.Pie;
                    series.Color = ColorTranslator.FromHtml("#6C8976");

                    Color[] colors = { ColorTranslator.FromHtml("#758467"), ColorTranslator.FromHtml("#819171"), ColorTranslator.FromHtml("#9CAF88"), ColorTranslator.FromHtml("#CBD5C0"),
                         ColorTranslator.FromHtml("#CBD5C0"),  ColorTranslator.FromHtml("#3A5A40"),  ColorTranslator.FromHtml("#588157"),  ColorTranslator.FromHtml("#A3B18A"),
                          ColorTranslator.FromHtml("#DAD7CD"),  ColorTranslator.FromHtml("#DFE6DA"),  ColorTranslator.FromHtml("#CBD5C0"),  ColorTranslator.FromHtml("#9CAF88"),
                           ColorTranslator.FromHtml("#819171") };

                    int colorIndex = 0;

                    while (reader.Read())
                    {
                        string saleMonth = reader.GetString(0);
                        decimal revenue = reader.GetDecimal(1);
                        series.Points.AddXY(saleMonth, revenue);

                        series.Points[series.Points.Count - 1].Color = colors[colorIndex % colors.Length]; 
                        series.Points[series.Points.Count - 1].Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold); 

                        colorIndex++; 
                    }
                    chart2.Series.Add(series);

                    chart2.Titles.Add("MONTHLY REVENUE");
                    chart2.Titles[0].Font = new System.Drawing.Font("Times New Roman", 30, FontStyle.Bold);
                    chart2.Titles[0].ForeColor = ColorTranslator.FromHtml("#596869");


                    foreach (var point in series.Points)
                    {
                        point.Label = $"{point.YValues[0]:C}"; 
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
