using GameCenterForm.ClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm.DataAccessLayers
{
    public class DataAccessLayerGames : DataAccessLayer

    {
        private const string SELECT_ALL_GAMES = "SELECT * FROM Game";
        private const string INSERT_GAME_QUERY = "INSERT INTO Game (GameName, NbrOfPlayers) " +
            "VALUES (@Name, @NbrOfPlayers)";
        private const string DELETE_GAME_QUERY = "DELETE FROM Game WHERE GameName = @Name";
        private const string UPDATE_GAME_QUERY = "UPDATE Game SET GameName = @Name, " +
            "NbrOfPlayers = @NbrOfPlayers " +
            "WHERE GameName = @Name";

        public override DataSet GetAll()
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(SELECT_ALL_GAMES, connection);


                    adapter.Fill(dataSet);

                    return dataSet;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }


        public override void Insert(object o)
        {
            try
            {
                if (o is Game)
                {
                    Game game = (Game)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        using (SqlCommand command = new(INSERT_GAME_QUERY, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@Name", game.Name);
                            command.Parameters.AddWithValue("@NbrOfPlayers", game.NbrOfPlayers);

                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public override void Delete(object o)
        {
            try
            {
                if (o is Game)
                {
                    Game game = (Game)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        using (SqlCommand command = new(DELETE_GAME_QUERY, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@Name", game.Name);
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }

        public override void Update(object o)
        {
            try
            {
                if (o is Game)
                {
                    Game game = (Game)o;
                    using (SqlConnection connection = GetDatabaseConnection())
                    {
                        using (SqlCommand command = new SqlCommand(UPDATE_GAME_QUERY, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@Name", game.Name);
                            command.Parameters.AddWithValue("@NbrOfPlayers", game.NbrOfPlayers);

                            command.ExecuteNonQuery();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
        }


        public override DataSet Find(string searchTerm)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    string query = "SELECT * FROM Game WHERE GameName LIKE @SearchTerm " +
                                   "OR NbrOfPlayers LIKE @SearchTerm";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            connection.Open();

                            adapter.Fill(dataSet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex);
            }
            return dataSet;
        }

        public static List<string> GetComboBoxGames()
        {
            List<string> items = new List<string>();
            try
            {
                string queryString = "SELECT GameName FROM Game";
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    connection.Open();

                    SqlCommand gameSelectCommand = new SqlCommand(queryString, connection);

                    SqlDataAdapter consoleTypeDataAdapter = new SqlDataAdapter(gameSelectCommand);

                    DataTable gameDataTable = new DataTable();
                    consoleTypeDataAdapter.Fill(gameDataTable);

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
    }
}

