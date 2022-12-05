using zsat.Models;

namespace zsat.Interfaces
{
    public interface IAppUser
    {
        public AppUser SignUp(string name, string email, string password);
    }
}
