using System.Data.SqlClient;

namespace SampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(local);Initial Catalog=SampleDatabase;Integrated Security=True";
            string input = "";

            while (input != "exit")
            {
                Console.WriteLine("Enter an action (create, read, update, delete, exit):");
                input = Console.ReadLine();

                switch (input)
                {
                    case "create":
                        Console.WriteLine("Enter first name:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Enter last name:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Enter age:");
                        int age = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter email:");
                        string email = Console.ReadLine();
                        CreatePerson(connectionString, firstName, lastName, age, email);
                        break;
                    case "read":
                        ReadPersons(connectionString);
                        Console.WriteLine("Enter person ID:");
                        int id = Int32.Parse(Console.ReadLine());
                        ReadPerson(connectionString, id);
                        break;
                    case "update":
                        ReadPersons(connectionString);
                        Console.WriteLine("Enter person ID:");
                        int updateId = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new first name:");
                        string updateFirstName = Console.ReadLine();
                        Console.WriteLine("Enter new last name:");
                        string updateLastName = Console.ReadLine();
                        Console.WriteLine("Enter new age:");
                        int updateAge = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new email:");
                        string updateEmail = Console.ReadLine();
                        UpdatePerson(connectionString, updateId, updateFirstName, updateLastName, updateAge, updateEmail);
                        break;
                    case "delete":
                        Console.WriteLine("Enter person ID:");
                        int deleteId = Int32.Parse(Console.ReadLine());
                        DeletePerson(connectionString, deleteId);
                        break;
                    case "exit":
                        break;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                }
            }
        }

        private static void CreatePerson(string connectionString, string firstName, string lastName, int age, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Person (FirstName, LastName, Age, Email) VALUES (@firstName, @lastName, @age, @email)");
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@email", email);
                command.Connection = connection;
                int result = command.ExecuteNonQuery();
                Console.WriteLine(result + " person(s) created.");
            }
        }

        private static void ReadPerson(string connectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Person WHERE PersonId = @id");
                command.Parameters.AddWithValue("@id", id);
                command.Connection = connection;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)} {reader.GetString(2)}, Age: {reader.GetInt32(3)}, Email: {reader.GetString(4)}");
                    }
                }
                else
                {
                    Console.WriteLine("No persons found.");
                }

                reader.Close();
            }
        }

        private static void UpdatePerson(string connectionString, int id, string firstName, string lastName, int age, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Person SET FirstName = @firstName, LastName = @lastName, Age = @age, Email = @email WHERE PersonId = @id");
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@email", email);
                command.Connection = connection;
                int result = command.ExecuteNonQuery();
                Console.WriteLine(result + " person(s) updated.");
            }
        }

        private static void DeletePerson(string connectionString, int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Person WHERE PersonId = @id");
                command.Parameters.AddWithValue("@id", id);
                command.Connection = connection;
                int result = command.ExecuteNonQuery();
                Console.WriteLine(result + " person(s) deleted.");
            }
        }
        private static void ReadPersons(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT PersonId, FirstName, LastName FROM Person", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("List of persons:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)} {reader.GetString(2)}");
                    }
                }
                else
                {
                    Console.WriteLine("No persons found.");
                }

                reader.Close();
            }
        }

    }
}
