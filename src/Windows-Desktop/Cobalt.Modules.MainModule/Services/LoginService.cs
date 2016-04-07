using System;
using Cobalt.DataAccess.Models;
using Cobalt.DataAccess.Repositories;
using Cobalt.Infrastructure.Cryptography;

namespace Cobalt.Modules.MainModule.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAccountRepository _accountRepository;

        public LoginService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool Login(Account account, string password)
        {
            try
            {
                var salt = Convert.FromBase64String(account.Salt);
                var hash = HashAlgorithm.GenerateExistingHash(password, salt);

                return hash == account.Hash;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Account GetAccount(string username)
        {
            try
            {
                return _accountRepository.GetAccount(username);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int Save(Account account)
        {
            try
            {
                return _accountRepository.SaveAccount(account);
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
