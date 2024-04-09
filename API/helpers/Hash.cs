using static BCrypt.Net.BCrypt;

namespace Data.helpers
{
    public class Hash
    {
       public static string HashGeneration(string password)
        {
            int workFactor = 10;
            string hashedPassword = HashPassword(password, workFactor);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return Verify(password, hashedPassword);
        }

    }
}
