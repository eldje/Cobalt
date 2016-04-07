using Cobalt.DataAccess.Models;

namespace Cobalt.Modules.MainModule.Services
{
    public interface ILoginService
    {
        bool Login(Account account, string password);
        Account GetAccount(string username);
        int Save(Account account);
    }
}
