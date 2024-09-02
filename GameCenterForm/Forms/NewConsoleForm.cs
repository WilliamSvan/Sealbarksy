using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;

namespace GameCenterForm.Forms
{
    public partial class NewConsoleForm : Form
    {
        DataAccessLayerConsoles dataAccessLayer = new();
        public NewConsoleForm()
        {
            InitializeComponent();
            lblTableNo.Text = dataAccessLayer.GetNextTableNumber().ToString();
        }
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int tableNo = Int32.Parse(lblTableNo.Text);
                string consoleType = cBoxConsoleType.Text;
                int nbrOfPlayers = (int)numUpDownNbrOfPlayers.Value;

                GamingConsole gamingConsole = new(tableNo, consoleType, nbrOfPlayers);

                dataAccessLayer.Insert(gamingConsole);
                MessageBox.Show($"Added a {consoleType} to table #{tableNo}",
                    "Console Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
    }
}
