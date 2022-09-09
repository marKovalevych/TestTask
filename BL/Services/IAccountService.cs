using BL.ValidationModels;
using DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface IAccountService
    {
        public Task<string> CreateAccount(AccountCreateModel model, Incident incident);
        public Task<Account> UpdateAccount(AccountUpdateModel model);
        public Task<List<Account>> GetAllAccounts();
        public Task<bool> CheckAccountExistingAsync(string name);
    }
}
