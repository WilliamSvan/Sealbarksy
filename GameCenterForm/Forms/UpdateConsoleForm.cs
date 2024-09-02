using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;

namespace GameCenterForm.Forms
{
    public partial class UpdateConsoleForm : Form
    {
        DataAccessLayerConsoles dataAccessLayer = new();
        public UpdateConsoleForm()
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

        public UpdateConsoleForm(string tableNo)
        {
            try
            {
                InitializeComponent();
                lblTableNo.Text = tableNo;
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
                // selected index is -1 if nothing is selected
                if (cBoxConsoleType.SelectedIndex != -1)
                {
                    int tableNo = Int32.Parse(lblTableNo.Text);
                    string consoleType = cBoxConsoleType.Text;
                    int nbrOfPlayers = (int)numUpDownNbrOfPlayers.Value;

                    GamingConsole gamingConsole = new(tableNo, consoleType, nbrOfPlayers);

                    dataAccessLayer.Update(gamingConsole);
                    MessageBox.Show($"Table #{tableNo} now has a {consoleType}",
                        "Console updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please select the console type!", "No console type selected",
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
