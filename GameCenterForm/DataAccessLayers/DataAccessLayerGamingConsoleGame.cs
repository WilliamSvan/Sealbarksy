using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm.DataAccessLayers
{
    public class DataAccessLayerGamingConsoleGame : DataAccessLayer
    {
        DataAccessLayerGames dataAccessLayer = new();

        private const string GET_CONSOLE_AND_GAME = "SELECT DISTINCT GamingConsole.ConsoleType, GamingConsoleGame.GameName " +
                      "FROM GamingConsole INNER JOIN GamingConsoleGame ON GamingConsole.TableNo = GamingConsoleGame.TableNo";

        private const string GET_GAMES_ON_SELECTED_CONSOLE = "SELECT GamingConsoleGame.GameName " +
            "FROM GamingConsoleGame " +
            "INNER JOIN gamingConsole ON GamingConsoleGame.TableNo = gamingConsole.TableNo " +
            "INNER JOIN Game ON GamingConsoleGame.GameName = Game.GameName " +
            "WHERE gamingConsole.consoleType = @selectedConsole " +
            "GROUP BY GamingConsoleGame.GameName";

        private const string GET_NON_INSTALLED_GAMES = "SELECT Game.GameName FROM Game " +
               "WHERE Game.GameName NOT IN " +
               "(SELECT GamingConsoleGame.GameName FROM GamingConsoleGame " +
               "INNER JOIN GamingConsole ON GamingConsoleGame.TableNo = GamingConsole.TableNo " +
               "WHERE GamingConsole.ConsoleType = @consoleType)";

        public override DataSet GetAll()
        {
            throw new NotImplementedException();
        }

        public override DataSet Find(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public static List<string> GetNonInstalledGames(string console)
        {

            List<string> items = new List<string>();
            try
            {

                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    SqlCommand gameSelectCommand = new SqlCommand(GET_NON_INSTALLED_GAMES, connection);

                    gameSelectCommand.Parameters.AddWithValue("@consoleType", console);

                    SqlDataAdapter nonInstalledGamesDataAdapter = new SqlDataAdapter(gameSelectCommand);


                    DataTable gameDataTable = new DataTable();
                    nonInstalledGamesDataAdapter.Fill(gameDataTable);

                    foreach (DataRow row in gameDataTable.Rows)
                    {
                        items.Add(row["GameName"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return items;
        }


        public DataSet GetConsoleAndGame()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(GET_CONSOLE_AND_GAME, connection);

                    adapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }

        //Adds games to list from the console choosed in the app (installed games)
        public static List<string> GetConsoleGames(string selectedConsole)
        {
            List<string> items = new List<string>();
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    using (SqlCommand command = new SqlCommand(GET_GAMES_ON_SELECTED_CONSOLE, connection))
                    {
                        connection.Open();

                        //SqlCommand gameSelectCommand = new SqlCommand(GET_GAMES_ON_SELECTED_CONSOLE, connection);
                        //gameSelectCommand.Parameters.AddWithValue("@selectedConsole", selectedConsole);
                        command.Parameters.AddWithValue("@selectedConsole", selectedConsole);

                        /* SqlDataAdapter nonInstalledGamesDataAdapter = new SqlDataAdapter(gameSelectCommand);
                         DataTable gameDataTable = new DataTable();
                         nonInstalledGamesDataAdapter.Fill(gameDataTable);*/
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {

                            DataTable gameDataTable = new DataTable();
                            adapter.Fill(gameDataTable);

                            foreach (DataRow row in gameDataTable.Rows)
                            {
                                items.Add(row["GameName"].ToString());
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return items;
        }


        //Show games of the console choosen in a table in the app
        public DataSet GetGamesOnConsoles(string str)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(GET_GAMES_ON_SELECTED_CONSOLE, connection);
                    command.Parameters.AddWithValue("@selectedConsole", str);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataSet);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }

        public void InstallGame(string console, string game)
        {
            string query = "INSERT INTO GamingConsoleGame (TableNo, GameName) " +
                   "SELECT DISTINCT TableNo, @GameName " +
                   "FROM GamingConsole " +
                   "WHERE ConsoleType = @ConsoleType";

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@ConsoleType", console);
                        command.Parameters.AddWithValue("@GameName", game);

                        command.ExecuteNonQuery();

                        connection.Close(); //BEHÖVS DENNA?!?!?!?!?!
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public void UninstallGame(string consoleType, string game)
        {
            string query = "DELETE GamingConsoleGame " +
                           "FROM GamingConsoleGame " +
                           "JOIN GamingConsole ON GamingConsoleGame.TableNo = GamingConsole.TableNo " +
                           "WHERE GamingConsole.ConsoleType LIKE @ConsoleType " +
                           "AND GamingConsoleGame.GameName = @GameName";

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@ConsoleType", "%" + consoleType + "%");
                        command.Parameters.AddWithValue("@GameName", game);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }
    }
}
