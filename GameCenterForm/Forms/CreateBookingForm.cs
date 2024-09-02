using GameCenterForm.DataAccessLayers;

namespace GameCenterForm.Forms
{
    public partial class CreateBookingForm : Form
    {


        public delegate void MyDelegate(string id, string console, string date, string timeslot, string price, string paymentMethod);
        public MyDelegate myDelegate;



        public CreateBookingForm()
        {
            InitializeComponent();
            PopulateEmployeeComboBox();
            PopulateConsoleComboBox();
            mCalendarReservation.MinDate = DateTime.Today;
        }

        // The forms load event. We want to fill the list with timeslots here
        private void CreateBookingForm_Load(object sender, EventArgs e)
        {
            try
            {
                lBoxTimeSlot.Items.Clear();
                for (int i = 10; i < 24; i++)
                {
                    string time = string.Format("{0:00}:00", i);
                    lBoxTimeSlot.Items.Add(time);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            NewPaymentForm();
        }

        private void NewPaymentForm()
        {
            try
            {
                NewPaymentForm form = new();

                string id = cBoxCustomer.Text;
                string console = cBoxConsoleType.Text;
                int result = string.Compare(lBoxTimeSlot.SelectedItem.ToString(), DateTime.Now.ToString("HH:mm"));

                if (mCalendarReservation.SelectionStart.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("You can't book a date in the past", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (mCalendarReservation.SelectionStart.Date == DateTime.Now.Date && result < 0)
                {
                    MessageBox.Show("You can't book a time in the past", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (mCalendarReservation.SelectionStart.Date == DateTime.Now.Date && result == 0)
                {
                    MessageBox.Show("You can't book a time in the past", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (lBoxTimeSlot.SelectedItem == null)
                {
                    MessageBox.Show("You need to select a time slot", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (cBoxPaymentMethod.SelectedItem == null)
                {
                    MessageBox.Show("You need to select a payment method", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (cBoxCustomer.SelectedItem == null)
                {
                    MessageBox.Show("You need to select a customer", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (cBoxConsoleType.SelectedItem == null)
                {
                    MessageBox.Show("You need to select a console", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DateTime date = mCalendarReservation.SelectionStart.Date;
                    string timeslot = lBoxTimeSlot.SelectedItem.ToString();
                    string price = lblPrice.Text;
                    string paymentMethod = cBoxPaymentMethod.SelectedItem.ToString();


                    myDelegate += form.ReceiveInformation;
                    myDelegate(id, console, date.ToString("yyyy-MM-dd"), timeslot, price, paymentMethod);

                    //form.Owner = this;

                    form.Show();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        //Changing price depending on what time that gets booked
        private void lBoxTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            string timeslot = lBoxTimeSlot.SelectedItem.ToString();
            int myHour = int.Parse(timeslot.Substring(0, 2));

            if (myHour < 12 || myHour > 18)
            {
                lblPrice.Text = "80";
            }
            else
            {
                lblPrice.Text = "120";
            }
        }

        private void PopulateEmployeeComboBox()
        {
            try
            {
                List<string> items = DataAccessLayerBookings.GetComboBoxCustomer();

                cBoxCustomer.Items.Clear();
                cBoxCustomer.Items.AddRange(items.ToArray());
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void PopulateConsoleComboBox()
        {
            try
            {
                List<string> items = DataAccessLayerBookings.GetComboBoxConsoles();

                cBoxConsoleType.Items.Clear();
                cBoxConsoleType.Items.AddRange(items.ToArray());
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }


        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Panel parentPanel = (Panel)this.Parent;
            MainForm mainForm = (MainForm)parentPanel.Parent;
            mainForm.panel2.Controls.Clear();


            BookingsForm form = new();
            form.TopLevel = false;
            form.AutoScroll = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = FormBorderStyle.None;

            mainForm.panel2.Controls.Add(form);
            form.Show();
        }
    }
}
