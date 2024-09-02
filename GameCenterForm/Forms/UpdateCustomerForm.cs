using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;

namespace GameCenterForm.Forms
{
    public partial class UpdateCustomerForm : Form
    {
        DataAccessLayerCustomer dataAccessLayer = new();

        public UpdateCustomerForm()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public UpdateCustomerForm(string customerID)
        {
            try
            {
                InitializeComponent();
                lblCustomerID.Text = customerID;
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string cID = lblCustomerID.Text;
                string name = tBoxName.Text;
                string phoneNo = tBoxPhone.Text;
                string email = tBoxEmail.Text;

                if (ErrorHandler.ContainsDigits(phoneNo) == false)
                {
                    MessageBox.Show("Phonenumber must contain digits only. Try again.", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ErrorHandler.ContainsDigits(name) == true)
                {
                    MessageBox.Show("Name can only contain letters.", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ErrorHandler.IsValidEmail(email) == false)
                {
                    MessageBox.Show("Email must follow naming conventions.", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Customer customer = new(cID, name, phoneNo, email);

                    dataAccessLayer.Update(customer);
                    MessageBox.Show($"Updated customer: {name} with customerID {customer.CustomerID}",
                               "Customer Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
    }
}
