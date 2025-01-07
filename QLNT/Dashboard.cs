using System.Data;
using System.Data.SqlClient;
using Guna.Charts.WinForms;


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
            LoadBarChart();
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

        private void LoadBarChart()
        {
            using (var connection = new SqlConnection(sqlConnection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("GetWeeklyRevenue", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    gunaChart1.Datasets.Clear();

                    // Tạo dataset mới
                    Guna.Charts.WinForms.GunaBarDataset barDataset = new Guna.Charts.WinForms.GunaBarDataset
                    {
                        Label = "Dayly Revenue",
                    };

                    // Duyệt qua từng dòng dữ liệu trong DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string day = row["DayMonth"]?.ToString() ?? "Unknown";

                        if (double.TryParse(row["TotalSales"]?.ToString(), out double totalSales))
                        {
                            barDataset.DataPoints.Add(day, totalSales);
                        }
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

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    gunaChart2.Datasets.Clear();

                    // Tạo dataset mới
                    Guna.Charts.WinForms.GunaPieDataset pieDataset = new Guna.Charts.WinForms.GunaPieDataset
                    {
                        Label = "Monthly Revenue",
                    };

                    // Duyệt qua từng dòng dữ liệu trong DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string day = row["MonthYear"]?.ToString() ?? "Unknown";

                        if (double.TryParse(row["TotalSales"]?.ToString(), out double totalSales))
                        {
                            pieDataset.DataPoints.Add(day, totalSales);
                        }
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
}
