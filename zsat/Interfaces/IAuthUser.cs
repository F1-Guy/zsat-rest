using zsat.Models;

namespace zsat.Interfaces
{
    public interface IAuthUser
    {
        public AuthUser SignUp(string userName, string password, string fullName);
        public AuthUser SignIn(string userName, string password);
    }
}
