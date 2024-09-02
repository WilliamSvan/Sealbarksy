using GameCenterForm.DataAccessLayers;

namespace GameCenterForm.ClassLibrary
{
    public class Booking
    {
        public string BookingID { get; set; }
        public DateTime BookingDate { get; set; }
        public string TimeSlot { get; set; }
        public int Price { get; set; }
        public string CustomerID { get; set; }
        public string PaymentID { get; set; }

        public Booking(string bookingID, DateTime bookingDate, string timeSlot, int price, string customerID, string paymentID)
        {
            BookingID = bookingID;
            BookingDate = bookingDate;
            TimeSlot = timeSlot;
            Price = price;
            CustomerID = customerID;
            PaymentID = paymentID;
        }

        public Booking(DateTime bookingDate, string timeSlot, int price, string customerID, string paymentID)
        {
            BookingID = DataAccessLayer.GetNextID("B", "Booking", "BookingID");
            BookingDate = bookingDate;
            TimeSlot = timeSlot;
            Price = price;
            CustomerID = customerID;
            PaymentID = paymentID;
        }

    }
}
