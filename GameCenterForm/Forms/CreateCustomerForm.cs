using GameCenterForm.DataAccessLayers;

namespace GameCenterForm
{
    public partial class CreateCustomerForm : Form
    {
        DataAccessLayerCustomer dataAccessLayer = new();

        public CreateCustomerForm()
        {
            InitializeComponent();
            lblCustomerID.Text = DataAccessLayer.GetNextID("C", "Customer", "CustomerID");
        }


        private void btnCreate_Click(object sender, EventArgs e)
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
                else if (phoneNo.Length != 10 || !phoneNo.StartsWith('0'))
                {
                    MessageBox.Show("Phone number must be 10 digits and start with 0.", "Try again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ClassLibrary.Customer customer = new(cID, name, phoneNo, email);

                    dataAccessLayer.Insert(customer);
                    MessageBox.Show($"Created customer: {name} with customerID {customer.CustomerID}",
                        "Customer Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
