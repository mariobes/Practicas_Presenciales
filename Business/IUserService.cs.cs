using Practices.Models;

namespace Practices.Business;
public interface IUserService
{
    void RegisterUser(string name, string email, string password, string dni, string phone);
    void PrintAllUsers();
    bool CheckUserExist(string email);
    bool CheckLoginUser(string email, string password);
    User GetUser(string email);
    void DeleteUser(string email);
    void UpdateUser(string email, string newName, string newEmail, string newPassword, string newDni, string newPhone);
    string InputEmpty();
}
