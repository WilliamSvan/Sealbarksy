using GameCenterForm.ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm.DataAccessLayers
{
    public class DataAccessLayerPayments : DataAccessLayer

    {
        private const string UPDATE_PAYMENT_QUERY =
            "UPDATE Payment SET Amount = @Amount WHERE PaymentID = @PaymentID";

        private const string SELECT_ALL_PAYMENTS = "SELECT* From Payment";

        private const string INSERT_PAYMENT_QUERY =
            "INSERT INTO Payment (PaymentID, Amount, PaymentDate, PaymentMethod, CustomerID) " +
            "VALUES (@PaymentID, @Amount, @PaymentDate, @PaymentMethod, @CustomerID)";
        public override DataSet GetAll()
        {
            throw new NotImplementedException();
        }

        public override void Insert(object o)
        {
            try
            {
                if (o is Payment)
                {
                    Payment payment = (Payment)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        connection.Open();

                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = INSERT_PAYMENT_QUERY;

                        //SqlDataAdapter paymentDataAdapter = new SqlDataAdapter(command);

                        command.Parameters.AddWithValue("@PaymentID", payment.PaymentID);
                        command.Parameters.AddWithValue("@Amount", payment.Amount);
                        command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                        command.Parameters.AddWithValue("@PaymentMethod", payment.PaymentMethod);
                        command.Parameters.AddWithValue("@CustomerID", payment.CustomerID);

                        command.ExecuteNonQuery();


                        //DataTable bookingDataTable = new DataTable();
                        //paymentDataAdapter.Fill(bookingDataTable);


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
                if (o is Payment)
                {
                    Payment payment = (Payment)o;
                    using (SqlConnection connection = GetDatabaseConnection())

                    {
                        using (SqlCommand command = new SqlCommand(UPDATE_PAYMENT_QUERY, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@Amount", payment.Amount);
                            // command.Parameters.AddWithValue("@CustomerID", payment.CustomerID);
                            command.Parameters.AddWithValue("@PaymentID", payment.PaymentID);

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
                if (o is Payment)
                {
                    Payment payment = (Payment)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        connection.Open();

                        // Attempt to delete the booking record
                        SqlCommand paymentDeleteCommand = connection.CreateCommand();
                        paymentDeleteCommand.CommandText = "DELETE FROM Payment WHERE PaymentID = @PaymentID";
                        paymentDeleteCommand.Parameters.AddWithValue("@PaymentID", payment.PaymentID);

                        int rowsAffected = paymentDeleteCommand.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            Console.WriteLine($"Payment with ID {payment.PaymentID} does not exist.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException sqlException)
                {
                    if (sqlException.Number is 547)
                    {
                        MessageBox.Show("You can't delete a payment that is connected to a booking, you must delete the booking first!",
                            "Payment is connected to a booking!",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    ErrorHandler.HandleException(ex);
                }
            }
        }

        public DataSet GetBookings()
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(SELECT_ALL_PAYMENTS, connection);

                    adapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }

        public override DataSet Find(string searchTerm)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    string query = "SELECT * FROM Payment WHERE PaymentID LIKE @SearchTerm " +
                                   "OR Amount LIKE @SearchTerm OR PaymentDate LIKE @SearchTerm " +
                                   "OR PaymentMethod LIKE @SearchTerm OR CustomerID LIKE @SearchTerm";

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
