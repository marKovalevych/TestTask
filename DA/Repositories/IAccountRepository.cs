using DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public interface IAccountRepository
    {
        public Task<List<Account>> GetAllAccountsAsync();
        public Task<Account> GetAccountByName(string name);
        public Task CreateAccountAsync(Account account);
        public void UpdateAccount(Account account);
    }
}
