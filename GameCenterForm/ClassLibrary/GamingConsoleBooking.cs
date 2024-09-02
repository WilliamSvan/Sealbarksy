namespace GameCenterForm.ClassLibrary
{
    public class GamingConsoleBooking
    {
        public int TableNo { get; set; }
        public string BookingID { get; set; }

        public GamingConsoleBooking(int consoleType, string bookingID)
        {
            TableNo = consoleType;
            BookingID = bookingID;
        }
    }
}
