using System;
using System.Data;
using System.Data.SqlClient;

namespace Database
{
    class Program
    {
        static string connectionString =
            "Data Source=ZBC-ERO-SKP1656;" +
            "Initial Catalog=MeatsStore;" +
            "Integrated Security=true";

        static void ShowGames()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string command = "SELECT * FROM Game";

                using (var cmd = new SqlCommand(command, conn))
                {
                    SqlDataAdapter ds = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ds.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                    {
                        Console.Write(item["Game"].ToString() + " | ");
                        Console.Write(item["Price"].ToString() + " | ");
                        Console.WriteLine(item["Amount"].ToString());
                    }
                }
            }
        }

        static void AddGame(string game, string price, string amount)
        {
            string query = "INSERT INTO Game VALUES (@Game, @Price, @Amount)";

            using (var conn = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, conn))
            {
                conn.Open();

                command.Parameters.AddWithValue("@Game", game);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Amount", amount);

                command.ExecuteNonQuery();
            }
        }

        static bool UserLogin(string Username, string Password)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string command = "SELECT Username, Password " +
                                 "FROM Login " +
                                 "WHERE Username='" + Username + "' AND Password='" + Password + "'";

                using (var cmd = new SqlCommand(command, conn))
                {
                    SqlDataAdapter ds = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ds.Fill(dt);

                    foreach (DataRow item in dt.Rows)
                        if ((item["Username"].ToString() == Username) && (item["Password"].ToString() == Password))
                            return true;
                }
            }
            return false;
        }

        static string game;
        static string price;
        static string amount;

        static void Main(string[] args)
        {

            while (true)
            {
                ShowGames();
                Console.Write("Game: ");
                game = Console.ReadLine();
                Console.Write("Price: ");
                price = Console.ReadLine();
                Console.Write("Amount: ");
                amount = Console.ReadLine();
                AddGame(game, price, amount);
                Console.Clear();

                //if (UserLogin("Admin", "Password"))
                //    Console.WriteLine("You are loged in!");
                //else
                //    Console.WriteLine("Failed!");
                //Console.Read();
            }
        }
    }
}
