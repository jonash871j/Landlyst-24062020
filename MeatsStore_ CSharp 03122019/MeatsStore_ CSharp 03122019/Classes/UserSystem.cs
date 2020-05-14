using System.Data;
using System.Data.SqlClient;

namespace MeatsStore__CSharp_03122019
{
    class UserSystem : DatabaseCore
    {
        // Used to check if username and password is valid
        public bool CheckLogin(string username, string password)
        {
            // String protection
            if (CheckIllegalCharacters(username)) return false;
            if (CheckIllegalCharacters(password)) return false;

            // Connect to database
            using (var conn = new SqlConnection(connectionString))
            {
                // SQL Statement
                string command = "SELECT Username, Password " +
                                 "FROM Login " +
                                 "WHERE Username='" + username + "' AND Password='" + password + "'";


                // Execute SQL statement
                using (var cmd = new SqlCommand(command, conn))
                {
                    // Translate the SQL code to C# language
                    SqlDataAdapter ds = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ds.Fill(dt);

                    // Checks if Username and Password is valid then return true
                    foreach (DataRow item in dt.Rows)
                        if ((item["Username"].ToString() == username) && (item["Password"].ToString() == password))
                            return true;
                }
            }
            return false;
        }

        // Used to check if username is valid and then sign the user up
        public bool CheckSignUp(string username, string password)
        {
            // String protection
            if (CheckIllegalCharacters(username)) return false;
            if (CheckIllegalCharacters(password)) return false;

            // Connect to database
            using (var conn = new SqlConnection(connectionString))
            {
                // SQL Statement
                string command = "SELECT Username " +
                                 "FROM Login " +
                                 "WHERE Username='" + username + "'";

                // Execute SQL statement
                using (var cmd = new SqlCommand(command, conn))
                {
                    // Translate the SQL code to C# language
                    SqlDataAdapter ds = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ds.Fill(dt);

                    // Checks if Username and Password is valid then return true
                    foreach (DataRow item in dt.Rows)
                        return false;
                    UserSignUp(username, password);
                    return true;
                }
            }
            return false;
        }

        // Signs up a user
        private void UserSignUp(string username, string password)
        {
            // SQL Statement
            string query = "INSERT INTO Login VALUES (@Username, @Password)";

            // Connect to database
            using (var conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                // Add user to database
                conn.Open();
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.ExecuteNonQuery();
            }
        }

        private void SetUserBalance(int balance, string username)
        {
            // Connect to database
            using (var conn = new SqlConnection(connectionString))
            {
                // SQL Statement
                string command = "SELECT Balance " +
                                 "FROM Login " +
                                 "WHERE Username='" + username + "'";

            }
        }
    }
}