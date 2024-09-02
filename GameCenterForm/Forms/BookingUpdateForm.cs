using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;


namespace GameCenterForm.Forms
{
    public partial class BookingUpdateForm : Form
    {
        DataAccessLayerBookings dataAccessLayer = new();
        DataAccessLayerPayments dataAccessLayerPayments = new();

        public BookingUpdateForm()
        {
            InitializeAsync();
            //InitializeComponent();
        }
        public async Task InitializeAsync()
        {
            InitializeComponent();
            await FillDataGridView();
            dateTimePickerEdit.MinDate = DateTime.Today;
            dataGridView1.ClearSelection();

        }

        public async Task FillDataGridView()
        {
            dataGridView1.DataSource = (await dataAccessLayer.GetAllAsync()).Tables[0];
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)

        {
            try
            {
                //if a row from the table is selected
                if (e.RowIndex >= 0)
                {
                    //Returns how many columns there are in the DataGridView
                    int columnCount = dataGridView1.Columns.Count;

                    if (e.ColumnIndex < columnCount)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[e.RowIndex].Selected = true;

                    }

                    DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];


                    lblBookingID.Text = clickedRow.Cells[0].Value.ToString();

                    string edit = clickedRow.Cells[1].Value.ToString();
                    DateTime dt = DateTime.Parse(edit);
                    dateTimePickerEdit.Value = dt;

                    string timeSlot = clickedRow.Cells[2].Value.ToString();
                    DateTime tSlot = DateTime.Parse(timeSlot);
                    dateTimePickerTimeSlot.Value = tSlot;

                    txtBoxPrice.Text = clickedRow.Cells[3].Value.ToString();
                    lblCustomerID.Text = clickedRow.Cells[4].Value.ToString();
                    lblPaymentID.Text = clickedRow.Cells[5].Value.ToString();

                }

                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void dateTimePickerTimeSlot_ValueChanged(object sender, EventArgs e)
        {
            int selectedHour = dateTimePickerTimeSlot.Value.Hour;

            // Set the format of the DateTimePicker to HH:mm
            dateTimePickerTimeSlot.CustomFormat = "HH:00";

            // Get the current date
            DateTime currentDate = DateTime.Today;

            // Set the minimum and maximum times to 10:00 and 23:00, respectively
            DateTime minTime = currentDate.AddHours(10);
            DateTime maxTime = currentDate.AddHours(23);

            // Set the minimum and maximum dates to the current date with the desired times
            dateTimePickerTimeSlot.MinDate = minTime;
            dateTimePickerTimeSlot.MaxDate = maxTime;

            dateTimePickerTimeSlot.ValueChanged += (sender, e) =>
            {
                // Get the selected DateTime
                var selectedDateTime = dateTimePickerTimeSlot.Value;

                // Set the minute to a fixed value (in this case, 0)
                selectedDateTime = selectedDateTime.AddMinutes(-selectedDateTime.Minute);

                // Set the Value property to the modified DateTime
                /*dateTimePickerTimeSlot.Value = selectedDateTime;


                // Check if the selected hour is outside the allowed range of 10 to 23
                if (selectedHour < 10 || selectedHour > 23)
                {
                    // Set the Value property to the minimum or maximum allowed value
                    if (selectedHour < 10)
                    {

                        dateTimePickerTimeSlot.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0);

                    }
                    else
                    {
                        dateTimePickerTimeSlot.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 0, 0);
                    }
                }*/
            };
        }


        private void dateTimePickerEdit_ValueChanged_1(object sender, EventArgs e)
        {
            dateTimePickerEdit.MaxDate = DateTime.Today.AddMonths(2);
        }


        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a booking to update!", "No booking selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string bookingID = lblBookingID.Text;
                    DateTime dt = dateTimePickerEdit.Value;
                    string timeSlot = dateTimePickerTimeSlot.Text;
                    int price = int.Parse(txtBoxPrice.Text);
                    string customerID = lblCustomerID.Text;
                    string paymentID = lblPaymentID.Text;
                    int result = string.Compare(timeSlot.ToString(), DateTime.Now.ToString("HH:mm"));

                    if (dt < DateTime.Now.Date)
                    {
                        MessageBox.Show("You can't book a date in the past", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (dt == DateTime.Now.Date && result < 0)
                    {
                        MessageBox.Show("You can't book a time in the past", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (dt == DateTime.Now.Date && result == 0)
                    {
                        MessageBox.Show("You can't book a time in the past", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        Booking tmp = new Booking(bookingID, dt, timeSlot, price, customerID, paymentID);
                        Console.WriteLine(timeSlot);
                        dataAccessLayer.Update(tmp);
                        await FillDataGridView();

                        Payment a = new Payment(paymentID, price);

                        dataAccessLayerPayments.Update(a);

                        MessageBox.Show("Booking " + lblBookingID.Text + " has been succesfully updated.", "Update complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
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