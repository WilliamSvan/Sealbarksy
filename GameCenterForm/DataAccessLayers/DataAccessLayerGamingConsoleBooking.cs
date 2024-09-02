using GameCenterForm.ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm.DataAccessLayers
{
    public class DataAccessLayerGamingConsoleBooking : DataAccessLayer
    {
        private const string INSERT_GamingConsoleBooking_QUERY = "INSERT INTO GamingConsoleBooking (TableNo, BookingID) VALUES (@TableNo, @BookingID)";


        public override void Insert(object o)
        {
            try
            {
                if (o is GamingConsoleBooking)
                {
                    GamingConsoleBooking consoleBooking = (GamingConsoleBooking)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        connection.Open();

                        SqlCommand command = connection.CreateCommand();
                        command.CommandText = INSERT_GamingConsoleBooking_QUERY;

                        command.Parameters.AddWithValue("@TableNo", consoleBooking.TableNo);
                        command.Parameters.AddWithValue("@BookingID", consoleBooking.BookingID);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
        public DataSet GetAvailableTableNo(string consoleType, string bookingDate, string timeSlot)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    string query = @"SELECT TOP 1 c.TableNo 
                        FROM GamingConsole c 
                        LEFT JOIN GamingConsoleBooking bc ON c.TableNo = bc.TableNo 
                        LEFT JOIN Booking b ON bc.BookingID = b.BookingID 
                        WHERE c.ConsoleType = @ConsoleType 
                            AND c.TableNo NOT IN (SELECT bc.TableNo 
                                    FROM GamingConsoleBooking bc 
                                    INNER JOIN Booking b ON bc.BookingID = b.BookingID 
                                    WHERE b.BookingDate = @BookingDate AND b.TimeSlot = @TimeSlot) 
                            AND (b.BookingID IS NULL OR b.BookingDate <> @BookingDate OR b.TimeSlot <> @TimeSlot)
                        ORDER BY c.TableNo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@ConsoleType", consoleType);
                        command.Parameters.AddWithValue("@BookingDate", bookingDate);
                        command.Parameters.AddWithValue("@TimeSlot", timeSlot);

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

        public override DataSet Find(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public override DataSet GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
