using GameCenterForm.ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm.DataAccessLayers
{
    public class DataAccessLayerCustomer : DataAccessLayer

    {
        private const string SELECT_ALL_QUERY = "SELECT * FROM Customer";
        private const string DELETE_QUERY = "DELETE FROM Customer WHERE CustomerID = @CustomerId";
        private const string INSERT_QUERY = "INSERT INTO Customer (CustomerID, Name, PhoneNumber, Email) VALUES (@CustomerID, @Name, @PhoneNumber, @Email)";
        private const string UPDATE_QUERY = "UPDATE Customer SET Name = @Name, PhoneNumber = @PhoneNumber, Email = @Email WHERE CustomerID = @CustomerID";

        public override DataSet GetAll()
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(SELECT_ALL_QUERY, connection);
                    adapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }

        public override void Insert(Object o)
        {
            try
            {
                if (o is Customer)
                {
                    Customer customer = (Customer)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        using (SqlCommand command = new SqlCommand(INSERT_QUERY, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                            command.Parameters.AddWithValue("@Name", customer.Name);
                            command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                            command.Parameters.AddWithValue("@Email", customer.Email);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public override void Delete(object o)
        {
            try
            {
                if (o is Customer)
                {
                    Customer customer = (Customer)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        connection.Open();

                        // Check for related booking 
                        SqlCommand bookingSelectCommand = connection.CreateCommand();
                        bookingSelectCommand.CommandText = "SELECT * FROM Booking WHERE PaymentID IN (SELECT PaymentID FROM Payment WHERE CustomerID = @CustomerId)";
                        bookingSelectCommand.Parameters.AddWithValue("@CustomerId", customer.CustomerID);

                        SqlDataAdapter bookingDataAdapter = new SqlDataAdapter(bookingSelectCommand);

                        DataTable bookingDataTable = new DataTable();
                        bookingDataAdapter.Fill(bookingDataTable);

                        if (bookingDataTable.Rows.Count > 0)
                        {
                            // Handle related booking records
                            SqlCommand bookingDeleteCommand = connection.CreateCommand();
                            bookingDeleteCommand.CommandText = "DELETE FROM Booking WHERE PaymentID IN (SELECT PaymentID FROM Payment WHERE CustomerID = @CustomerId)";
                            bookingDeleteCommand.Parameters.AddWithValue("@CustomerId", customer.CustomerID);

                            bookingDeleteCommand.ExecuteNonQuery();
                        }

                        // Check for related payment records
                        SqlCommand paymentSelectCommand = connection.CreateCommand();
                        paymentSelectCommand.CommandText = "SELECT * FROM Payment WHERE CustomerID = @CustomerId";
                        paymentSelectCommand.Parameters.AddWithValue("@CustomerId", customer.CustomerID);

                        SqlDataAdapter paymentDataAdapter = new SqlDataAdapter(paymentSelectCommand);

                        DataTable paymentDataTable = new DataTable();
                        paymentDataAdapter.Fill(paymentDataTable);

                        if (paymentDataTable.Rows.Count > 0)
                        {
                            // Handle related payment records
                            SqlCommand paymentDeleteCommand = connection.CreateCommand();
                            paymentDeleteCommand.CommandText = "DELETE FROM Payment WHERE CustomerID = @CustomerId";
                            paymentDeleteCommand.Parameters.AddWithValue("@CustomerId", customer.CustomerID);

                            paymentDeleteCommand.ExecuteNonQuery();
                        }

                        // Attempt to delete the customer record
                        SqlCommand customerDeleteCommand = connection.CreateCommand();
                        customerDeleteCommand.CommandText = "DELETE FROM Customer WHERE CustomerID = @CustomerId";
                        customerDeleteCommand.Parameters.AddWithValue("@CustomerId", customer.CustomerID);

                        int rowsAffected = customerDeleteCommand.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            Console.WriteLine($"Customer with ID {customer.CustomerID} does not exist.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public override void Update(object o)
        {
            try
            {
                if (o is Customer)
                {
                    Customer customer = (Customer)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        using (SqlCommand command = new SqlCommand(UPDATE_QUERY, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                            command.Parameters.AddWithValue("@Name", customer.Name);
                            command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                            command.Parameters.AddWithValue("@Email", customer.Email);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public override DataSet Find(string searchTerm)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    string query = "SELECT * FROM Customer WHERE CustomerID LIKE @SearchTerm " +
                                   "OR PhoneNumber LIKE @SearchTerm OR Name LIKE @SearchTerm OR Email LIKE @SearchTerm";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            connection.Open();

                            adapter.Fill(dataSet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }
    }
}
