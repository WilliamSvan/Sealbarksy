using GameCenterForm.ClassLibrary;
using GameCenterForm.DataAccessLayers;

namespace GameCenterForm.Forms
{
    public partial class NewGameForm : Form
    {
        DataAccessLayerGames dataAccessLayer = new();
        public NewGameForm()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string gameName = tBoxName.Text;
                int nbrOfPlayers = (int)numUpDownNbrOfPlayers.Value;

                Game game = new(gameName, nbrOfPlayers);

                dataAccessLayer.Insert(game);
                MessageBox.Show($"Added the game {game.Name} that can have up to {game.NbrOfPlayers} players",
                    "Game Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
    }
}
