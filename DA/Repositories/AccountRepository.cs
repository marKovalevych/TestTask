using DA.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context=context;
        }
        public async Task<Account> GetAccountByName(string name)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task CreateAccountAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public Task<List<Account>> GetAllAccountsAsync()
        {
            return _context.Accounts.ToListAsync();
        }

        public  void UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
        }
    }
}
