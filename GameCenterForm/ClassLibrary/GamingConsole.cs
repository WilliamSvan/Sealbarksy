namespace GameCenterForm.ClassLibrary
{
    public class GamingConsole
    {
        public int TableNo { get; set; }
        public string ConsoleType { get; set; }
        public int NbrOfPlayers { get; set; }

        public GamingConsole(int tableNo, string consoleType, int nbrOfPlayers)
        {
            TableNo = tableNo;
            ConsoleType = consoleType;
            NbrOfPlayers = nbrOfPlayers;
        }

    }
}
