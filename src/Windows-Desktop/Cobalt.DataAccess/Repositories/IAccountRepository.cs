using Cobalt.DataAccess.Models;

namespace Cobalt.DataAccess.Repositories
{
    public interface IAccountRepository
    {
        Account GetAccount(int id);
        Account GetAccount(string username);
        int SaveAccount(Account account);
    }
}
