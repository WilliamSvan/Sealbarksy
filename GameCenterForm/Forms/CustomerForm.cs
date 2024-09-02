﻿using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;
using GameCenterForm.Forms;
using System.Data;

namespace GameCenterForm
{
    public partial class CustomerForm : Form
    {
        DataAccessLayerCustomer dataAccessLayer = new();

        public CustomerForm()
        {
            InitializeComponent();
            FillDataGridView();
        }

        //In this method, we first set the DataSource property of the DataGridView to the result of
        //calling GetAll().Tables[0]. This will populate the DataGridView with data.

        //Next, we add an event handler for the DataBindingComplete event of the DataGridView.
        //We do this by subscribing to the event with the += operator and passing in the name of the
        //event handler method (DataGridViewCustomers_DataBindingComplete). This event handler
        //method will be called when the DataBindingComplete event is raised.
        public void FillDataGridView()
        {
            try
            {
                dataGridViewCustomers.DataSource = dataAccessLayer.GetAll().Tables[0];
                dataGridViewCustomers.DataBindingComplete += DataGridViewCustomers_DataBindingComplete;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        //Method DataGridViewCustomers_DataBindingComplete and comment generated by ChatGPT
        //This method is called when the DataBindingComplete event is raised. In this method,
        //we simply call the ClearSelection() method of the DataGridView to clear any row selection
        //that may have occurred during the data binding process.

        //By using the DataBindingComplete event to clear the row selection, we ensure that the
        //ClearSelection() method is called after the DataGridView has been populated with data
        //and any row selection has occurred.This should prevent the first row from being selected
        //when the DataGridView is initially displayed.

        private void DataGridViewCustomers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewCustomers.ClearSelection();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CreateCustomerForm form = new CreateCustomerForm();


                form.ShowDialog();

                FillDataGridView();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                //Checking if any row in the DataGridView is selected
                //If no, the user will be notified by a textbox and the method stops here
                if (dataGridViewCustomers.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select the customer to delete",
                        "No customer selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected row and put the values in a Customer object 
                DataGridViewRow selectedRow = dataGridViewCustomers.SelectedRows[0];
                string id = selectedRow.Cells["CustomerID"].Value.ToString();
                string name = selectedRow.Cells["Name"].Value.ToString();
                string phoneNo = selectedRow.Cells["PhoneNumber"].Value.ToString();
                string email = selectedRow.Cells["Email"].Value.ToString();

                Customer customer = new(id, name, phoneNo, email);

                //MessageBox that asks user to confirm deletion
                DialogResult result =
                    MessageBox.Show(
                        $"You are about to delete {customer.CustomerID} {customer.Name}. Do you want to proceed?",
                        "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //If user presses No nothing happens
                if (result == DialogResult.No)
                {
                    return;
                }

                dataAccessLayer.Delete(customer);
                FillDataGridView();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Returns how many columns there are in the DataGridView
            int columnCount = dataGridViewCustomers.Columns.Count;

            if (e.ColumnIndex < columnCount)
            {
                dataGridViewCustomers.ClearSelection();
                dataGridViewCustomers.CurrentRow.Selected = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewCustomers.SelectedRows.Count == 1)
                {
                    DataGridViewRow selectedRow = dataGridViewCustomers.SelectedRows[0];
                    string customerID = selectedRow.Cells["CustomerID"].Value.ToString();

                    UpdateCustomerForm form = new(customerID);

                    form.ShowDialog();
                    FillDataGridView();
                }
                else if (dataGridViewCustomers.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select the customer to update", "No customer selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Please select only one customer to update", "Too many customers selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }

        }

        private void tBoxCustomerSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Trim removes leading or trailing white spaces
                string searchText = tBoxCustomerSearch.Text.Trim();

                // Create a DataSet and fill it with all Customers
                DataSet dataSet = dataAccessLayer.Find(searchText);

                dataGridViewCustomers.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
    }
}