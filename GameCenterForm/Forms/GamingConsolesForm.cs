using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;
using System.Data;

namespace GameCenterForm.Forms
{
    public partial class GamingConsolesForm : Form
    {
        DataAccessLayerConsoles dataAccessLayer = new();
        public GamingConsolesForm()
        {
            InitializeComponent();
            FillDataGridView();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            HandlebtnNew_Click();
        }

        private void tBoxConsoleSearch_TextChanged(object sender, EventArgs e)
        {
            HandleTBoxConsoleSearch_TextChanged();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteConsole();
        }

        private void dataGridViewConsoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Returns how many columns there are in the DataGridView
            int columnCount = dataGridViewConsoles.Columns.Count;

            if (e.ColumnIndex < columnCount)
            {
                dataGridViewConsoles.ClearSelection();
                dataGridViewConsoles.CurrentRow.Selected = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            HandleBtnUpdate_Click();
        }

        #region METHODS


        private void HandlebtnNew_Click()
        {
            NewConsoleForm form = new NewConsoleForm();
            form.ShowDialog();
            FillDataGridView();

        }
        private void HandleTBoxConsoleSearch_TextChanged()
        {
            // Trim removes leading or trailing white spaces
            string searchText = tBoxConsoleSearch.Text.Trim();

            // Create a DataSet and fill it with all Customers
            DataSet dataSet = dataAccessLayer.Find(searchText);

            dataGridViewConsoles.DataSource = dataSet.Tables[0];

        }
        private void DeleteConsole()
        {
            try
            {
                //Checking if any row in the DataGridView is selected
                //If no, the user will be notified by a textbox and the method stops here
                if (dataGridViewConsoles?.SelectedRows?.Count == 0)
                {
                    MessageBox.Show(
                        "Please select the console to delete",
                        "No console selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected row and put the values in a Console object
                DataGridViewRow selectedRow = dataGridViewConsoles.SelectedRows[0];
                int tableNo = (int)selectedRow.Cells["TableNo"].Value;
                string type = selectedRow.Cells["ConsoleType"].Value.ToString();
                int nbrOfPlayers = (int)selectedRow.Cells["NbrOfPlayers"].Value;

                GamingConsole gamingConsole = new GamingConsole(tableNo, type, nbrOfPlayers);

                //MessageBox that asks user to confirm deletion
                DialogResult result =
                    MessageBox.Show(
                        $"You are about to delete ({gamingConsole.TableNo}) {gamingConsole.ConsoleType}" +
                        $". This will also delete all bookings and payments connected to this console. \n\n Do you want to proceed?", "Confirm deletion",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //If user presses No nothing happens
                if (result == DialogResult.No)
                {
                    return;
                }
                dataAccessLayer.DeletePayment(tableNo);
                dataAccessLayer.Delete(gamingConsole);               
                FillDataGridView();

            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }


        }
        private void HandleBtnUpdate_Click()
        {
            //Checks if only one row is selected
            if (dataGridViewConsoles?.SelectedRows.Count == 1)
            {
                // Gets the selected row
                DataGridViewRow selectedRow = dataGridViewConsoles.SelectedRows[0];

                string selectedTableNo = selectedRow.Cells["TableNo"].Value.ToString();

                UpdateConsoleForm form = new(selectedTableNo);
                form.ShowDialog();
            }
            // 0 selected
            else if (dataGridViewConsoles?.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please select a console to update!", "No console selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Else too many rows selected
            else
            {
                MessageBox.Show("Please select only one console to update!", "Too many selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            FillDataGridView();
        }
        //In this method, we first set the DataSource property of the DataGridView to the result of
        //calling GetAll().Tables[0]. This will populate the DataGridView with data.

        //Next, we add an event handler for the DataBindingComplete event of the DataGridView.
        //We do this by subscribing to the event with the += operator and passing in the name of the
        //event handler method (dataGridViewConsoles_DataBindingComplete). This event handler
        //method will be called when the DataBindingComplete event is raised.
        public void FillDataGridView()
        {
            try
            {
                dataGridViewConsoles.DataSource = dataAccessLayer.GetAll().Tables[0];
                dataGridViewConsoles.DataBindingComplete += dataGridViewConsoles_DataBindingComplete;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        //Method dataGridViewConsoles_DataBindingComplete and comment generated by ChatGPT
        //This method is called when the DataBindingComplete event is raised. In this method,
        //we simply call the ClearSelection() method of the DataGridView to clear any row selection
        //that may have occurred during the data binding process.

        //By using the DataBindingComplete event to clear the row selection, we ensure that the
        //ClearSelection() method is called after the DataGridView has been populated with data
        //and any row selection has occurred.This should prevent the first row from being selected
        //when the DataGridView is initially displayed.

        private void dataGridViewConsoles_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewConsoles.ClearSelection();
        }


    }
}

#endregion