using System.Security.Cryptography;
using zsat.Interfaces;
using zsat.Models;
using static System.Net.Mime.MediaTypeNames;

namespace zsat.Managers
{
    public class AuthUserManager : IAuthUser
    {
        private readonly ZsatDbContext _context;

        public AuthUserManager(ZsatDbContext context)
        {
            _context = context;
        }

        public AuthUser SignUp(string userName, string password)
        {
            string hashedPassword = "";

            // Uses SHA256 to create the hash
            using (SHA256 sha = SHA256.Create())
            {
                // Convert the string to a byte array first, to be processed
                string salt = "nf8n43nsd9s";
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password + salt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);
                hashedPassword = hash;
            }

            AuthUser user = new() { UserName = userName, Password = hashedPassword };
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
