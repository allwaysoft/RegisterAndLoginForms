using RegisterAndLoginForms.Models;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace RegisterAndLoginForms.Services
{
    public class UsersDAO
    {
        string connectionString = @"server=localhost;user=root;database=customerdb;port=3306;password=root";
           
        public bool FindUserByNameAndPassword(UserModel user)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM Users WHERE username=@username AND password=@password";

            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@password", user.Password);
                try
                {
                    connection.Open();
                    MySqlDataReader reader =command.ExecuteReader();
                    if (reader.HasRows)
                        success= true;
                }
                catch (Exception e )
                {
                    Console.WriteLine(e.Message);
                    //throw;
                }
            }
            return success;
        }
    }
}
