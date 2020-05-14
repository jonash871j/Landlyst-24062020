

using System.Collections.Generic;

namespace MeatsStore__CSharp_03122019
{
    static public class GlobalUser
    {
        private static bool isUserLogined = false;
        private static string username = "";
        private static int balance = 0;
        private static List<int> gameBasket = new List<int>();

        public static bool IsUserLogined
        {
            get { return isUserLogined; }
            set { isUserLogined = value; }
        }
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }
        public static int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public static List<int> GameBasket
        {
            get { return gameBasket; }
            set { gameBasket = value; }
        }

        static public void Logout()
        {
            GameBasket.Clear();
            isUserLogined = false;
            username = "";
        }
    }
}