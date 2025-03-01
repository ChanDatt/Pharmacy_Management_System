using System.Data;
using System.Data.SqlClient;
using Guna.Charts.WinForms;
using BL;


namespace QLNT
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            ShowInfo();
            loadBarChart();
            loadPieChart();
        }

        private void ShowInfo()
        {
            try
            {
                List<object> list = new BL.DashBoardBL().showDashBoard();
                lb_Staff.Text = list[0].ToString();
                lb_BSeller.Text = list[1].ToString();
                lb_Revenue.Text = ((decimal)list[2]).ToString("C");
                lb_Profit.Text = ((decimal)list[3]).ToString("C");
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void loadBarChart()
        {

            try
            {
                List<(string Day, double TotalSales)> listRevenue = new BL.DashBoardBL().getWeeklyRevenue();
                gunaChart1.Datasets.Clear();

                // Tạo dataset mới
                Guna.Charts.WinForms.GunaBarDataset barDataset = new Guna.Charts.WinForms.GunaBarDataset
                {
                    Label = "Dayly Revenue",
                };

                foreach (var data in listRevenue)
                {
                    barDataset.DataPoints.Add(data.Day, data.TotalSales);
                }

                // Thêm dataset vào chart
                gunaChart1.Datasets.Add(barDataset);

                // Cấu hình tiêu đề
                gunaChart1.Title.Text = "WEEKLY REVENUE";
                gunaChart1.Title.Font = new Guna.Charts.WinForms.ChartFont
                {
                    FontName = "Times New Roman",
                    Size = 40,
                    Style = ChartFontStyle.Bold
                };

                gunaChart1.Update(); // Cập nhật biểu đồ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void loadPieChart()
        {

            try
            {
                List<(string Day, double TotalSales)> listRevenue = new BL.DashBoardBL().getMonthlyRevenue();
                gunaChart2.Datasets.Clear();

                // Tạo dataset mới
                Guna.Charts.WinForms.GunaPieDataset pieDataset = new Guna.Charts.WinForms.GunaPieDataset
                {
                    Label = "Monthly Revenue",
                };

                // Duyệt qua từng dòng dữ liệu trong DataTable
                foreach (var data in listRevenue)
                {

                    pieDataset.DataPoints.Add(data.Day, data.TotalSales);

                }

                // Config chart
                gunaChart2.XAxes.Display = false;
                gunaChart2.YAxes.Display = false;

                // Thêm dataset vào chart
                gunaChart2.Datasets.Add(pieDataset);

                // Cấu hình tiêu đề
                gunaChart2.Title.Text = "MONTHLY REVENUE";
                gunaChart2.Title.Font = new Guna.Charts.WinForms.ChartFont
                {
                    FontName = "Times New Roman",
                    Size = 40,
                    Style = ChartFontStyle.Bold
                };

                gunaChart2.Update(); // Cập nhật biểu đồ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
