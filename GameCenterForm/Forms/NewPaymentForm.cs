using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;
using System.Data;

namespace GameCenterForm.Forms
{
    public partial class NewPaymentForm : Form
    {
        DataAccessLayerBookings dataAccessLayerBookings;
        DataAccessLayerPayments dataAccessLayerPayments;
        DataAccessLayerGamingConsoleBooking dataAccessLayerGamingConsoleBooking;

        public NewPaymentForm()
        {
            try
            {
                InitializeComponent();
                dataAccessLayerPayments = new DataAccessLayerPayments();
                dataAccessLayerBookings = new DataAccessLayerBookings();
                dataAccessLayerGamingConsoleBooking = new DataAccessLayerGamingConsoleBooking();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public void ReceiveInformation(string id, string console, string date, string timeslot, string price, string paymentMethod)
        {
            lblCustomer.Text = id;
            lblConsoleType.Text = console;
            lblBookingDate.Text = date.ToString();
            lblTimeSlot.Text = timeslot;
            lblPrice.Text = price;
            lblPaymentMethod.Text = paymentMethod;
        }


        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                string customer = lblCustomer.Text;
                string[] customerSplit = customer.Split(',');
                string id = customerSplit[0];
                // Create a new Payment object
                Payment payment = new Payment(
                    int.Parse(lblPrice.Text),
                    DateTime.Now,
                    lblPaymentMethod.Text,
                    id);

                // Insert the Payment record into the database
                dataAccessLayerPayments.Insert(payment);

                // Retrieve the PaymentID value generated for the Payment record
                string paymentID = payment.PaymentID;

                // Create a new Booking object with the generated PaymentID value
                Booking booking = new Booking(
                    DateTime.Parse(lblBookingDate.Text),
                    lblTimeSlot.Text,
                    int.Parse(lblPrice.Text),
                    id,
                    paymentID);

                // Insert the Booking record into the database
                dataAccessLayerBookings.Insert(booking);

                // Retrieve the BookingID value generated for the Booking record
                string bookingID = booking.BookingID;

                // Get the available gaming table for the specified console type, booking date, and time slot
                DataSet availableTables = dataAccessLayerGamingConsoleBooking.GetAvailableTableNo(lblConsoleType.Text, lblBookingDate.Text, lblTimeSlot.Text);

                if (availableTables.Tables[0].Rows.Count == 0)
                {
                    // No available gaming tables were found
                    MessageBox.Show("No available gaming tables found for the selected console type, booking date, and time slot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the first available gaming table from the dataset
                int TableNo = (int)availableTables.Tables[0].Rows[0]["TableNo"];

                // Create a new GamingConsoleBooking object
                GamingConsoleBooking consoleBooking = new GamingConsoleBooking(
                    TableNo,
                    bookingID
                    );

                // Insert the Gaming record into the database
                dataAccessLayerGamingConsoleBooking.Insert(consoleBooking);

                // Show success message and close form
                MessageBox.Show("Payment and booking created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
    }
}
