using System.Data;
using System.Data.SqlClient;

namespace MeatsStore__CSharp_03122019
{
    public class GameSystem : DatabaseCore
    {
        private string[,] gameTable;
        private int lengthRow;
        private int lengthCol = 3;

        public string[,] GameTable
        {
            get { return gameTable;  }
            set { gameTable = value; }
        }
        public int LengthRow
        {
            get { return lengthRow; }
            set { lengthRow = value; }
        }
        public int LengthCol
        {
            get { return lengthCol; }
            set { lengthCol = value; }
        }

        public GameSystem()
        {
            // Connect to database
            using (var conn = new SqlConnection(connectionString))
            {
                // SQL Statement
                string command = "SELECT * FROM Game";

                // Execute SQL statement
                using (var cmd = new SqlCommand(command, conn))
                {
                    // Translate the SQL code to C# language
                    SqlDataAdapter ds = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ds.Fill(dt);

                    // Set the size of the gameTable array
                    gameTable = new string[dt.Rows.Count, lengthCol];

                    // Adds data from the database to the gameTable array
                    int y = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        gameTable[y, 0] = item["Game"].ToString();
                        gameTable[y, 1] = item["Price"].ToString();
                        gameTable[y, 2] = item["Amount"].ToString();
                        y++;
                    }
                    lengthRow = y;
                }
            }
        }
    }
}