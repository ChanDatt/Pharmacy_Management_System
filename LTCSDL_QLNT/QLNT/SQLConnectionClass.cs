using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class SQLConnectionClass
{
    private string connectionString;

    public SQLConnectionClass()
    {
        var connectionStringSettings = ConfigurationManager.ConnectionStrings["DatabaseConnection"];
        if (connectionStringSettings == null)
        {
            Console.WriteLine("Connection string not found.");
            throw new Exception("Connection string not found.");
        }
        connectionString = connectionStringSettings.ConnectionString;
    }

    public string ConnectionString => connectionString; // Expose the connection string

    public void ExecuteQuery(string query)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Query executed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

public DataTable ExecuteReadQuery(string query)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                MessageBox.Show("Data read successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        return dataTable;
    }

    public bool TestConnection()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                return true; // Connection successful
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
                return false; // Connection failed
            }
        }
    }

    public DataTable GetMedicines(int offset, int limit)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("LoadMedicine", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Offset", offset);
                command.Parameters.AddWithValue("@Limit", limit);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        return dataTable;
    }
    public DataTable GetCustomerData()
    {
        DataTable customers = new DataTable();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetCustomer", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Specify that it’s a stored procedure
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(customers);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }

        return customers;
    }

    public DataTable GetEmployeeData()
    {
        DataTable employee = new DataTable();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Specify that it’s a stored procedure
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(employee);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }

        return employee;
    }

    public DataTable GetReceiptsData()
    {
        DataTable receipt = new DataTable();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetReceipt", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Specify that it’s a stored procedure
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(receipt);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }

        return receipt;
    }

    public DataTable GetExpiredOrNearExpiredProducts()
    {
        DataTable expiredProducts = new DataTable();
        DateTime today = DateTime.Now;
        DateTime nearExpirationDate = today.AddDays(30); // Define "near expiration" as 30 days

        string query = @"
            SELECT top 1000 MID, MedicineName, ExperationDATE
            FROM MedInventory 
            WHERE ExperationDATE <= @Today";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Today", today);
                command.Parameters.AddWithValue("@NearExpirationDate", nearExpirationDate);

                try
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(expiredProducts);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        return expiredProducts;
    }
    public DataTable GetOutOfStockProduct()
    {
        DataTable OOSProduct = new DataTable();

        string query = @"
            SELECT * FROM MedInventory WHERE StockQuantity <= 5";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                try
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(OOSProduct);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }
        return OOSProduct;
    }
}