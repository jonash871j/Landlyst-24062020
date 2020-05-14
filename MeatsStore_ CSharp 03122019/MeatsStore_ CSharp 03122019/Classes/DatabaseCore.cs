namespace MeatsStore__CSharp_03122019
{
    public class DatabaseCore
    {
        protected string connectionString =
            "Data Source=ZBC-ERO-SKP1656;" +
            "Initial Catalog=MeatsStore;" +
            "Integrated Security=true";

        // Used to check illegal characters in a text like /\ .: 
        protected bool CheckIllegalCharacters(string text)
        {
            for (int i = 0; i < 48; i++)
                if (text.Contains(((char)i).ToString()))
                    return true;
            // Does not check from 0 - 9
            for (int i = 58; i < 65; i++)
                if (text.Contains(((char)i).ToString()))
                    return true;
            // Does not check from A - Z
            for (int i = 91; i < 97; i++)
                if (text.Contains(((char)i).ToString()))
                    return true;
            // Does not check from a - z
            for (int i = 123; i < 255; i++)
                if (text.Contains(((char)i).ToString()))
                    return true;
            return false;
        }
    }
}