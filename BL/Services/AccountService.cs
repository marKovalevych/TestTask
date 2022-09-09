using BL.ValidationModels;
using DA.Entities;
using DA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ISaveChangerService _saveChangerService;

        public AccountService(IAccountRepository accountRepository, IContactRepository contactRepository, ISaveChangerService saveChangerService)
        {
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _saveChangerService = saveChangerService;
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _accountRepository.GetAllAccountsAsync();
        }

        public async Task<Account> UpdateAccount(AccountUpdateModel model)
        {
            var toUpdate = await _accountRepository.GetAccountByName(model.OldName);

            if (toUpdate != null)
            {
                toUpdate.Name = model.Name;

                var contact = await _contactRepository.GetContactByAccountAsync(model.OldName);
                if (contact == null)
                {
                    return null;
                }
                contact.AccountName = toUpdate.Name;
                _contactRepository.UpdateContact(contact);

                _accountRepository.UpdateAccount(toUpdate);

                return (toUpdate);
                await _saveChangerService.SaveChangerAsync();
            }

            return null;
        }

        public async Task<bool> CheckAccountExistingAsync(string name)
        {
            var account = await _accountRepository.GetAccountByName(name);

            return account != null ? true : false;
        }

        public async Task<string> CreateAccount(AccountCreateModel model, Incident incident)
        {
            var contacts = _contactRepository.GetAllContacts();

            if (!contacts.Contains(await _contactRepository.GetContactAsync(model.Email)))
            {

                var contact = new Contact()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AccountName = model.Name
                };

                contacts.Clear();
                contacts.Add(contact);
                var accountToCreate = new Account
                {
                    IncidentTitle = incident.Title,
                    Incident = incident,
                    Name = model.Name
                };

                await _accountRepository.CreateAccountAsync(accountToCreate);
                var ac = await _accountRepository.GetAccountByName(accountToCreate.Name);
                contact.AccountId = ac.Id;
                await _contactRepository.CreateContactAsync(contact);

                return "Ok";
            }

            var account = new Account
            {
                IncidentTitle = incident.Title,
                Incident = incident,
                Name = model.Name,
                Contacts = contacts.Where(x => x.AccountName == model.Name).ToList()
            };
            await _accountRepository.CreateAccountAsync(account);
            await _saveChangerService.SaveChangerAsync();
            return "Ok";
        }
    }
}
