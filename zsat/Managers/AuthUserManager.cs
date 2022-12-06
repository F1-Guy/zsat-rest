using System.Reflection.Metadata;
using System.Security.Cryptography;
using zsat.Interfaces;
using zsat.Models;
using static System.Net.Mime.MediaTypeNames;

namespace zsat.Managers
{
    public class AuthUserManager : IAuthUser
    {
        private readonly ZsatDbContext _context;
        private const string passwordSalt = "nf8n43nsd9s";

        public AuthUserManager(ZsatDbContext context)
        {
            _context = context;
        }

        public AuthUser SignIn(string userName, string password)
        {
            string hashedPassword = "";

            // Uses SHA256 to create the hash
            using (SHA256 sha = SHA256.Create())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password + passwordSalt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);
                hashedPassword = hash;
            }

            AuthUser? foundUser = _context.AuthUsers.Where(u => u.UserName == userName).FirstOrDefault();
            if (foundUser != null && foundUser.Password == hashedPassword) return foundUser;
            return null;
        }

        public AuthUser SignUp(string userName, string password, string fullName)
        {
            string hashedPassword = "";

            // Uses SHA256 to create the hash
            using (SHA256 sha = SHA256.Create())
            {
                // Convert the string to a byte array first, to be processed
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password + passwordSalt);
                byte[] hashBytes = sha.ComputeHash(textBytes);

                // Convert back to a string, removing the '-' that BitConverter adds
                string hash = BitConverter
                    .ToString(hashBytes)
                    .Replace("-", String.Empty);
                hashedPassword = hash;
            }

            AuthUser user = new() { UserName = userName, Password = hashedPassword, FullName = fullName };
            _context.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
