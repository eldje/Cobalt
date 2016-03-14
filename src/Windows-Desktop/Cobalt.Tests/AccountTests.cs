using System.Collections.Generic;
using System.Linq;
using Cobalt.DataAccess.Models;
using Cobalt.DataAccess.Repositories;
using Cobalt.Modules.Login.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cobalt.Tests
{
    [TestClass]
    public class AccountTests
    {
        private LoginService _service;
        private Mock<IAccountRepository> _repository;
        private List<Account> _accounts;

        [TestInitialize]
        public void Setup()
        {
            _repository = new Mock<IAccountRepository>();
            _accounts = new List<Account>
            {
                new Account { AccountId = 1, Username = "John", Hash = "9f3Iv0NW9Jr3l+EmOS/zWCPe96k=", Salt = "y7qwIY0ep8aHiiSwl57dt4ueuCo=" }, // Password is, "TestPassword"
                new Account { AccountId = 2, Username = "Ryan", Hash = "63mnR/gbFIIU6vGEFqoY5H1QCCI=", Salt = "xi/lkLFqPPTR5Q9rX3m/PJ4FH0rECyalYdyRJ6pCpfE=" }, // Password is, "NewPassword"
            };

            _service = new LoginService(_repository.Object);
        }

       
        [TestMethod]
        [TestCategory("Accounts")]
        public void CanLogin()
        {
            _repository.Setup(x => x.GetAccount(It.IsAny<string>()))
                .Returns<string>(username => _accounts.FirstOrDefault(x => x.Username == username));

            var account = _service.GetAccount("John");

            Assert.IsTrue(_service.Login(account, "TestPassword"));
        }
    }
}
