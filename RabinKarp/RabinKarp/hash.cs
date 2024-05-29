using System.Security.Cryptography;
using System.Text;

namespace RabinKarp
{
    public class HashSHA256
    {
        public static string GetHash(string _string)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.UTF8.GetBytes(_string))); //ASCII - для латиницы. UTF8 - для кириллицы включительно
        }
    }
}
