using SimpleBankingModelLibrary;

namespace SimpleBankingDALibrary
{
    public interface IUserRepo
    {
        void AddUser(User user);
        User GetUserByUsername(string username);
    }
}
