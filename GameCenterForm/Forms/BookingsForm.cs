﻿using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;
using GameCenterForm.Forms;
using System.Data;

namespace GameCenterForm
{
    public partial class BookingsForm : Form
    {
        DataAccessLayerBookings dataAccessLayer = new();
        public BookingsForm()
        {
            try
            {
                InitializeComponent();
                FillDataGridView();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }

        //In this method, we first set the DataSource property of the DataGridView to the result of
        //calling GetAll().Tables[0]. This will populate the DataGridView with data.

        //Next, we add an event handler for the DataBindingComplete event of the DataGridView.
        //We do this by subscribing to the event with the += operator and passing in the name of the
        //event handler method (dataGridViewBookings_DataBindingComplete). This event handler
        //method will be called when the DataBindingComplete event is raised.
        public void FillDataGridView()
        {
            try
            {
                dataGridViewBookings.DataSource = dataAccessLayer.GetAll().Tables[0];
                dataGridViewBookings.DataBindingComplete += dataGridViewBookings_DataBindingComplete;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        //Method dataGridViewBookings_DataBindingComplete and comment generated by ChatGPT
        //This method is called when the DataBindingComplete event is raised. In this method,
        //we simply call the ClearSelection() method of the DataGridView to clear any row selection
        //that may have occurred during the data binding process.

        //By using the DataBindingComplete event to clear the row selection, we ensure that the
        //ClearSelection() method is called after the DataGridView has been populated with data
        //and any row selection has occurred.This should prevent the first row from being selected
        //when the DataGridView is initially displayed.

        private void dataGridViewBookings_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewBookings.ClearSelection();
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                NewBookingCreateForm();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Checking if any row in the DataGridView is selected
            //If no, the user will be notified by a textbox and the method stops here
            try
            {
                if (dataGridViewBookings.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select the booking to delete",
                        "No booking selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected row and put the values in a Booking object 
                DataGridViewRow selectedRow = dataGridViewBookings.SelectedRows[0];
                string bookingID = selectedRow.Cells["BookingID"].Value.ToString();
                string customerID = selectedRow.Cells["CustomerID"].Value.ToString();
                string paymentID = selectedRow.Cells["PaymentID"].Value.ToString();
                DateTime bookingDate = (DateTime)selectedRow.Cells["BookingDate"].Value;
                string timeSlot = selectedRow.Cells["TimeSlot"].Value.ToString();
                int price = (int)selectedRow.Cells["Price"].Value;

                Booking booking = new Booking(bookingID, bookingDate, timeSlot, price, customerID, paymentID);

                //MessageBox that asks user to confirm deletion
                DialogResult result =
                    MessageBox.Show(
                        $"You are about to delete booking ID: {booking.BookingID} for customer ID: {booking.CustomerID}. Do you want to proceed?",
                        "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //If user presses No nothing happens
                if (result == DialogResult.No)
                {
                    return;
                }

                dataAccessLayer.Delete(booking);
                dataAccessLayer.DeletePayment(paymentID);
                FillDataGridView();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }


        private void NewBookingUpdateForm()
        {
            try
            {
                Panel parentPanel = (Panel)this.Parent;
                MainForm mainForm = (MainForm)parentPanel.Parent;
                mainForm.panel2.Controls.Clear();

                BookingUpdateForm form = new BookingUpdateForm();
                form.TopLevel = false;
                form.AutoScroll = false;
                form.Dock = DockStyle.Fill;
                form.FormBorderStyle = FormBorderStyle.None;

                mainForm.panel2.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void NewBookingCreateForm()
        {
            try
            {
                Panel parentPanel = (Panel)this.Parent;
                MainForm mainForm = (MainForm)parentPanel.Parent;
                mainForm.panel2.Controls.Clear();

                CreateBookingForm form = new CreateBookingForm();
                form.TopLevel = false;
                form.AutoScroll = false;
                form.Dock = DockStyle.Fill;
                form.FormBorderStyle = FormBorderStyle.None;

                mainForm.panel2.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void dataGridViewBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Returns how many columns there are in the DataGridView
                int columnCount = dataGridViewBookings.Columns.Count;

                if (e.ColumnIndex < columnCount)
                {
                    dataGridViewBookings.ClearSelection();
                    dataGridViewBookings.CurrentRow.Selected = true;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                NewBookingUpdateForm();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void tBoxBookingSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Trim removes leading or trailing white spaces
                string searchText = tBoxBookingSearch.Text.Trim();

                // Create a DataSet and fill it with all Customers
                DataSet dataSet = dataAccessLayer.Find(searchText);

                dataGridViewBookings.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
    }
}
