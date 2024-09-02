using GameCenterForm.ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm.DataAccessLayers
{
    public class DataAccessLayerConsoles : DataAccessLayer
    {
        private const string SELECT_ALL_CONSOLES = "SELECT * FROM GamingConsole";
        private const string DELETE_CONSOLE_QUERY = "DELETE FROM GamingConsole WHERE TableNo = @TableNo";
        private const string INSERT_CONSOLE_QUERY = "INSERT INTO GamingConsole" +
            " (TableNo, ConsoleType, NbrOfPlayers) VALUES (@TableNo, @ConsoleType, @NbrOfPlayers)";
        private const string DELETE_PAYMENT_QUERY = "DELETE FROM Payment WHERE PaymentID = " +
            "(SELECT p.PaymentID FROM Payment p " +
            "JOIN Booking b ON b.PaymentID = p.PaymentID " +
            "JOIN GamingConsoleBooking gb ON gb.BookingID = b.BookingID " +
            "WHERE gb.TableNo = @TableNo)";

        private const string UPDATE_CONSOLE_QUERY = "UPDATE GamingConsole SET TableNo = @TableNo, " +
            "ConsoleType = @ConsoleType, NbrOfPlayers = @NbrOfPlayers WHERE TableNo = @TableNo";

        public override DataSet GetAll()
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(SELECT_ALL_CONSOLES, connection);
                    adapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }

        public override void Insert(object o)
        {
            try
            {
                if (o is GamingConsole)
                {
                    GamingConsole gamingConsole = (GamingConsole)o;

                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(INSERT_CONSOLE_QUERY, connection))
                        {

                            command.Parameters.AddWithValue("@TableNo", gamingConsole.TableNo);
                            command.Parameters.AddWithValue("@ConsoleType", gamingConsole.ConsoleType);
                            command.Parameters.AddWithValue("@NbrOfPlayers", gamingConsole.NbrOfPlayers);

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
                if (o is GamingConsole)
                {
                    GamingConsole gamingConsole = (GamingConsole)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        connection.Open();

                        using (SqlCommand command = new(DELETE_CONSOLE_QUERY, connection))
                        {
                            command.Parameters.AddWithValue("@TableNo", gamingConsole.TableNo);
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
        //DELETE_PAYMENT_QUERY
        public void DeletePayment(int tableNo)
        {
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    using (SqlCommand command = new(DELETE_PAYMENT_QUERY, connection))
                    {
                        command.Parameters.AddWithValue("@TableNo", tableNo);
                        command.ExecuteNonQuery();
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
                    string query = "SELECT * FROM GamingConsole WHERE TableNo LIKE @SearchTerm " +
                                   "OR ConsoleType LIKE @SearchTerm OR NbrOfPlayers LIKE @SearchTerm";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
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

        public override void Update(object o)
        {
            try
            {
                if (o is GamingConsole)
                {
                    GamingConsole gamingConsole = (GamingConsole)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        using (SqlCommand command = new SqlCommand(UPDATE_CONSOLE_QUERY, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@TableNo", gamingConsole.TableNo);
                            command.Parameters.AddWithValue("@ConsoleType", gamingConsole.ConsoleType);
                            command.Parameters.AddWithValue("@NbrOfPlayers", gamingConsole.NbrOfPlayers);

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

        public int GetNextTableNumber()
        {
            int nextNumber = 1;

            try
            {
                // Create default value
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    string query = "SELECT MAX(TableNo) FROM GamingConsole";

                    using (SqlCommand command = new(query, connection))
                    {

                        object result = command.ExecuteScalar();

                        //DBNull is a class that represents nonexistent value returned from database
                        if (result != DBNull.Value)
                        {
                            int highestNumber = Convert.ToInt32(result);
                            int numRecords = GetNumberOfTables();

                            // If this is true it means there should be no gaps
                            if (highestNumber == numRecords)
                            {
                                nextNumber = highestNumber + 1;
                            }
                            else
                            {
                                nextNumber = FindFirstAvailableNumber();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return nextNumber;
        }

        private int FindFirstAvailableNumber()
        {
            int firstAvailableNumber = -1;

            try
            {
                // Defaul value
                string query = "SELECT TableNo FROM GamingConsole ORDER BY TableNo ASC";
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    using (SqlCommand command = new(query, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                int currentNumber = reader.GetInt32(0);

                                // if no 1 is missing
                                if (firstAvailableNumber == -1 && currentNumber > 1)
                                {
                                    firstAvailableNumber = 1;
                                }

                                // if currentNumber is greater than the firstAvailableNumber there is a gap
                                if (firstAvailableNumber != -1 && currentNumber > firstAvailableNumber + 1)
                                {
                                    break;
                                }

                                firstAvailableNumber = currentNumber;
                            }
                        }
                    }
                }

                // Safety check that there is at least on GamingConsole
                if (firstAvailableNumber == -1)
                {
                    firstAvailableNumber = GetNumberOfTables() + 1;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return firstAvailableNumber + 1;
        }

        private int GetNumberOfTables()
        {
            int numberOfTables = 0;
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    string query = "SELECT COUNT(*) FROM GamingConsole";

                    using (SqlCommand command = new(query, connection))
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            numberOfTables = Convert.ToInt32(result);
                        }
                        else
                        {
                            numberOfTables = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return numberOfTables;
        }
    }
}
