using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;

namespace GameCenterForm.Forms
{
    public partial class UpdateGameForm : Form
    {
        DataAccessLayerGames dataAccessLayer = new();
        public UpdateGameForm()
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

        public UpdateGameForm(string name, int nbrOfPlayers)
        {
            try
            {
                InitializeComponent();
                tBoxName.Text = name;
                numUpDownNbrOfPlayers.Value = nbrOfPlayers;
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
                string newName = tBoxName.Text;
                int nbrOfPlayers = (int)numUpDownNbrOfPlayers.Value;

                Game game = new(newName, nbrOfPlayers);
                dataAccessLayer.Update(game);
                MessageBox.Show($"{game.Name} has now been updated",
                    "Game updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
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
