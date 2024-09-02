namespace GameCenterForm.ClassLibrary
{
    public class Game
    {
        public string Name { get; set; }
        public int NbrOfPlayers { get; set; }

        public Game(string name, int nbrOfPlayers)
        {
            Name = name;
            NbrOfPlayers = nbrOfPlayers;
        }
    }
}
