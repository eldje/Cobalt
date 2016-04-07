using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobalt.DataAccess.Models;

namespace Cobalt.DataAccess.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Account GetAccount(string username)
        {
            throw new NotImplementedException();
        }

        public int SaveAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
