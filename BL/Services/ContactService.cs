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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ISaveChangerService _saveChangerService;

        public ContactService(IContactRepository contactRepository, IAccountRepository accountRepository, ISaveChangerService saveChangerService)
        {
            _contactRepository=contactRepository;
            _accountRepository=accountRepository;
            _saveChangerService = saveChangerService;
        }

        public HashSet<Contact> GetContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public async Task<Contact> UpdateContact(ContactModel model)
        {
            var toUpdate = await _contactRepository.GetContactAsync(model.Email);
            if(toUpdate != null)
            {
                toUpdate.FirstName = model.FirstName;
                toUpdate.LastName = model.LastName;
                toUpdate.Email = model.Email;
                

                _contactRepository.UpdateContact(toUpdate);
                await _saveChangerService.SaveChangerAsync();
                return toUpdate;
            }

            return null;
        }
    }
}
