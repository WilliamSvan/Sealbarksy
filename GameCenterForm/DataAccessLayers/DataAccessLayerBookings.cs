using GameCenterForm.ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm.DataAccessLayers
{


    internal class DataAccessLayerBookings : DataAccessLayer
    {

        private const string SELECT_BOOKINGS_QUERY = "SELECT b.BookingID, b.BookingDate, b.TimeSlot, b.Price, b.CustomerID, b.PaymentID, gc.ConsoleType, gcb.TableNo FROM Booking b JOIN GamingConsoleBooking gcb ON b.BookingID = gcb.BookingID JOIN GamingConsole gc ON gc.TableNo = gcb.TableNo";

        private const string INSERT_BOOKINGS_QUERY = "INSERT INTO Booking (BookingID, BookingDate, TimeSlot, Price, CustomerID, PaymentID) VALUES (@BookingID, @BookingDate, @TimeSlot, @Price, @CustomerID, @PaymentID)";
        //private const string UPDATE_BOOKING_QUERY = "UPDATE Booking SET BookingDate=@BookingDate, TimeSlot=@TimeSlot, Price=@Price WHERE BookingID = @BookingID AND PaymentID = (SELECT PaymentID FROM Payment WHERE CustomerID = @CustomerID)";
        private const string UPDATE_BOOKING_QUERY = "UPDATE Booking SET BookingDate=@BookingDate, TimeSlot=@TimeSlot, Price=@Price WHERE BookingID = @BookingID AND PaymentID = @PaymentID ";

        private const string DELETE_BOOKING_QUERY = "DELETE FROM Booking WHERE BookingID = @BookingID";

        private const string DELETE_PAYMENT_QUERY = "DELETE FROM Payment WHERE PaymentID = @PaymentID";

        //, CustomerID=@CustomerID, PaymentID=@PaymentID 
        private const string SELECT_CUSTOMER_QUERY = "SELECT CustomerID, Name FROM Customer ORDER BY Name";


        public override DataSet GetAll()
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(SELECT_BOOKINGS_QUERY, connection);

                    adapter.Fill(dataSet);
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }
        public async Task<DataSet> GetAllAsync()
        {
            return await Task.Run(() => GetAll());
        }

        public override void Insert(object o)
        {
            try
            {
                if (o is Booking)
                {
                    Booking booking = (Booking)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        connection.Open();

                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = INSERT_BOOKINGS_QUERY;

                        SqlDataAdapter paymentDataAdapter = new SqlDataAdapter(command);

                        //SqlDataAdapter bookingDataAdapter = new SqlDataAdapter(command);


                        command.Parameters.AddWithValue("@BookingID", booking.BookingID);
                        command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                        command.Parameters.AddWithValue("@TimeSlot", booking.TimeSlot);
                        command.Parameters.AddWithValue("@Price", booking.Price);
                        command.Parameters.AddWithValue("@CustomerID", booking.CustomerID);
                        command.Parameters.AddWithValue("@PaymentID", booking.PaymentID);

                        command.ExecuteNonQuery();
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
                if (o is Booking)
                {
                    Booking booking = (Booking)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        connection.Open();

                        // Attempt to delete the booking record
                        SqlCommand bookingDeleteCommand = connection.CreateCommand();
                        bookingDeleteCommand.CommandText = DELETE_BOOKING_QUERY;
                        bookingDeleteCommand.Parameters.AddWithValue("@BookingID", booking.BookingID);

                        int rowsAffected = bookingDeleteCommand.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            Console.WriteLine($"Booking with ID {booking.BookingID} does not exist.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
        public void DeletePayment(string paymentID)
        {
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();
                    // Attempt to delete the payment record
                    SqlCommand paymentDeleteCommand = connection.CreateCommand();
                    paymentDeleteCommand.CommandText = DELETE_PAYMENT_QUERY;
                    paymentDeleteCommand.Parameters.AddWithValue("@PaymentID", paymentID);

                    int rowsAffected = paymentDeleteCommand.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine($"Payment with ID {paymentID} does not exist.");
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
                if (o is Booking)
                {
                    Booking booking = (Booking)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        using (SqlCommand command = new SqlCommand(UPDATE_BOOKING_QUERY, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@BookingID", booking.BookingID);
                            command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                            command.Parameters.AddWithValue("@TimeSlot", booking.TimeSlot);
                            command.Parameters.AddWithValue("@Price", booking.Price);
                            command.Parameters.AddWithValue("@CustomerID", booking.CustomerID);
                            command.Parameters.AddWithValue("@PaymentID", booking.PaymentID);

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

        public void newBooking()
        {
            try
            {

            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }


        public static List<string> GetComboBoxCustomer() //get Customer from database
        {
            List<string> items = new List<string>();

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    using (SqlCommand command = new SqlCommand(SELECT_CUSTOMER_QUERY, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            connection.Open();

                            DataTable customerDataTable = new DataTable();
                            adapter.Fill(customerDataTable);

                            foreach (DataRow row in customerDataTable.Rows)
                            {
                                string customerId = row["CustomerID"].ToString();
                                string name = row["Name"].ToString();
                                items.Add(string.Format("{0}, {1}", customerId, name));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return items;
        }
        public static List<string> GetComboBoxConsoles()
        {
            List<string> items = new List<string>();
            string queryString = "SELECT ConsoleType FROM GamingConsole GROUP BY ConsoleType";

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    using (SqlCommand consoleTypeSelectCommand = new SqlCommand(queryString, connection))
                    {
                        using (SqlDataAdapter consoleTypeDataAdapter = new SqlDataAdapter(consoleTypeSelectCommand))
                        {
                            connection.Open();

                            DataTable consoleTypeDataTable = new DataTable();
                            consoleTypeDataAdapter.Fill(consoleTypeDataTable);

                            foreach (DataRow row in consoleTypeDataTable.Rows)
                            {
                                items.Add(row["ConsoleType"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return items;
        }
        public static List<string> GetComboBoxPayments()
        {
            List<string> items = new List<string>();
            string queryString = "SELECT PaymentMethod FROM Payment GROUP BY PaymentMethod";

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    using (SqlCommand paymentMethodSelectCommand = new SqlCommand(queryString, connection))
                    {
                        using (SqlDataAdapter paymentMethodDataAdapter = new SqlDataAdapter(paymentMethodSelectCommand))
                        {
                            connection.Open();

                            DataTable paymentDataTable = new DataTable();
                            paymentMethodDataAdapter.Fill(paymentDataTable);

                            foreach (DataRow row in paymentDataTable.Rows)
                            {
                                items.Add(row["PaymentMethod"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return items;
        }

        public override DataSet Find(string searchTerm)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    string query = "SELECT * FROM Booking WHERE BookingID LIKE @SearchTerm " +
                                   "OR BookingDate LIKE @SearchTerm OR TimeSlot LIKE @SearchTerm " +
                                   "OR Price LIKE @SearchTerm OR CustomerID LIKE @SearchTerm " +
                                   "OR PaymentID LIKE @SearchTerm";

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