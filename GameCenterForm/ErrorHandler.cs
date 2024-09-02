using System.Data;
using System.Data.SqlClient;

namespace GameCenterForm
{
    public class ErrorHandler
    {
        //Whole class created with Github CoPilot and ChatGPT with minor changes from devs
        public static void HandleException(Exception ex)
        {
            //sql exception handler
            {
                string errorMessage = "An error occurred.";
                if (ex is SqlException sqlException)
                {
                    switch (sqlException.Number)
                    {
                        case 53:
                            errorMessage = "Could not connect to the server. Please make sure that the server is running. Contact your IT-guy.";
                            break;
                        case 207:
                            errorMessage = "Invalid column name. Check the query and parameters to make sure they are correct. Contact your IT-guy.";
                            break;
                        case 208:
                            errorMessage = "Invalid object name. Check the query and parameters to make sure they are correct. Contact your IT-guy.";
                            break;
                        case 2627:
                            errorMessage = "Violation of unique constraint. The data you are trying to insert already exists in the database. Contact your IT-guy.";
                            break;
                        case 547:
                            errorMessage = "Constraint violation. The data you are trying to insert or update violates a constraint in the database. Contact your IT-guy.";
                            break;
                        case 18456:
                            errorMessage = "Login failed. Check the username and password to make sure they are correct. Contact your IT-guy.";
                            break;
                        case 18452:
                            errorMessage = "Login failed. Check the username and password to make sure they are correct. Contact your IT-guy.";
                            break;
                        case 4060:
                            errorMessage = "Invalid database. Check the database name to make sure it is correct. Contact your IT-guy.";
                            break;
                        case 18461:
                            errorMessage = "Login failed. Check the username and password to make sure they are correct. Contact your IT-guy.";
                            break;
                        case 233:
                            errorMessage = "The database does not accept incoming connections at this time. Contact your IT-guy.";
                            break;
                        case 2:
                            errorMessage = "The server was not found or was not accessible. Check the server name to make sure it is correct. Contact your IT-guy.";
                            break;
                        case 64:
                            errorMessage = "The server was not found or was not accessible. Check the server name to make sure it is correct. Contact your IT-guy.";
                            break;

                        default:
                            errorMessage = sqlException.Message;
                            break;
                    }
                }
                else if (ex is ConstraintException)
                {
                    errorMessage = "Customer ID already exists, pick a new one.";
                }
                else if (ex is InvalidOperationException)
                {
                    errorMessage = "Invalid operation. Check the query and parameters to make sure they are correct.\nError type: " + ex.GetType().Name;
                }
                else if (ex is ArgumentException)
                {
                    errorMessage = "Invalid argument. Check the query and parameters to make sure they are correct. \nError type: " + ex.GetType().Name;
                }
                else if (ex is ArgumentNullException)
                {
                    errorMessage = "Invalid argument. Check the query and parameters to make sure they are correct. \nError type: " + ex.GetType().Name;
                }
                else if (ex is ArgumentOutOfRangeException)
                {
                    errorMessage = "Invalid argument. Check the query and parameters to make sure they are correct. \nError type: " + ex.GetType().Name;
                }
                else if (ex is OverflowException)
                {
                    errorMessage = "Invalid format. Check the query and parameters to make sure they are correct. \nError type: " + ex.GetType().Name;
                }
                else if (ex is IndexOutOfRangeException)
                {
                    errorMessage = "Invalid index. Check the query and parameters to make sure they are correct. \nError type: " + ex.GetType().Name;
                }
                else if (ex is NullReferenceException)
                {
                    errorMessage = "You can't do that. Speak with your IT-guy! \nError type: " + ex.GetType().Name;
                }
                else if (ex is OutOfMemoryException)
                {
                    errorMessage = "Out of memory. Check the query and parameters to make sure they are correct.\nError type: " + ex.GetType().Name;
                }
                else if (ex is StackOverflowException)
                {
                    errorMessage = "Stack overflow. Check the query and parameters to make sure they are correct.\nError type: " + ex.GetType().Name;
                }
                /*else if (ex is FormatException)
                {
                    errorMessage = "Invalid format. Check the query and parameters to make sure they are correct.\nError type: " + ex.GetType().Name;
                }*/
                else if (ex is Exception)
                {
                    errorMessage = "Error. Something went terribly wrong... Take the errormessage to your IT-guy \nError type: " + ex.GetType().Name;
                }
                else if (ex is SystemException)
                {
                    errorMessage = "System error. Check the query and parameters to make sure they are correct.\nError type: " + ex.GetType().Name;
                }
                else
                {
                    errorMessage = ex.Message;
                }

                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool ContainsDigits(string str)
        {
            foreach (char c in str)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}