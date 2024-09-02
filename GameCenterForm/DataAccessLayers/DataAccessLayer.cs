using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm.DataAccessLayers
{
    public abstract class DataAccessLayer : IDataAccessLayer
    {

        protected static DataSet dataSet = new("GamingCenter");
        protected string selectAllQuery;

        public static SqlConnection GetDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings
                ["GameCenterConnectionString"].ConnectionString;

            SqlConnectionStringBuilder builder = new(connectionString);


            SqlConnection connection = new(builder.ConnectionString);

            return connection;
        }
        public static string GetNextID(string prefix, string table, string id)
        {
            string query = $"SELECT MAX({id}) FROM {table} WHERE {id} LIKE @prefix";
            using (SqlConnection connection = DataAccessLayer.GetDatabaseConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.Parameters.AddWithValue("@prefix", prefix + "%");

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        string lastID = result.ToString();
                        string nextID = IncrementString(lastID);
                        if (nextID.StartsWith(prefix))
                        {
                            return nextID;
                        }
                    }
                    return prefix + "00001";
                }
            }
        }
        public static string IncrementString(string input)
        {
            char firstLetter = input[0];
            int restOfString = int.Parse(input.Substring(1));
            restOfString++;
            return firstLetter + restOfString.ToString().PadLeft(input.Length - 1, '0');
        }

        public abstract DataSet GetAll();
        public virtual void Insert(object o) { }
        public virtual void Delete(object o) { }
        public virtual void Update(object o) { }
        public abstract DataSet Find(string searchTerm);
    }
}
