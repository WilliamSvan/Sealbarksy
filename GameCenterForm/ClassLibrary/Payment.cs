using GameCenterForm.DataAccessLayers;
namespace GameCenterForm.ClassLibrary
{
    public class Payment
    {
        public string PaymentID { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string CustomerID { get; set; }

        public Payment(string paymentID, int amount, DateTime paymentDate, string paymentMethod, string customerID)
        {
            this.PaymentID = paymentID;
            this.Amount = amount;
            this.PaymentDate = paymentDate;
            this.PaymentMethod = paymentMethod;
            this.CustomerID = customerID;
        }

        // Constructor that generates a new, unique PaymentID value
        public Payment(int amount, DateTime paymentDate, string paymentMethod, string customerID)
        {
            PaymentID = DataAccessLayer.GetNextID("P", "Payment", "PaymentID");
            this.Amount = amount;
            this.PaymentDate = paymentDate;
            this.PaymentMethod = paymentMethod;
            this.CustomerID = customerID;
        }
        public Payment(string paymentID, int amount)
        {
            PaymentID = paymentID;
            this.Amount = amount;


        }

    }
}
